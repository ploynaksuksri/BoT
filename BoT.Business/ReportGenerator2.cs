using BoT.Business.Managers;
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
            StatusFileManager manager = new StatusFileManager();
            OnlineTransactions = manager.ReadReport(_fileList.StatusFile);
            return OnlineTransactions;
        }

        public List<RefundTransaction> GetRefundTransactions(string filePath)
        {
            _fileList.RefundFile = filePath;
            RefundFileManager manager = new RefundFileManager();
            RefundTransactions = manager.ReadReport(_fileList.RefundFile);
            return RefundTransactions;
        }

        public List<AmazonFile> GetAmazonTransactions(string filePath)
        {
            _fileList.AmazonFile = filePath;
            AmazonFileManager manager = new AmazonFileManager();
            AmazonTransactions = manager.ReadReport(_fileList.AmazonFile);
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

            List<OutputTransaction> output = new List<OutputTransaction>();
            foreach(var t in Transactions)
            {
                var item = t as OutputTransaction;
                item.IsThaiCode = GetIsThaiCode(item.Nationality);
                item.CustomerType = item.IsAmazon ? TransactionConst.Personal : TransactionConst.NonPersonal;
                item.DocumentTypeCode = ComplianceDict[item.MTCN];
                item.ExchangeRate = Math.Round(item.ExchangeRate, 7);
                output.Add(item);
            }
            return output;
        }

        private List<Transaction> FilterTransactions()
        {
            var discardTranasctions = new List<Transaction>();
            foreach (var t in Transactions)
            {
                var found = OnlineTransactions.FirstOrDefault(e => e.MTCN == t.MTCN);
                if (found != null && found.MTCN == t.MTCN)
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
