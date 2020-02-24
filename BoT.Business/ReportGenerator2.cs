using BoT.Business.Managers;
using BoT.Business.Utilities;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace BoT.Business
{
    public class ReportGenerator2
    {
        private FileList _fileList;
        public OutputFiles OutputFiles = new OutputFiles();
        public const string OnlineBotLicence = "MT125610008";
        public List<Transaction> Transactions { get; set; }
        public List<OnlineTransaction> OnlineTransactions { get; set; }
        public List<RefundTransaction> RefundTransactions { get; set; }
        public List<AmazonFile> AmazonTransactions { get; set; }
        public Dictionary<string, ComplianceFile> ComplianceDict { get; set; }
        public List<MonitoringFile> MonitoringTransactions { get; set; }
        public List<Transaction> FilteredTransactions { get; set; }

        public Dictionary<string, string> ObjectiveCodes = new Dictionary<string, string>()
        {
            {"01", "318059"},
            {"02", "318012"},
            {"03", "318013"},
            {"04", "318209"},
            {"05", "318132"}
        };

        private readonly log4net.ILog _logger;


        public ReportGenerator2(ILog logger, FileList fileList)
        {
            _logger = logger;
            _fileList = fileList;
        }

        public void Clear()
        {
            Transactions.Clear();
            OnlineTransactions.Clear();
            RefundTransactions.Clear();
            AmazonTransactions.Clear();
            ComplianceDict.Clear();
            MonitoringTransactions.Clear();
            FilteredTransactions.Clear();
        }

        public List<Transaction> ReadTransactions(string filePath)
        {
            _fileList.MainFile = filePath;
            CodeConversionManager codeManager = new CodeConversionManager(_fileList.CountryCodeFile, _fileList.CurrencyCodeFile);
            TransactionManager manager = new TransactionManager(codeManager);
            Transactions = manager.ReadReport(_fileList.MainFile);
            return Transactions;
        }

        public List<OnlineTransaction> GetOnlineTransactions(string filePath)
        {
            _fileList.StatusFile = filePath;
            OnlineTransactions = new OnlineFileManager().ReadReport(_fileList.StatusFile);
            return OnlineTransactions;
        }

        public List<RefundTransaction> GetRefundTransactions(string filePath)
        {
            _fileList.RefundFile = filePath;
            RefundTransactions = new RefundFileManager().ReadReport(_fileList.RefundFile);
            return RefundTransactions;
        }

        public List<AmazonFile> GetAmazonTransactions(string filePath)
        {
            _fileList.AmazonFile = filePath;
            AmazonTransactions = new AmazonFileManager().ReadReport(_fileList.AmazonFile);
            return AmazonTransactions;
        }

        public Dictionary<string, ComplianceFile> GetComplianceList(string filePath)
        {
            _fileList.ComplianceFile = filePath;
            ComplianceFileManager manager = new ComplianceFileManager(_fileList.DocumentTypeCodeFile);
            ComplianceDict = manager.ReadReport(_fileList.ComplianceFile);
            return ComplianceDict;
        }

        public List<MonitoringFile> GetMonitoringTransactions(string filePath)
        {
            _fileList.MonitoringFile = filePath;
            MonitoringTransactions = new MonitoringFileManager().ReadReport(_fileList.MonitoringFile);
            MonitoringTransactions = MonitoringTransactions.Where(e => e.IsGoods).ToList();
            return MonitoringTransactions;
        }

        private List<OutputTransaction> GetOutput()
        {
            _logger.Info("Getting Output...");
            FilteredTransactions = FilterTransactions();
            ProcessAmazonList();

            BotCodeManager botCodeManager = new BotCodeManager(_fileList.BotCodeFile);
            List<OutputTransaction> output = new List<OutputTransaction>();
            foreach (var t in FilteredTransactions)
            {
               
                var item = new OutputTransaction(t);
                item.IsThaiCode = GetIsThaiCode(item.Nationality);
                item.CustomerType = item.IsAmazon ? TransactionConst.Personal : TransactionConst.NonPersonal;
                if (ComplianceDict.TryGetValue(item.MTCN, out ComplianceFile code))
                {
                    item.DocumentTypeCode = code.DocumentTypeCode;
                }
                else
                {
                    item.IsValid = false;
                    _logger.Info($"{item.MTCN} is missing from compliance. Can't get DocumentTypeCode");
                }

                item.ExchangeRate = Math.Round(item.ExchangeRate, 7);
                botCodeManager.MapBotCode(item);
                if (ObjectiveCodes.TryGetValue(item.Objective, out string objectiveCode))
                {
                    item.ObjectiveCode = objectiveCode;
                    if (item.Objective == "04")
                    {
                        var monitoringItem = MonitoringTransactions.FirstOrDefault(e => e.MTCN == item.MTCN);
                        if (monitoringItem != null && monitoringItem.IsGoods)
                        {
                            item.ObjectiveCode = ObjectiveCodes["05"];
                        }
                    }
                }
                else
                {
                    item.IsValid = false;
                    _logger.Info($"{item.MTCN} - Objective ({item.Objective} is not in the list or missing.");
                }

                output.Add(item);
            }
            return output;
        }

        public void GenerateReport()
        {
            var mtcnRequired = true;
            var output = GetOutput();
            var thOutputs = output.Where(e => e.Customer2.CountryCode == "TH");
            var invalidOutputs = output.Where(e => e.IsValid == false);

            WriteCSV(output.Except(thOutputs).Except(invalidOutputs), OutputFiles.OutputFilePath, mtcnRequired);
            WriteCSV(thOutputs, OutputFiles.THOutputFilePath, mtcnRequired);
            WriteCSV(invalidOutputs, OutputFiles.InvalidOutputFilePath, mtcnRequired);
        }

        public void WriteCSV(IEnumerable<OutputTransaction> outputs, string filePath, bool mtcnRequired)
        {
            _logger.Info($"Writing outputs to {filePath}");
            var builder = new StringBuilder();
            foreach (var t in outputs)
            {
                builder.AppendLine(t.ToString(mtcnRequired));
            }
            CSVHelper.Write(filePath, builder.ToString());
            builder.Clear();
            _logger.Info($"Finished writing outputs to {filePath}");
        }

        private List<Transaction> FilterTransactions()
        {
            var discardTranasctions = new List<Transaction>();
            foreach (var t in Transactions.Where(e => e.BotLicenseNo == OnlineBotLicence))
            {
                var found = OnlineTransactions.FirstOrDefault(e => e.MTCN == t.MTCN);
                if (found != null)
                {
                    t.FundInMethod = found.FundsInMethod;
                    if (found.Status != StatusFileConsts.Approved)
                    {
                        discardTranasctions.Add(t);
                    }
                }
            }

            var filteredTransactions = Transactions.Except(discardTranasctions).ToList();

            filteredTransactions = filteredTransactions.Where(t => !RefundTransactions.Exists(r => IsRefunded(t, r))).ToList();
            return filteredTransactions;
        }
        private void ProcessAmazonList()
        {
            foreach (var amazon in AmazonTransactions)
            {
                var transaction = FilteredTransactions.FirstOrDefault(e => e.MTCN == amazon.MTCN);
                if (transaction != null)
                {
                    transaction.IdNumber = amazon.IdNumber;
                    transaction.Nationality = amazon.Nationality;
                    transaction.IsAmazon = true;
                }
            }
        }

        private bool IsRefunded(Transaction transaction, RefundTransaction refund)
        {
            return refund.MTCN == transaction.MTCN || refund.OldMTCN == transaction.MTCN;
        }


        private string GetIsThaiCode(string nationality)
        {

            if (nationality.Equals("TH", StringComparison.OrdinalIgnoreCase))
            {
                return TransactionConst.IsThai;
            }
            else
            {
                return TransactionConst.NonThai;
            }
        }


    }
}
