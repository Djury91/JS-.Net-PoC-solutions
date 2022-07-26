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

            HTTPCalls.EncryptedText = encryptedText;
            MyGreetings.Greetings();

            Console.ReadKey();
        }
    }
}
