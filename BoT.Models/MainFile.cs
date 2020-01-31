using System;

namespace BoT.Models
{
    public class MainFile
    {
        public string MTCN { get; set; }
        public string BotLicenseNo { get; set; }
        public string TransactionDateString { get; set; }
        public string TransactionType { get; set; }
        public string IdNumber { get; set; }
        public string Nationality { get; set; }
        public Customer Customer1 { get; set; }
        public Customer Customer2 { get; set; }
        public string Objective { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal ForeingCurrencyPrincipal { get; set; }
        public decimal ThaiBahtPrincipal { get; set; }      
    }

    public class Customer
    {
        public string Address { get; set; }
        public string FullName { get; set; }
        public string CountryCode { get; set; }
    }
}
