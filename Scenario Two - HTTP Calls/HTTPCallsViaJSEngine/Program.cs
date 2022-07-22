using Shared.Class;
using System;

namespace HTTPCallsViaJSEngine
{
    internal class Program
    {
        internal static string inputText = "CGMforever";

        static void Main(string[] args)
        {
            Console.WriteLine($"Origin text: {inputText}");

            var encryptedText = Encryptor.EncryptString(inputText);
            Console.WriteLine($"Encrypted text: {encryptedText}");

            var decryptedText = DecryptorJS.MyGreetings(encryptedText);
            Console.WriteLine($"DecryptedText text: {decryptedText}");

            Console.ReadKey();
        }
    }
}
