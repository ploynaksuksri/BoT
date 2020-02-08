using BoT.Business;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace BoT.Test
{
    public class ReportGeneratorTest
    {
        public const string CountryCodeFile = @"C:\central\project\BoT\BoT.Business\Codes\CountryCode.json";
        public const string CurrencyCodeFile = @"C:\central\project\BoT\BoT.Business\Codes\CurrencyCode.json";
        public const string MainFile = @"C:\central\MMTSA39_20191231_MTD.txt";
        public const string StatusFile = @"C:\central\report2.csv";
        public const string RefundFile = @"C:\central\refund.xlsx";
        public const string AmazonFile = @"C:\central\amazon.xlsx";
        public const string ComplianceFile = @"C:\central\Compliance_Dec19.xlsx";
        public const string DocumentTypeCodeFile = @"C:\central\project\BoT\BoT.Business\Codes\DocumentTypeCode.json";

        [Fact]
        public void Test()
        {
            var fileList = new FileList
            {
                MainFile = MainFile,
                StatusFile = StatusFile,
                CountryCodeFile = CountryCodeFile,
                CurrencyCodeFile = CurrencyCodeFile,
                RefundFile = RefundFile,
                AmazonFile = AmazonFile,
                ComplianceFile = ComplianceFile,
                DocumentTypeCodeFile = DocumentTypeCodeFile
            };

            ReportGenerator generator = new ReportGenerator(fileList);
            var filtered = generator.GetFilteredReports();         


            var expected = 26691;

            Assert.Equal(expected, filtered.Count);
        }

    }
}
