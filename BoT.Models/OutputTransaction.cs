using System;
using System.Collections.Generic;
using System.Text;

namespace BoT.Models
{
    public class OutputTransaction : Transaction
    {
        public string DocumentTypeCode { get; set; } //Step9 - Document code from compliance file
        public string ObjectiveCode { get; set; }
        public string BotOfflineCode { get; set; } // Step12 - 21 for offline and 22 for online
        public string PaymentInstrumentCode { get; set; }
        public string CustomerType { get; set; }  // Step8 - 176068 นิติบุคคล
        public string IsThaiCode { get; set; } = string.Empty; // Step7 - Thai or non Thai

        public bool IsValid { get; set; } = true;

        public override string ToString()
        {
            return $"{BotLicenseNo};{TransactionDateString};{TransactionType};{IsThaiCode};{Customer1.FullName};" +
                $"{IdNumber};{Nationality};{DocumentTypeCode};{Customer1.Address};{CustomerType};{Customer2.FullName};" +
                $"{Customer2.CountryCode};;{ObjectiveCode};{BotOfflineCode};{PaymentInstrumentCode};" +
                $"{CurrencyCode};{ExchangeRate};{ForeingCurrencyPrincipal};{ThaiBahtPrincipal}";
        }

        public OutputTransaction(Transaction t)
        {
            MTCN = t.MTCN;
            BotLicenseNo = t.BotLicenseNo;
            TransactionDateString = t.TransactionDateString;
            TransactionType = t.TransactionType;
            IdNumber = t.IdNumber;
            Nationality = t.Nationality;
            Customer1 = t.Customer1;
            Customer2 = t.Customer2;
            Objective = t.Objective;
            CurrencyCode = t.CurrencyCode;
            ExchangeRate = t.ExchangeRate;
            ForeingCurrencyPrincipal = t.ForeingCurrencyPrincipal;
            ThaiBahtPrincipal = t.ThaiBahtPrincipal;
            FundInMethod = t.FundInMethod;
            IsAmazon = t.IsAmazon;
        }
    }

}
