using System;
using System.Collections.Generic;
using System.Text;

namespace BoT.Models
{
    public class StatusFile
    {
        public string TransactionDateString { get; set; } //1
        public string TransactionId { get; set; } //2
        public string MTCN { get; set; } //3
        public string Status { get; set; } //4
        public string FundsInMethod { get; set; } //24
    }

    public class StatusFileConsts
    {
        public static string Approved = "APPROVED";
        public static string CreditDebitCard = "Credit/Debit card";
    }
}
