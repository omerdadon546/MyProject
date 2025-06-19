using System;
using System.Text.RegularExpressions;
using System.Web.Services;

namespace WebServiceCS
{
    public class WebService1 : WebService
    {
        [WebMethod]
        public bool IsStrongPassword(string password)
        {
            // תנאים לסיסמה חזקה:
            // לפחות 8 תווים, אות גדולה, אות קטנה, ספרה ותו מיוחד
            if (string.IsNullOrEmpty(password)) return false;

            bool lengthOK = password.Length >= 8;
            bool hasUpper = Regex.IsMatch(password, @"[A-Z]");
            bool hasLower = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"\d");
            bool hasSpecial = Regex.IsMatch(password, @"[^\w\d\s]");

            return lengthOK && hasUpper && hasLower && hasDigit && hasSpecial;
        }
    }
}
