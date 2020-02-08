using System;
using System.Collections.Generic;
using System.Text;

namespace BoT.Models
{
    public class OutputTransaction : Transaction
    {
        public string DocumentTypeCode2 { get; set; }
        public string DomesticCode { get; set; }
        public string ObjectiveCode { get; set; }
        public string BotLicenceCode { get; set; }
        public string PaymentInstrumentCode { get; set; }
    }
}
