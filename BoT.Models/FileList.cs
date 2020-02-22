namespace BoT.Models
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

        #endregion Code file

    }

    public class OutputFiles
    {
        public string OutputDirectory { get; set; }
        public string OutputFilePath { get; set; }
        public string THOutputFilePath { get; set; }
        public string InvalidOutputFilePath { get; set; }

        public const string THPrefix = "th";
        public const string InvalidPrefix = "invalid";

        public void Clear()
        {
            OutputDirectory = string.Empty;
            OutputFilePath = string.Empty;
            THOutputFilePath = string.Empty;
            InvalidOutputFilePath = string.Empty;
        }
    }
}