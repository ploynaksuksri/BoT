using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using BoT.Business.Utilities;
using BoT.Models;

namespace BoT.Business.Managers
{
    public class RefundFileManager : IReportManager<RefundFile>
    {
        public const string MTCNChar = "-";

       
        public List<RefundFile> ReadReport(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception($"File {filePath} doesn't exist.");
            }

            List<RefundFile> refundTransactions = new List<RefundFile>();
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                foreach (IXLRow row in worksheet.RowsUsed().Skip(2))
                {
                    refundTransactions.Add(new RefundFile
                    {
                        MTCN = row.Cell(4).GetValue<string>().RemoveCharacterOnMTCN(MTCNChar),
                        OldMTCN = row.Cell(5).GetValue<string>().RemoveCharacterOnMTCN(MTCNChar),
                        SenderName = row.Cell(6).GetValue<string>()
                    });
                }
            }
            return refundTransactions;
        }






    }
}
