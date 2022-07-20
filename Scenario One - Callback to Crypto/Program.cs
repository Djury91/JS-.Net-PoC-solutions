using System;

namespace EnDecryptWithJint
{
    internal class Program
    {
        internal static string inputText = "CGMforever";

        static void Main(string[] args)
        {
            var encryptedText = Encryptor.EncryptString(inputText);

            if(string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException("encryptedText");

            Console.WriteLine($"Origin text: {inputText}");

            Console.WriteLine($"Encrypted text: {encryptedText}");

            var decryptedText = DecryptorJS.DecryptString(encryptedText, Encryptor.Key, Encryptor.IV);

            if (string.IsNullOrEmpty(decryptedText))
                throw new ArgumentNullException("decryptedText");

            // For test
            //var decryptedText = Encryptor.DecryptString(encryptedText);
            Console.WriteLine($"DecryptedText text: {decryptedText}");

            Console.ReadKey();
        }
    }
}
