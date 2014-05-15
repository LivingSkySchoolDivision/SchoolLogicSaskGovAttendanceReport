using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSKYSLData
{
    public static class Helpers
    {
        // How long the cache lifetime is when loading objects from the database
        public static readonly TimeSpan CacheLifetime = new TimeSpan(0, 0, 2, 0);

        /// <summary>
        /// Parse an int. Merely an easier to use wrapper for Int.TryParse.
        /// </summary>
        /// <param name="thisString"></param>
        /// <returns></returns>
        public static int ParseInt(string thisString)
        {
            int returnMe = 0;
            if (int.TryParse(thisString, out returnMe))
            {
                return returnMe;
            }

            return 0;
        }

        /// <summary>
        /// Parse a decimal. Merely an easier to use wrapper for Decimal.TryParse.
        /// </summary>
        /// <param name="thisString"></param>
        /// <returns></returns>
        public static decimal ParseDecimal(string thisString)
        {
            decimal returnMe = -1;
            if (decimal.TryParse(thisString, out returnMe))
            {
                return returnMe;
            }
            return 0;
        }

        /// <summary>
        /// Parse a date from a string using DateTime.TryParse. Also adjusts for "MinValue" dates from MS SQL by
        /// adjusting them to c#'s DateTime.MinValue.
        /// </summary>
        /// <param name="thisDate"></param>
        /// <returns></returns>
        public static DateTime ParseDate(string thisDate)
        {
            DateTime returnMe = DateTime.MinValue;

            if (!DateTime.TryParse(thisDate, out returnMe))
            {
                returnMe = DateTime.MinValue;
            }

            // Ccheck if we've managed to parse the SQL's minimum date and convert it
            if (returnMe == new DateTime(1900, 1, 1))
            {
                returnMe = DateTime.MinValue;
            }

            return returnMe;
        }

        /// <summary>
        /// Parse a bool. Merely an easier to use wrapper for Bool.TryParse. Defaults to false.
        /// </summary>
        /// <param name="thisDatabaseValue"></param>
        /// <returns></returns>
        public static bool ParseBool(string thisDatabaseValue)
        {
            if (String.IsNullOrEmpty(thisDatabaseValue))
            {
                return false;
            }
            else
            {
                bool parsedBool = false;
                bool.TryParse(thisDatabaseValue, out parsedBool);
                return parsedBool;
            }
        }

        /// <summary>
        /// Display a debug message in the output console. Centrally located here so that we can disable it easier.
        /// </summary>
        /// <param name="message"></param>
        public static void DebugMsg(string message)
        {
            Debug.Write(message + '\n');
        }

        /// <summary>
        /// Returns the name of the month number specified
        /// </summary>
        /// <param name="monthNum"></param>
        /// <returns></returns>
        public static string GetMonthName(int monthNum)
        {
            string returnMe = "Unknown";
            switch (monthNum)
            {
                case 1:
                    returnMe = "January";
                    break;
                case 2:
                    returnMe = "February";
                    break;
                case 3:
                    returnMe = "March";
                    break;
                case 4:
                    returnMe = "April";
                    break;
                case 5:
                    returnMe = "May";
                    break;
                case 6:
                    returnMe = "June";
                    break;
                case 7:
                    returnMe = "July";
                    break;
                case 8:
                    returnMe = "August";
                    break;
                case 9:
                    returnMe = "September";
                    break;
                case 10:
                    returnMe = "October";
                    break;
                case 11:
                    returnMe = "November";
                    break;
                case 12:
                    returnMe = "December";
                    break;
            }
            return returnMe;
        }

        /// <summary>
        /// Returns the number of a month, given the full name of it. This is used for figuring out which month the user selected from a dropdown list populated by strings.
        /// </summary>
        /// <param name="monthName"></param>
        /// <returns></returns>
        public static int GetMonthNumber(string monthName)
        {
            switch (monthName.ToLower())
            {
                case "january":
                    return 1;
                case "february":
                    return 2;
                case "march":
                    return 3;
                case "april":
                    return 4;
                case "may":
                    return 5;
                case "june":
                    return 6;
                case "july":
                    return 7;
                case "august":
                    return 8;
                case "september":
                    return 9;
                case "october":
                    return 10;
                case "november":
                    return 11;
                case "december":
                    return 12;
            }

            return 0;
        }

        /// <summary>
        /// Returns a list of each DateTime between the given two DateTimes.
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public static IEnumerable<DateTime> GetEachDayBetween(DateTime dateFrom, DateTime dateTo)
        {
            DateTime from = dateFrom;
            DateTime to = dateTo;

            // Dates need to be in chronological order, so reverse them if necesary
            if (dateFrom > dateTo)
            {
                to = dateFrom;
                from = dateTo;
            }

            List<DateTime> returnMe = new List<DateTime>();
            for (DateTime day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
            {
                returnMe.Add(day);
            }
            return returnMe;
        }
    }
}
