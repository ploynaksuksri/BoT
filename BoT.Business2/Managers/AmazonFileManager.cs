using BoT.Models;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using BoT.Business.Utilities;

namespace BoT.Business.Managers
{
    public class AmazonFileManager : IReportManager<AmazonFile>
    {

        public List<AmazonFile> ReadReport(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception($"File {filePath} doesn't exist.");
            }

            List<AmazonFile> amazonList = new List<AmazonFile>();
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                {
                    amazonList.Add(new AmazonFile
                    {
                        MTCN = GetValue(row, 2).RemoveCharacterOnMTCN("-"),
                        IdNumber = GetValue(row, 3),
                        Nationality = GetValue(row, 4)
                    });
                }
            }
            return amazonList;
        }

        private string GetValue(IXLRow row, int index)
        {
            return row.Cell(index).GetValue<string>().Trim();
        }
    }
}
