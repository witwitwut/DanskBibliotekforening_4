using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repository
{
    class ClassRegEx
    {
        /// <summary>
        /// 12/12/12
        /// 12-12-2012
        /// 12.12.1912
        /// 1/1/12
        /// 01/01/12
        /// 
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public bool IsValidEuDate(string checkValue)
        {
            string pattern = @"^((((0?[1-9])|(([12])([0-9]))|(([3])([0-1])))(-|\/|\.)((0?[13578])|(10)|(12)))|(((0?[1-9])|(([12])([0-9]))|(30))(-|\/|\.)((0?[2469])|(11))))(-|\/|\.)(([0-9][0-9])|(([1-2][0-9])([0-9][0-9])))$";
            return Regex.IsMatch(checkValue, pattern);
        }

        /// <summary>
        /// http://www.google.com
        /// https://www.google.com
        /// ftp://www.google.com
        /// file://www.google.com
        /// www.google.com
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public bool IsValidURL(string checkValue)
        {
            string pattern = @"(?:(?:https?|ftp|file):\/\/|www\.|ftp\.)(?:\([-A-Z0-9+&@#\/%=~_|$?!:,.]*\)|[-A-Z0-9+&@#\/%=~_|$?!:,.])*(?:\([-A-Z0-9+&@#\/%=~_|$?!:,.]*\)|[A-Z0-9+&@#\/%=~_|$])";
            return Regex.IsMatch(checkValue, pattern);
        }

        /// <summary>
        /// hej@hej.hej
        /// hej.hej@hej.hej
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public bool IsValidMail(string checkValue)
        {
            string pattern = @"(?:[a-zæøå0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zæøå0-9!#$%&'*+/=?^_`{|}~-]+)*|(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*)@(?:(?:[a-zæøå0-9](?:[a-zæøå0-9-]*[a-zæøå0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
            return Regex.IsMatch(checkValue, pattern);
        }

        /// <summary>
        /// Ingen mellemrum
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public bool IsValidUserName(string checkValue)
        {
            string pattern = @"^\S[A-Za-z0-9]{3,25}$";
            return Regex.IsMatch(checkValue, pattern);
        }

        /// <summary>
        /// Skal have mindst en uppercase, lowercase og et tal
        /// 8-25 karakterer
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public bool IsValidPassword(string checkValue)
        {
            string pattern = @"(?=^.{8,25}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$";
            return Regex.IsMatch(checkValue, pattern);
        }

        /// <summary>
        /// +4522222222
        /// +45 22 22 22 22
        /// +45 222 222 22
        /// 004522222222
        /// 0045 22 22 22 22
        /// 0045 222 222 22
        /// 22 22 22 22
        /// 22222222
        /// 222 222 22
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public bool IsValidPhoneNumber(string checkValue)
        {
            string pattern = @"^(((\(\+45\))|(0045))\s?)?(([0-9]{8}){1})|(([0-9]{2}\s){4})|(([0-9]{2}\s?){1})(([0-9]{3}\s?){2})$";
            return Regex.IsMatch(checkValue, pattern);
        }

        /// <summary>
        /// 010120-0000
        /// 010120 0000
        /// 0101200000
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public bool IsValidDkSocialSecurityNumber(string checkValue)
        {
            bool isValid;
            string pattern = @"^(?:(?:31(?:0[13578]|1[02])|(?:30|29)(?:0[13-9]|1[0-2])|(?:0[1-9]|1[0-9]|2[0-8])(?:0[1-9]|1[0-2]))[0-9]{2}(\s?|\-?)[0-9]|290200-?[4-9]|2902(?:(?!00)[02468][048]|[13579][26])(\s{0,1}|\-{0,1})[0-3])[0-9]{3}|000000(\s?|\-?)0000$";
            isValid = Regex.IsMatch(checkValue, pattern);
            isValid = CheckCpr(checkValue);
            return isValid;
        }

        /// <summary>
        /// Tjekker om Cpr nummeret er gyldigt.
        /// </summary>
        /// <param name="inCpr"></param>
        /// <returns></returns>
        private bool CheckCpr(string inCpr)
        {
            bool res = false;
            string cprStr = inCpr.Replace(" ", "").Replace("-", "");
            int shortCpr = Convert.ToInt32(cprStr);

            int v1 = 4;
            int v2 = 3;
            int v3 = 2;
            int v4 = 7;
            int v5 = 6;
            int v6 = 5;
            int v7 = 4;
            int v8 = 3;
            int v9 = 2;

            int c1 = ((shortCpr % 1000000000) - (shortCpr % 100000000)) / 100000000;
            int c2 = ((shortCpr % 100000000) - (shortCpr % 10000000)) / 10000000;
            int c3 = ((shortCpr % 10000000) - (shortCpr % 1000000)) / 1000000;
            int c4 = ((shortCpr % 1000000) - (shortCpr % 100000)) / 100000;
            int c5 = ((shortCpr % 100000) - (shortCpr % 10000)) / 10000;
            int c6 = ((shortCpr % 10000) - (shortCpr % 1000)) / 1000;
            int c7 = ((shortCpr % 1000) - (shortCpr % 100)) / 100;
            int c8 = ((shortCpr % 100) - (shortCpr % 10)) / 10;
            int c9 = shortCpr % 10;

            int ct = ((c1 * v1) + (c2 * v2) + (c3 * v3) + (c4 * v4) + (c5 * v5) + (c6 * v6) + (c7 * v7) + (c8 * v8) + (c9 * v9)) % 11;

            if (ct == 0)
            {
                res = true;
            }

            return res;
        }
    }
}
