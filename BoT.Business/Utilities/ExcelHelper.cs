using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using ClosedXML.Excel;

namespace BoT.Business.Utilities
{
    public class ExcelHelper
    {
        public void ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception($"File {filePath} doesn't exist.");
            }

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheets.FirstOrDefault();
                foreach(IXLRow row in worksheet.RowsUsed())
                {

                }
            }
        }
    }
}
