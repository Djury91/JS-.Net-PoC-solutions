﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EnDecryptWithJint
{
    static class Encryptor
    {
        public static string Key { get; private set; } = "8080808080808080";
        public static string IV { get; private set; } = "8080808080808080";

        private static byte[] _key { get; set; } = Encoding.UTF8.GetBytes(Key);
        private static byte[] _iv { get; set; } = Encoding.UTF8.GetBytes(IV);

        public static string EncryptString(string inputText)
        {
            if(string.IsNullOrEmpty(inputText))
                throw new ArgumentNullException("inputText");
        
            byte[] clearBytes = Encoding.Unicode.GetBytes(inputText);
            byte[] encryptedData = Encrypt(clearBytes, _key, _iv);
            return Convert.ToBase64String(encryptedData);
        }

        private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = null;
            try
            {
                Rijndael alg = Rijndael.Create();
                alg.Key = Key;
                alg.IV = IV;
                cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(clearData, 0, clearData.Length);
                cs.FlushFinalBlock();
                return ms.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.Close();
            }
        }

        // For test
        public static string DecryptString(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException("encryptedText");

            byte[] cipherBytes = Convert.FromBase64String(encryptedText);
            byte[] decryptedData = Decrypt(cipherBytes, _key, _iv);
            return Encoding.Unicode.GetString(decryptedData);
        }

        private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = null;
            try
            {
                Rijndael alg = Rijndael.Create();
                alg.Key = Key;
                alg.IV = IV;
                cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.FlushFinalBlock();
                return ms.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.Close();
            }
        }
    }
}
