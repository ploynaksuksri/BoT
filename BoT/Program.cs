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
using System.IO;

namespace BoT
{
    static class Program
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));
        private static string _basePath = Directory.GetCurrentDirectory();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                _logger.Info("Running Form");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var report = GetReportGenerator();
                Application.Run(new Form1(report));
            }
            catch(Exception ex)
            {
                _logger.Error(ex);
            }           
        }

        private static ReportGenerator2 GetReportGenerator()
        {
            var codesFolder = GetSetting("CodeFolder");
            var baseCodesFolder = Path.Combine(_basePath, codesFolder);
            FileList fileList = new FileList
            {
                CountryCodeFile = Path.Combine(baseCodesFolder, GetSetting("CountryCodeFile")),
                CurrencyCodeFile = Path.Combine(baseCodesFolder, GetSetting("CurrencyCodeFile")),
                DocumentTypeCodeFile = Path.Combine(baseCodesFolder, GetSetting("DocumentTypeCodeFile")),
                BotCodeFile = Path.Combine(baseCodesFolder, GetSetting("BotCodeFile"))
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
