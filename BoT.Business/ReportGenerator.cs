using BoT.Business.Managers;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BoT.Business
{
    public class ReportGenerator
    {
        private TransactionManager _mainFileManager;
        private OnlineFileManager _statusFileManager;
        private RefundFileManager _refundFileManager;
        private AmazonFileManager _amazoneFileManager;
        private ComplianceFileManager _complianceFileManager;
        private FileList _fileList;


        public ReportGenerator(FileList fileList)
        {
            _fileList = fileList;
            var codeManager = new CodeConversionManager(_fileList.CountryCodeFile, _fileList.CurrencyCodeFile);
            _mainFileManager = new TransactionManager(codeManager);
            _statusFileManager = new OnlineFileManager();
            _refundFileManager = new RefundFileManager();
            _amazoneFileManager = new AmazonFileManager();
            _complianceFileManager = new ComplianceFileManager(_fileList.DocumentTypeCodeFile);
        }

        public List<Transaction> GetFilteredReports()
        {
            // Step1 - Read transactions from file
            List<Transaction> transactions = _mainFileManager.ReadReport(_fileList.MainFile).ToList();


            // Step2 - Removed non approved transactions from online transaciton files
            var onlineTransaction = _statusFileManager.ReadReport(_fileList.StatusFile);
            var discardTranasctions = new List<Transaction>();
            foreach(var t in transactions)
            {
                var found = onlineTransaction.FirstOrDefault(e => e.MTCN == t.MTCN);
                if (found != null && found.MTCN == t.MTCN && (found.Status != StatusFileConsts.Approved))
                {
                    discardTranasctions.Add(t);
                }
            }
            transactions = transactions.Except(discardTranasctions).ToList();
        


            // Step3 - Removed refunded transactions
            var refundTransactions = _refundFileManager.ReadReport(_fileList.RefundFile);
           // transactions = transactions.Where(t => !refundTransactions.Exists(r => IsRefunded(t, r))).ToList();
           


            // Step4 - Replace country and currency code when reading transaction from file


            // Step5 - Replace information from Amazon file
            var amazonList = _amazoneFileManager.ReadReport(_fileList.AmazonFile);
            foreach(var amazon in amazonList)
            {
                var transaction = transactions.FirstOrDefault(e => e.MTCN == amazon.MTCN);
                if (transaction != null)
                {
                    transaction.IdNumber = amazon.IdNumber;
                    transaction.Nationality = amazon.Nationality;
                    transaction.IsAmazon = true;
                }
            }

            // Step6 - Update transaction type to BoT format


            // Step7 - Set IsThai or NonThai customer type
            SetForeignCustomerCode(transactions);

            // Step8 - Set Customer type from Amazon list
            SetCustomerTypeCode(transactions, amazonList);

            // Step9 - Get Document type code from compliance file
            GetDocumentTypeCode(transactions, _fileList.ComplianceFile);

            onlineTransaction.Clear();
            discardTranasctions.Clear();
            //refundTransactions.Clear();
            return transactions.ToList();
           
        }

        private bool IsRefunded(Transaction transaction, RefundTransaction refund)
        {
            return refund.MTCN == transaction.MTCN || refund.OldMTCN == transaction.MTCN;
        }

        // Step 7
        private void SetForeignCustomerCode(List<Transaction> transactions)
        {
            //transactions.ForEach(e => e.ForeignCustomerCode = GetThaiCode(e.Nationality));
        }

        // Step 8
        private void SetCustomerTypeCode(List<Transaction> transactions, List<AmazonFile> amazonList)
        {
            //transactions.Where(e => e.IsAmazon).ToList().ForEach(e =>
            //{
            //    e.CustomerType = e.IsAmazon ? TransactionConst.Personal : TransactionConst.NonPersonal;
            //});
        }

        // Step 9 - Compliance file
        private void GetDocumentTypeCode(List<Transaction> transactions, string complianceFilePath)
        {
            //_complianceFileManager.GetDocumentTypeCode(transactions, complianceFilePath);
        }

        private string GetThaiCode(string nationality)
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