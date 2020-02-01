using BoT.Business.Utilities;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoT.Business
{
    public class MainFileManager: IReportManager<Transaction>
    {
        public const char Delimiter = ';';
        public const int NoColumns = 17;

        private CodeConversionManager _codeManager;
        public MainFileManager(CodeConversionManager codeManager)
        {
            _codeManager = codeManager;
        }

        public List<Transaction> ReadReport(string filePath)
        {
            List<Transaction> reports = new List<Transaction>();

            string[] lines = CSVHelper.ReadLine(filePath);

            foreach (var line in lines.Skip(1))
            {
                var items = CSVHelper.ParseLine(line, Delimiter);
                if (items.Length == NoColumns)
                {
                    var item = GetItem(items);
                    TransformItem(item);
                    reports.Add(item);
                }
            }
            return reports;
        }

        public Transaction GetItem(string[] items)
        {
            return new Transaction
            {
                BotLicenseNo = items[0],
                TransactionDateString = items[1],
                TransactionType = items[2],
                Customer1 = new Customer
                {
                    FullName = items[3],
                    Address = items[6]
                },
                IdNumber = items[4],
                Nationality = items[5],
                Customer2 = new Customer
                {
                    FullName = items[7],
                    CountryCode = items[8]
                },
                Objective = items[10],
                CurrencyCode = items[12],
                ExchangeRate = items[13].GetDecimal(),
                ForeingCurrencyPrincipal = items[14].GetDecimal(),
                ThaiBahtPrincipal = items[15].GetDecimal(),
                MTCN = items[16]
            };
        }

        public void TransformItem(Transaction item)
        {
            item.CurrencyCode = _codeManager.GetCurrencyCode(item.CurrencyCode);
            item.Nationality = _codeManager.GetCountryCode(item.Nationality);
            item.Customer2.CountryCode = _codeManager.GetCountryCode(item.Customer2.CountryCode);
        }




        #region Disposable

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            disposed = true;
        }
        #endregion
    }
}
