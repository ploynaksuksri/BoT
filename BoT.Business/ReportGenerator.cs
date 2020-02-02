using BoT.Business.Managers;
using BoT.Models;
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
        private FileList _fileList;

        public ReportGenerator(FileList fileList)
        {
            _fileList = fileList;
            var codeManager = new CodeConversionManager(_fileList.CountryCodeFile, _fileList.CurrencyCodeFile);
            _mainFileManager = new TransactionManager(codeManager);
            _statusFileManager = new StatusFileManager();
            _refundFileManager = new RefundFileManager();
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


            return transactions.ToList();
        }

        private bool IsRefunded(Transaction transaction, RefundFile refund)
        {
            return refund.MTCN == transaction.MTCN || refund.OldMTCN == transaction.MTCN;
        }
    }
}