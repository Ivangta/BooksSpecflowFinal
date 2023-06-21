using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BooksSpecflow.Utils
{
    public class Helpers
    {
        private RestClient client;
        private RestRequest request;
        public static string GenerateRandomAlphanumericString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }

        public static string RemoveNonNumericValuesUsingRegex(string source)
        {
            return Regex.Replace(source, "[^\\d.]", string.Empty);
        }
    }
}
