using BoT.Business;
using BoT.Models;
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
            var report = GetReportGenerator();
            Application.Run(new Form1(report));
        }

        private static ReportGenerator2 GetReportGenerator()
        {
            FileList fileList = new FileList
            {
                CountryCodeFile = GetSetting("CountryCodeFile"),
                CurrencyCodeFile = GetSetting("CurrencyCodeFile"),
                DocumentTypeCodeFile = GetSetting("DocumentTypeCodeFile"),
                PaymentInstrumentCodeFile = GetSetting("PaymentInstrumentCodeFile")
            };

            ReportGenerator2 reportGenerator = new ReportGenerator2(fileList);
            return reportGenerator;
        }

        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }
    }

}
