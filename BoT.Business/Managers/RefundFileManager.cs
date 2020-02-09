using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using BoT.Business.Utilities;
using BoT.Models;
using System.Threading.Tasks;

namespace BoT.Business.Managers
{
    public class RefundFileManager // : IReportManager<RefundTransaction>
    {
        public const string MTCNChar = "-";

       
        public List<RefundTransaction> ReadReport(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception($"File {filePath} doesn't exist.");
            }

            List<RefundTransaction> refundTransactions = new List<RefundTransaction>();
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                foreach (IXLRow row in worksheet.RowsUsed().Skip(2))
                {
                    if (IsEmptyRow(row))
                    {
                        break;
                    }
                    else
                    {
                        refundTransactions.Add(new RefundTransaction
                        {
                            MTCN = row.Cell(4).GetValue<string>().RemoveCharacterOnMTCN(MTCNChar),
                            OldMTCN = row.Cell(5).GetValue<string>().RemoveCharacterOnMTCN(MTCNChar),
                            SenderName = row.Cell(6).GetValue<string>()
                        });
                    }
                }
            }
            return refundTransactions;
        }



        private bool IsEmptyRow(IXLRow row)
        {
            return string.IsNullOrEmpty(row.Cell(1).GetValue<string>());
        }


    }
}
