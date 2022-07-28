using SharedState.API;
using SharedState.Helpers;
using System;

namespace SharedState
{
    internal class Program
    {
        internal static string inputText = "CGMforever";

        static void Main(string[] args)
        {
            Console.WriteLine($"Origin text: {inputText}");

            var encryptedText = CryptoHelper.EncryptString(inputText);
            Console.WriteLine($"Encrypted text: {encryptedText}");

            HTTPCall.EncryptedText = encryptedText;
            MyGreetings.Greetings();

            Console.ReadKey();
        }
    }
}
