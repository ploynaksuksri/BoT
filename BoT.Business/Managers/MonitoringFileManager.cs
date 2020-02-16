using BoT.Business.Utilities;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoT.Business.Managers
{
    public class MonitoringFileManager
    {
        public const char Delimiter = ';';

        public List<MonitoringFile> ReadReport(string filePath)
        {
            List<MonitoringFile> reports = new List<MonitoringFile>();

            string[] lines = CSVHelper.ReadLine(filePath);

            var header = CSVHelper.ParseLine(lines[0], Delimiter);
            var mtcnIndex = GetColumnIndex(header, "MTCN");
            var sendPayIndicatorIndex = GetColumnIndex(header, "SendpayIndicator");
            var sSenOtherReasonIndex = GetColumnIndex(header, "S_SEN_OTHER_REASON");
            var pRecOtherReasonIndex = GetColumnIndex(header, "P_REC_OTHER_REASON");

            foreach (var line in lines.Skip(1))
            {
                var items = CSVHelper.ParseLine(line, Delimiter);
                var monitoringItem = new MonitoringFile
                {
                    MTCN = items[mtcnIndex],
                    SendpayIndicator = items[sendPayIndicatorIndex],
                    SSenOtherReason = items[sSenOtherReasonIndex],
                    PRecOtherReason = items[pRecOtherReasonIndex]
                };

                if (monitoringItem.SendpayIndicator == "Send")
                {
                    monitoringItem.IsGoods = IsGoods(monitoringItem.SSenOtherReason);
                }

                if (monitoringItem.SendpayIndicator == "Pay")
                {
                    monitoringItem.IsGoods = IsGoods(monitoringItem.PRecOtherReason);
                }

                reports.Add(monitoringItem);
            }
            return reports;
        }

        private int GetColumnIndex(string[] header, string columnName)
        {
            return Array.IndexOf(header, columnName);
        }

        private bool IsGoods(string reason)
        {
            return reason.ToLower().Contains("goods");
        }
    }

}