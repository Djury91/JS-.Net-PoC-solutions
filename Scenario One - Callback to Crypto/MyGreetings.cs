using System;
using System.IO;
using Jint;

namespace CallbackToCrypto
{
    public static class MyGreetings
    {
        public static void Greetings(string encryptedText)
        {
            var engine = new Engine();

            engine.SetValue("log", new Action<string>(Console.WriteLine));
            engine.SetValue("decryptString", new Func<string, string>(Encryptor.DecryptString));
            engine.SetValue("encryptedText", encryptedText);

            var myGreetings = File.ReadAllText(@"myGreetings.js");
            engine.Execute(myGreetings);
        }
    }
}
