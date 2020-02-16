﻿namespace BoT.Models
{
    public class FileList
    {
        public string MainFile { get; set; }
        public string StatusFile { get; set; }
        public string RefundFile { get; set; }
        public string AmazonFile { get; set; }
        public string ComplianceFile { get; set; }
        public string MonitoringFile { get; set; }

        #region Code file
        public string DocumentTypeCodeFile { get; set; }
        public string CountryCodeFile { get; set; }
        public string CurrencyCodeFile { get; set; }
        public string BotCodeFile { get; set; }
        #endregion
    }
}