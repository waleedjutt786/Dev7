using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev7.EMS.Domain.Extensions
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static string To_ddMMyyyy_String(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        public static DateTime To_ddMMyyyy(this string date, char splitterChar)
        {
            string str = string.Empty;
            DateTime retVal = AppConstants.DEFAULT_DATE;
            string[] dateComponents = date.Split(splitterChar);
            if (dateComponents.Length == 3)
            {
                int day = Convert.ToInt32(dateComponents[0]);
                int month = Convert.ToInt32(dateComponents[1]);
                int year = Convert.ToInt32(dateComponents[2]);
                retVal = new DateTime(year, month, day);
            }

            //if(string.)
            //return date.ToString("dd/MM/yyyy");
            //return 
            return retVal;
        }
    }
}
