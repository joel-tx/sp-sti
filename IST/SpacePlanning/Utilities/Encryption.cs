using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace STP.SpacePlanning.Utilities
{
    public class Encryption
    {
        /// <summary>
        /// Encrypts a password using SHA256 Algorithm.
        /// the encrypted data cannot be dencrypt 
        /// </summary>
        /// <param name="password">value to Encrypt</param>
        /// <returns>encrypted data in SHA256</returns>
        public static string Encrypt(string password)
        {
            SHA256 algorithmSHA256 = SHA256Managed.Create();            
            byte[] hash = algorithmSHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return GetStringFromHash(hash);
        }

        /// <summary>
        /// Converts the bytes in to string
        /// </summary>
        /// <param name="hash">source hash bytes</param>
        /// <returns>hash code in string format</returns>
        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder encryptedHash = new StringBuilder();
            for (int indexHash = 0; indexHash < hash.Length; indexHash++)
            {
                encryptedHash.Append(hash[indexHash].ToString("X2"));
            }
            return encryptedHash.ToString();
        }
    }
}
