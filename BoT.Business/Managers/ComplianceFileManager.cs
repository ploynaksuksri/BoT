using BoT.Business.Utilities;
using BoT.Models;
using ClosedXML.Excel;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoT.Business.Managers
{
    public class ComplianceFileManager : BaseCodeManager<DocumentCode>
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ComplianceFileManager));

        public static Dictionary<string, string> _codes = new Dictionary<string, string>();

        public ComplianceFileManager(string documentTypeFilePath)
        {
            _codes = ReadCodesDict(documentTypeFilePath);
        }

        public Dictionary<string, ComplianceFile> ReadReport(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception($"File {filePath} doesn't exist.");
            }

            Dictionary<string, ComplianceFile> complianceList = new Dictionary<string, ComplianceFile>();
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                foreach (IXLRow row in worksheet.RowsUsed().Skip(1))
                {
                    var MTCN = GetValue(row, 1).RemoveCharacterOnMTCN("-");
                    if (!complianceList.ContainsKey(MTCN))
                    {
                        var documentType = GetValue(row, 40);
                        complianceList.Add(MTCN, new ComplianceFile
                        {
                            MTCN = MTCN,
                            DocumentType = documentType,
                            DocumentTypeCode = GetDocumentTypeCode(MTCN, documentType)
                        }); ;
                    }
                }
            }
            return complianceList;
        }

        private string GetValue(IXLRow row, int index)
        {
            return row.Cell(index).GetValue<string>().Trim();
        }

        private string GetDocumentTypeCode(string mtcn, string documentType)
        {
            if (_codes.TryGetValue(documentType, out string code))
            {
                return code;
            }
            else
            {
                var errorMessage = $"Cannot find document type code for MTCN {mtcn}, document type {documentType}";
                _logger.Error(errorMessage);
                throw new Exception(errorMessage);
            }
        }

        public Dictionary<string, string> ReadCodesDict(string filePath)
        {
            var codes = ReadCodes(filePath);

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