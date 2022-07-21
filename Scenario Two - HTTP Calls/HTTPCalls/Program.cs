using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTTPCalls
{
    internal class Program
    {
        internal static string inputText = "CGMforever";

        static async Task Main(string[] args)
        {
            Console.WriteLine($"Origin text: {inputText}");

            var encryptedText = Encryptor.EncryptString(inputText);
            Console.WriteLine($"Encrypted text: {encryptedText}");

            var decryptedText = await DecryptorNodeServer.MyGreetings(encryptedText);
            Console.WriteLine($"DecryptedText text: {decryptedText}");

            Console.ReadKey();
        }
    }
}
