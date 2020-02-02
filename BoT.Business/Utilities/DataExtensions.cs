using System;
using System.Collections.Generic;
using System.Text;

namespace BoT.Business.Utilities
{
    public static class DataExtensions
    {
        public static decimal GetDecimal(this string number)
        {
            if (string.IsNullOrEmpty(number))
                return 0m;

            if (Decimal.TryParse(number, out decimal result))
            {
                return result;
            }
            else
            {
                return 0m;
            }
        }

        public static string RemoveCharacterOnMTCN(this string input, string character)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return input.Replace(character, string.Empty);
        }
    }
}
