using BoT.Business;
using BoT.Business.Managers;
using BoT.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace BoT.Test
{
    public class FileTest
    {
        [Fact]
        public void GetMainFile()
        {
            string filePath = @"C:\central\MMTSA39_20191231_MTD.txt";
            var manager = new TransactionManager(new CodeConversionManager());

            List<Transaction> reports = manager.ReadReport(filePath);

            var expected = 30492;

            Assert.Equal(expected, reports.Count);
        }

        [Fact]
        public void GetStatusFile()
        {
            string filePath = @"C:\central\report2.csv";
            var manager = new StatusFileManager();

            List<StatusFile> statusTransactions = manager.ReadReport(filePath);

            var expected = 11343;

            Assert.Equal(expected, statusTransactions.Count);
        }

        [Fact]
        public void GetApprovedOnly()
        {
            string filePath = @"C:\central\report2.csv";
            var manager = new StatusFileManager();

            List<StatusFile> statusTransactions = manager.GetApprovedTransactions(filePath);

            var expected = 5225;
            
            Assert.Equal(expected, statusTransactions.Count);
        }

        [Fact]
        public void GetRefundList()
        {
            string filePath = @"C:\central\refund.xlsx";
            var manager = new RefundFileManager();

            List<RefundFile> refundTransactions = manager.ReadReport(filePath);

            var expected = 1044135;

            Assert.Equal(expected, refundTransactions.Count);
        }


        [Fact]
        public void GetAmazonFile()
        {
            string filePath = @"C:\central\amazon.xlsx";
            var manager = new AmazonFileManager();

            List<AmazonFile> refundTransactions = manager.ReadReport(filePath);

            var expected = 13;

            Assert.Equal(expected, refundTransactions.Count);
        }

        [Fact]
        public void GetComplianceFile()
        {
            var manager = new ComplianceFileManager(@"C:\central\project\BoT\BoT.Business\Codes\DocumentTypeCode.json");
            string filePath = @"C:\central\Compliance_Dec19.xlsx";
            List<ComplianceFile> complianceFiles = manager.ReadReport(filePath);

            var expected = 27169;

            Assert.Equal(expected, complianceFiles.Count);
        }

        [Fact]
        public void GetDocumentCodeFile()
        {
            string filePath = @"C:\central\project\BoT\BoT.Business\Codes\DocumentTypeCode.json";
            var manager = new ComplianceFileManager();

            Dictionary<string, string> codes = manager.ReadCodes(filePath);

            var expected = 8;

            Assert.Equal(expected, codes.Count);
        }
    }
}
