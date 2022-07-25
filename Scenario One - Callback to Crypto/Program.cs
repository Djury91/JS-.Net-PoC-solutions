using System;

namespace CallbackToCrypto
{
    internal class Program
    {
        internal static string inputText = "CGMforever";

        static void Main(string[] args)
        {
            var encryptedText = Encryptor.EncryptString(inputText);

            Console.WriteLine($"Origin text: {inputText}");

            Console.WriteLine($"Encrypted text: {encryptedText}");

            //var decryptedText = DecryptorJS.myGreetings(encryptedText);
            MyGreetings.Greetings(encryptedText);

            // For test
            //var decryptedText = Encryptor.DecryptString(encryptedText);
            //Console.WriteLine($"DecryptedText text: {decryptedText}");

            Console.ReadKey();
        }
    }
}
