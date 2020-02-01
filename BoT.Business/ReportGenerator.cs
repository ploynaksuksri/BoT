using BoT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BoT.Business
{
    public class ReportGenerator
    {
        private MainFileManager _mainFileManager;
        private StatusFileManager _statusFileManager;
        private FileList _fileList;

        public ReportGenerator(FileList fileList)
        {
            _fileList = fileList;
            var codeManager = new CodeConversionManager(_fileList.CountryCodeFile, _fileList.CurrencyCodeFile);
            _mainFileManager = new MainFileManager(codeManager);
            _statusFileManager = new StatusFileManager();
        }

        public List<MainFile> GetFilteredReports()
        {
            var transactions = _mainFileManager.ReadReport(_fileList.MainFile);
            var approvedTransactions = _statusFileManager.ReadReport(_fileList.StatusFile);
            Debug.Assert(transactions.Count == 30492);
            Debug.Assert(approvedTransactions.Count == 5225);

            transactions = transactions.Where(e => approvedTransactions.Exists(a => a.MTCN == e.MTCN)).ToList();          
            Debug.Assert(transactions.Count == 4892);

            return transactions;
        }
        
    }
}
