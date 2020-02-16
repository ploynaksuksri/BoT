using BoT.Business;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace BoT
{
    static class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger.Info("Running Form");
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
                BotCodeFile = GetSetting("BotCodeFile")
            };

            ReportGenerator2 reportGenerator = new ReportGenerator2(_logger, fileList);
            return reportGenerator;
        }

        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? "";
        }
    }

}
