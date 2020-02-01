using BoT.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BoT.Test
{
    public class CodeTest
    {
        public const string CountryCodeFile = @"C:\central\project\BoT\BoT.Business\Codes\CountryCode.json";
        public const string CurrencyCodeFile = @"C:\central\project\BoT\BoT.Business\Codes\CurrencyCode.json";

        private CodeConversionManager _manager = new CodeConversionManager();

        [Theory]
        [InlineData(CountryCodeFile,5)]
        [InlineData(CurrencyCodeFile, 13)]
        public void ReadCodes(string filePath, int expectedNo)
        {
            var codes = _manager.ReadCodes(filePath);
            Assert.Equal(expectedNo, codes.Count);
        }
    }
}
