using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BoT.Models;
using ClosedXML.Excel;
using System.Linq;
using BoT.Business.Utilities;

namespace BoT.Business.Managers
{
    public class ComplianceFileManager : IReportManager<ComplianceFile>
    {
        public static Dictionary<string, string> _codes = new Dictionary<string, string>();

        public ComplianceFileManager()
        {

        }

        public ComplianceFileManager(string documentTypeFilePath)
        {
            _codes = ReadCodes(documentTypeFilePath);
        }


        public List<ComplianceFile> ReadReport(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception($"File {filePath} doesn't exist.");
            }

            List<ComplianceFile> complianceList = new List<ComplianceFile>();
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                {
                    var item = new ComplianceFile
                    {
                        MTCN = GetValue(row, 1).RemoveCharacterOnMTCN("-"),
                        DocumentType = GetValue(row, 40)
                    };
                    item.ComplianceCode = _codes[item.DocumentType];
                    complianceList.Add(item);
                }
            }
            return complianceList;
        }


    

        private string GetValue(IXLRow row, int index)
        {
            return row.Cell(index).GetValue<string>().Trim();
        }


        public Dictionary<string, string> ReadCodes(string filePath)
        {
            var text = File.ReadAllText(filePath);            
            var codes = JsonConvert.DeserializeObject<List<DocumentCode>>(text);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var code in codes)
            {
                dict.Add(code.DocumentType, code.Code);
            }
            codes.Clear();
            return dict;
        }



    }

    public class DocumentCode
    {
        public string DocumentType { get; set; }
        public string Code { get; set; }
    }
}
