using System;

namespace BoT.Models
{
    public class Transaction
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



        public string ThaiCode { get; set; }
        public bool IsAmazon { get; set; }
        public string CustomerType { get; set; }
        public string ForeignCustomerCode { get; set; } = string.Empty;
    }

    public class Customer
    {
        public string Address { get; set; }
        public string FullName { get; set; }
        public string CountryCode { get; set; }
    }

    public class TransactionConst
    {
        public const string IsThai = "176001";
        public const string NonThai = "170067";

        public const string Personal = "176068";
        public const string NonPersonal = "176067";
    }
}
