using BoT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BoT.Business
{
    public class CodeConversionManager : IDisposable
    {
        public static List<CodeConversion> CountryCodes { get; set; } = new List<CodeConversion>();

        public static List<CodeConversion> CurrencyCodes { get; set; } = new List<CodeConversion>();

        public CodeConversionManager()
        {
        }

        public CodeConversionManager(string countryCodePath, string currencyCodePath)
        {
            CountryCodes = ReadCodes(countryCodePath);
            CurrencyCodes = ReadCodes(currencyCodePath);
        }

        public string GetCountryCode(string code)
        {
            return GetCode(CountryCodes, code);
        }

        public string GetCurrencyCode(string code)
        {
            return GetCode(CurrencyCodes, code);
        }

        private string GetCode(List<CodeConversion> codes, string oldCode)
        {
            var newCode = codes.Where(e => e.From.Equals(oldCode, StringComparison.OrdinalIgnoreCase)).Select(e => e.To).FirstOrDefault();
            return string.IsNullOrEmpty(newCode) ? oldCode : newCode;
        }

        public List<CodeConversion> ReadCodes(string filePath)
        {
            var text = File.ReadAllText(filePath);
            var codes = JsonConvert.DeserializeObject<List<CodeConversion>>(text);
            return codes;
        }



        #region Disposable
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                CountryCodes.Clear();
                CurrencyCodes.Clear();
            }

            disposed = true;
        }
        #endregion
    }
}