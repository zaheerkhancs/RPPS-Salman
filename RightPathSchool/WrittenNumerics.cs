﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightPathSchool
{
   
        public static class WrittenNumerics
        {
            static readonly string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            static readonly string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            static readonly string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            static readonly string[] thousandsGroups = { "", " Thousand", " Million", " Billion" };

            private static string FriendlyInteger(int n, string leftDigits, int thousands)
            {
                if (n == 0)
                    return leftDigits;

                string friendlyInt = leftDigits;
                if (friendlyInt.Length > 0)
                    friendlyInt += " ";

                if (n < 10)
                    friendlyInt += ones[n];
                else if (n < 20)
                    friendlyInt += teens[n - 10];
                else if (n < 100)
                    friendlyInt += FriendlyInteger(n % 10, tens[n / 10 - 2], 0);
                else if (n < 1000)
                    friendlyInt += FriendlyInteger(n % 100, (ones[n / 100] + " Hundred"), 0);
                else
                    friendlyInt += FriendlyInteger(n % 1000, FriendlyInteger(n / 1000, "", thousands + 1), 0);

                return friendlyInt + thousandsGroups[thousands];
            }

            public static string DateToWritten(DateTime date)
            {
                return string.Format("{0} {1} {2}", IntegerToWritten(date.Day), date.ToString("MMMM"), IntegerToWritten(date.Year));
            }

            public static string IntegerToWritten(int n)
            {
                if (n == 0)
                    return "Zero";
                else if (n < 0)
                    return "Negative " + IntegerToWritten(-n);

                return FriendlyInteger(n, "", 0);
            }
        
    }
}
