using BoT.Business.Managers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var countryCode = GetSetting("CountryCodeFile");
            var currencyCode = GetSetting("CurrencyCodeFile");
            CodeConversionManager codeManager = new CodeConversionManager(countryCode, currencyCode);
            Application.Run(new Form1(codeManager));
        }

        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }
    }
}
