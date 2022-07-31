using SharedState.API;
using SharedState.Helpers;
using SharedState.SQLite;
using System;
using System.Threading.Tasks;

namespace SharedState
{
    internal class Program
    {
        internal static string inputText = "CGMforever";

        static void Main(string[] args)
        {
            Console.WriteLine("Create SQLite connection...");

            SQLiteHelper.CreateSQLiteConnection();
            Console.WriteLine("Done!\n");

            Console.WriteLine($"Origin text: {inputText}");

            var encryptedText = CryptoHelper.EncryptString(inputText);
            Console.WriteLine($"Encrypted text: {encryptedText}");

            HTTPCall.EncryptedText = encryptedText;
            MyGreetings.Greetings();

            Console.WriteLine();
            Task.Run(() => SQLiteHelper.DisplayLog()).Wait();

            Console.ReadKey();
        }
    }
}
