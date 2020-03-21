using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dev7.EMS.Framework.Extention
{
    /// <summary>
    /// This class have String Extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// combines lastName and firstName into 'lastName, firstName' format.
        /// </summary>
        /// <param name="lastName">The last name.</param>
        /// <param name="firstName">The first name.</param>
        /// <returns></returns>
        public static string LastNameFirstNameFormat(string lastName, string firstName)
        {
            if (string.IsNullOrWhiteSpace(lastName) && string.IsNullOrWhiteSpace(firstName))
                return string.Empty;

            return string.IsNullOrWhiteSpace(lastName)
                ? firstName
                : $"{lastName} {firstName}";
        }

        public static string MinifyHtml(this string str)
        {
            str = Regex.Replace(str, @"\n|\t", " ");
            str = Regex.Replace(str, @">\s+<", "><").Trim();
            str = Regex.Replace(str, @"\s{2,}", " ");
            return str;
        }

        /// <summary>
        /// Firsts the name last name format.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public static string FirstNameLastNameFormat(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName) && string.IsNullOrWhiteSpace(firstName))
                return string.Empty;

            return string.IsNullOrWhiteSpace(lastName)
                ? firstName
                : $"{firstName} {lastName}";
        }

        /// <summary>
        /// Completes the address.
        /// </summary>
        /// <param name="addressLine1">The address line1.</param>
        /// <param name="addressLine2">The address line2.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zipCode">The zip code.</param>
        /// <param name="country">The country.</param>
        /// <returns></returns>
        public static string CompleteAddress(string addressLine1, string addressLine2, string city, string state,
            string zipCode, string country)
        {
            var sb = new StringBuilder();
            if (string.IsNullOrWhiteSpace(addressLine1))
                return $"No default address available.";
            var address = string.IsNullOrWhiteSpace(addressLine2) ? addressLine1 : $"{addressLine1}, {addressLine2}";
            sb.Append($"{address}, {city}, {state} {zipCode}");
            return sb.ToString();
        }

        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        //public static string ToJson(this object value)
        //{
        //    var settings = new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    };

        //    return JsonConvert.SerializeObject(value, Formatting.Indented, settings);
        //}
    }
}
