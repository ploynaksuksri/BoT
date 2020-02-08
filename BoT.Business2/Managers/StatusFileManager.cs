using BoT.Business.Utilities;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoT.Business.Managers
{
    public class StatusFileManager : IReportManager<StatusFile>
    {
        public const char Delimiter = ';';
        public const int NoColumns = 26;

        public List<StatusFile> GetNonApprovedTransaction(string filePath)
        {
            var transactions = ReadReport(filePath);
            return transactions.Where(e => !e.Status.Equals(StatusFileConsts.Approved)).ToList();
        }

        public List<StatusFile> ReadReport(string filePath)
        {
            List<StatusFile> reports = new List<StatusFile>();

            string[] lines = CSVHelper.ReadLine(filePath);

            foreach (var line in lines.Skip(1))
            {
                var items = CSVHelper.ParseLine(line, Delimiter);
                var item = GetItem(items);
                reports.Add(item);
                if (items.Length == NoColumns)
                {
                   
                }
            }
            return reports;
        }

        public StatusFile GetItem(string[] items)
        {
            return new StatusFile
            {
                TransactionDateString = TrimQuotes(items[0]),
                TransactionId = TrimQuotes(items[1]),
                MTCN = TrimQuotes(items[2]),
                Status = TrimQuotes(items[3]),
                FundsInMethod = TrimQuotes(items[23])
            };
        }

        private string TrimQuotes(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                return string.Empty;
            }

            return item.TrimEnd('"').TrimStart('"');
        }

        public void TransformItem(StatusFile item)
        {
            throw new NotImplementedException();
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

        #endregion Disposable
    }
}