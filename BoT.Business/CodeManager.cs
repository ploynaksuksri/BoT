using BoT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BoT.Business
{
    public class CodeManager
    {
        public static List<CodeConvension> CountryCode { get; set; }

        public static List<CodeConvension> CurrencyCode { get; set; }

        public List<CodeConvension> ReadCodes(string filePath)
        {
            var text = File.ReadAllText(filePath);
            var codes = JsonConvert.DeserializeObject<List<CodeConvension>>(text);
            return codes;
        }
    }
}
