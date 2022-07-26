using Shared.Class;
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

            Shared.Class.HTTPCalls.ApiUrl = "http://localhost:5000/mygreetings";
            var decryptedText = await Shared.Class.HTTPCalls.MyGreetingsPost(encryptedText);
            Console.WriteLine($"DecryptedText text: {decryptedText}");

            Console.ReadKey();
        }
    }
}
