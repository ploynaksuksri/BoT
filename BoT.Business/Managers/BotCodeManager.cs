﻿using BoT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using log4net;

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
                    if (t.FundInMethod == "Direct Debit")
                    {
                        t.PaymentInstrumentCode = "0753600003";
                    }

                    if (t.FundInMethod == "Credit/Debit Card")
                    {
                        t.PaymentInstrumentCode = "0753600004";
                    }
                }
            }
            else
            {
                _logger.Info($"{t.MTCN} can't map BotLicenceNo {t.BotLicenseNo}");
                t.IsValid = false;
            }
           
        }
    }
}