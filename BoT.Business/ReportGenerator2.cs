using BoT.Business.Managers;
using BoT.Business.Utilities;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoT.Business
{
    public class ReportGenerator2
    {
        private FileList _fileList;

        public List<Transaction> Transactions { get; set; }
        public List<OnlineTransaction> OnlineTransactions { get; set; }
        public List<RefundTransaction> RefundTransactions { get; set; }
        public List<AmazonFile> AmazonTransactions { get; set; }
        public Dictionary<string, string> ComplianceDict { get; set; }
        public List<Transaction> FilteredTransactions { get; set; }



        public ReportGenerator2(FileList fileList)
        {
            _fileList = fileList;
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
            OnlineTransactions = new StatusFileManager().ReadReport(_fileList.StatusFile);
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

        public Dictionary<string,string> GetComplianceList(string filePath)
        {
            _fileList.ComplianceFile = filePath;
            ComplianceFileManager manager = new ComplianceFileManager(_fileList.DocumentTypeCodeFile);
            ComplianceDict = manager.ReadReport(_fileList.ComplianceFile);
            return ComplianceDict;
        }

        public List<OutputTransaction> GetOutput()
        {
            FilteredTransactions = FilterTransactions();
            ProcessAmazonList();

            BotCodeManager botCodeManager = new BotCodeManager(_fileList.BotCodeFile);
            List<OutputTransaction> output = new List<OutputTransaction>();
            foreach(var t in Transactions)
            {
                var item = new OutputTransaction(t);
                item.IsThaiCode = GetIsThaiCode(item.Nationality);
                item.CustomerType = item.IsAmazon ? TransactionConst.Personal : TransactionConst.NonPersonal;
                if (ComplianceDict.TryGetValue(item.MTCN, out string code))
                {
                    item.DocumentTypeCode = code;
                }
                else
                {
                    item.IsValid = false;
                }
             
                item.ExchangeRate = Math.Round(item.ExchangeRate, 7);
                botCodeManager.MapBotCode(item);
                if (item.IsValid)
                {
                    output.Add(item);
                }
            }
            return output;
        }

        public void GenerateReport()
        {
            var output = GetOutput();
            var builder = new StringBuilder();
            foreach(var t in output)
            {
                builder.AppendLine(t.ToString());
            }
            string filePath = @"C:\central\output.csv";
            CSVHelper.Write(filePath, builder.ToString());

        }

        private List<Transaction> FilterTransactions()
        {
            var discardTranasctions = new List<Transaction>();
            foreach (var t in Transactions.Where(e => e.BotLicenseNo == "MT125610008"))
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

        public string GenerateOutputCSV(List<OutputTransaction> outputs)
        {
            string csv = string.Empty;      
            foreach (var t in outputs)
            {
                csv += t.ToString() + System.Environment.NewLine;
            }
            return csv;
        }
       

    }
}
