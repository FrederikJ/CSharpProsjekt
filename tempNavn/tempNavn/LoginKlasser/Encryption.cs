using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CSharpProsjekt.LoginKlasser
{
    /// <summary>
    /// Klassen er skrevet i forbindelse med et annet fag(systemutvikling)
    /// Programmering 3 - C# Prosjekt
    /// Krypterer brukerpassord. 
    /// </summary>
    public static class Encryption
    {
        private static readonly string passwordHash = "P@@Sw0rdH@$h1ng";
        private static readonly string saltKey = "$@LT&K3Y";
        private static readonly string viKey = "@1B2c3D4e5F6g7H8";

        /// <summary>
        /// Retunere true eller false om passordene er lik etter han har decryptert passordet som er skrivet inn.
        /// </summary>
        /// <param name="userPass"></param>
        /// <param name="databasePass"></param>
        /// <returns></returns>
        public static bool Decrypt(string userPass, string databasePass)
        {
            string decryption = Encrypt(userPass);
            if (decryption == databasePass)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Får in plain text, for så å salte og hashe passordet forså å retunere stringen
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(passwordHash, Encoding.ASCII.GetBytes(saltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(viKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
    }
}