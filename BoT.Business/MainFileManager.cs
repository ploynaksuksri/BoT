﻿using BoT.Business.Utilities;
using BoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoT.Business
{
    public class MainFileManager
    {
        public const char Delimiter = ';';
        public const int NoColumns = 17;

        public List<MainFile> ReadReport(string filePath)
        {
            List<MainFile> reports = new List<MainFile>();

            string[] lines = CSVHelper.ReadLine(filePath);
     
            foreach(var line in lines.Skip(1))
            {
                var items = CSVHelper.ParseLine(line, Delimiter);
                if (items.Length == NoColumns)
                {
                    reports.Add(GetItem(items));
                }               
            }
            return reports;
        }

        public MainFile GetItem(string[] items)
        {

            return new MainFile
            {
                BotLicenseNo = items[0],
                TransactionDateString = items[1],
                TransactionType = items[2],
                Customer1 = new Customer
                {
                    FullName = items[3],
                    Address = items[6]
                },
                IdNumber = items[4],
                Nationality = items[5],
                Customer2 = new Customer
                {
                    FullName = items[7],
                    CountryCode = items[8]
                },
                Objective = items[10],
                CurrencyCode = items[12],
                ExchangeRate = items[13].GetDecimal(),
                ForeingCurrencyPrincipal = items[14].GetDecimal(),
                ThaiBahtPrincipal = items[15].GetDecimal(),
                MTCN = items[16]
            };
        }

    }
}
