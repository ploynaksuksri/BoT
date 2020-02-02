using BoT.Business;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Text;
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

        [Fact]
        public void Test()
        {
            var fileList = new FileList
            {
                MainFile = MainFile,
                StatusFile = StatusFile,
                CountryCodeFile = CountryCodeFile,
                CurrencyCodeFile = CurrencyCodeFile,
                RefundFile = RefundFile
            };

            ReportGenerator generator = new ReportGenerator(fileList);
            var filtered = generator.GetFilteredReports();

            var expected = 4892;

            Assert.Equal(expected, filtered.Count);
        }

    }
}
