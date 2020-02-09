using System;
using System.Collections.Generic;
using System.Text;

namespace BoT.Models
{
    public class OutputTransaction : Transaction
    {
        public string DocumentTypeCode { get; set; } //Step9 - Document code from compliance file
        public string ObjectiveCode { get; set; }
        public string BotLicenceCode { get; set; }
        public string PaymentInstrumentCode { get; set; }
        public string CustomerType { get; set; }  // Step8 - 176068 นิติบุคคล
        public string IsThaiCode { get; set; } = string.Empty; // Step7 - Thai or non Thai
    
    }
}
