using COMP123.Model;
using System.Collections.Generic;

namespace COMP123.Utility
{
    public static class Encryption
    {
        private static int encryptCode = 3;
        public static string Encrypt(string plainText)
        {
            string encryptedString = "";
            char[] charArray = plainText.ToCharArray();
            foreach (char c in charArray)
            {
                encryptedString += (char)((int)c + encryptCode);
            }
            return encryptedString;
        }

        public static string Decrypt(string encryptedText)
        {
            string plainText = "";
            char[] charArray = encryptedText.ToCharArray();
            foreach (char c in charArray)
            {
                plainText += (char)((int)c - encryptCode);
            }
            return plainText;
        }

        public static bool Login(string userName, string password)
        {
            List<Staff> staffs = null;
            foreach (Staff staff in staffs)
            {
                if (string.Compare(staff.Name, userName, true) == 0)
                {
                    if (string.Compare(staff.Password, Encrypt(password), true) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
