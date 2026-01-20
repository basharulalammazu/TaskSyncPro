using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public class PasswordGenerator
    {
        public static string GeneratePassword(int length = 12, bool includeUppercase = true, bool includeLowercase = true, bool includeDigits = true, bool includeSpecialChars = false)
        {
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string special = "!@#$%^&*()-_=+<>?";

            string charSet = "";
            if (includeUppercase) charSet += upper;
            if (includeLowercase) charSet += lower;
            if (includeDigits) charSet += digits;
            if (includeSpecialChars) charSet += special;

            if (string.IsNullOrEmpty(charSet))
                throw new ArgumentException("At least one character set must be selected.");

            var password = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(charSet.Length);
                password.Append(charSet[index]);
            }

            return password.ToString();
        }
    }
}
