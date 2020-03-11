using BoT.Models;
using log4net;
using System.Collections.Generic;

namespace BoT.Business.Managers
{
    public class BotCodeManager : BaseCodeManager<BotCode>
    {
        private ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Dictionary<string, BotCode> CodeDict { get; set; } = new Dictionary<string, BotCode>();

        public BotCodeManager(string codeFilePath)
        {
            GetCodes(codeFilePath);
        }

        public void GetCodes(string filePath)
        {
            var codes = ReadCodes(filePath);
            foreach(var c in codes)
            {
                if (!CodeDict.ContainsKey(c.BotLicence))
                {
                    CodeDict.Add(c.BotLicence, c);
                }               
            }
        }

        public void MapBotCode(List<OutputTransaction> transactions)
        {
            foreach(var t in transactions)
            {
                MapBotCode(t);
            }
        }

        public void MapBotCode(OutputTransaction t)
        {
            if (CodeDict.TryGetValue(t.BotLicenseNo, out BotCode code))
            {
                t.BotOfflineCode = code.OfflineCode;
                t.PaymentInstrumentCode = code.PaymentInstrumentCode;

                if (t.BotLicenseNo == "MT125610008")
                {
                    if (t.FundInMethod?.ToLower() == "Direct Debit".ToLower())
                    {
                        t.PaymentInstrumentCode = "0753600003";
                    }
               
                    if (t.FundInMethod?.ToLower() == "Credit/Debit card".ToLower())
                    {
                        t.PaymentInstrumentCode = "0753600004";
                    }
                }
            }
            else
            {
                _logger.Info($"{t.MTCN} cannot map BotLicenceNo {t.BotLicenseNo}");
                t.IsValid = false;
            }
           
        }
    }
}
