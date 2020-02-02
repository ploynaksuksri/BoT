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
        private StatusFileManager _statusFileManager;
        private RefundFileManager _refundFileManager;
        private AmazonFileManager _amazoneFileManager;
        private FileList _fileList;


        public ReportGenerator(FileList fileList)
        {
            _fileList = fileList;
            var codeManager = new CodeConversionManager(_fileList.CountryCodeFile, _fileList.CurrencyCodeFile);
            _mainFileManager = new TransactionManager(codeManager);
            _statusFileManager = new StatusFileManager();
            _refundFileManager = new RefundFileManager();
            _amazoneFileManager = new AmazonFileManager();
        }

        public List<Transaction> GetFilteredReports()
        {
            List<Transaction> transactions = _mainFileManager.ReadReport(_fileList.MainFile).ToList();
            Debug.Assert(transactions.Count == 30492);


            var approvedTransactions = _statusFileManager.GetApprovedTransactions(_fileList.StatusFile);
            transactions = transactions.Where(e => approvedTransactions.Exists(a => a.MTCN == e.MTCN)).ToList();

            Debug.Assert(approvedTransactions.Count == 5225);
            approvedTransactions.Clear();


            //var refundTransactions = _refundFileManager.ReadReport(_fileList.RefundFile);
            //transactions = transactions.Where(t => !refundTransactions.Exists(r => IsRefunded(t,r))).ToList();

            //refundTransactions.Clear();

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

            return transactions.ToList();
        }

        private bool IsRefunded(Transaction transaction, RefundFile refund)
        {
            return refund.MTCN == transaction.MTCN || refund.OldMTCN == transaction.MTCN;
        }

        // Step 7
        private void SetNationalityCode(List<Transaction> transactions)
        {
            transactions.ForEach(e => GetThaiCode(e.Nationality));
        }

        // Step 8
        private void SetCustomerTypeCode(List<Transaction> transactions, List<AmazonFile> amazonList)
        {
            transactions.Where(e => e.IsAmazon).ToList().ForEach(e =>
            {
                e.CustomerType = e.IsAmazon ? TransactionConst.Personal : TransactionConst.NonPersonal;
            });
        }

        // Step 9
        private void Step9()
        {

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