using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    internal class ValidationHelper
    {
        public static bool IsValidHebrewName(string name)
        {
            // בדיקת תקינות שם בעברית
            return Regex.IsMatch(name, "^[א-ת]+$");
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // בדיקת תקינות מספר טלפון - 10 ספרות
            return Regex.IsMatch(phoneNumber, "^[0-9]{10}$");
        }

        public static bool IsValidEmail(string email)
        {
            // בדיקת תקינות מייל על פי ביטוי רגולרי פשוט
            return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        }

        public static bool IsValidPassword(string password)
        {
            // בדיקת תקינות סיסמה - לפחות 6 תווים, לפחות אות אחת ולפחות סיפרה אחת
            return password.Length >= 6 && Regex.IsMatch(password, "[a-zA-Z]") && Regex.IsMatch(password, "[0-9]");
        }
    }
}

