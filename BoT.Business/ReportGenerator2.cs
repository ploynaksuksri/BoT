using BoT.Business.Managers;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Text;


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
            List<OutputTransaction> output = new List<OutputTransaction>();
            foreach(var t in Transactions)
            {
                var item = t as OutputTransaction;

                output.Add(item);
            }
            return output;
        }


        public string GenerateOutputCSV(List<OutputTransaction> outputs)
        {
            string csv = string.Empty;      
            foreach (var t in outputs)
            {
                csv += GetLine(t) + System.Environment.NewLine;
            }
            return csv;
        }
        public string GetLine(OutputTransaction t)
        {
            return $"{t.BotLicenseNo};{t.TransactionDateString};{t.TransactionType};{t.DomesticCode};{t.Customer1.FullName};" +
                $"{t.IdNumber};{t.Nationality};{t.DocumentTypeCode2};{t.Customer1.Address};{t.CustomerType};{t.Customer2.FullName};" +
                $"{t.Customer2.CountryCode};;{t.ObjectiveCode};{t.BotLicenceCode};{t.PaymentInstrumentCode};" +
                $"{t.CurrencyCode};{t.ExchangeRate};{t.ForeingCurrencyPrincipal};{t.ThaiBahtPrincipal}";
        }


    }
}
