using Jint;
using System;
using System.IO;

namespace HTTPCallsViaJSEngine
{
    public static class DecryptorJS
    {
        private static string myGreetingsUrl { get; set; } = "http://localhost:5000/mygreetings";

        public static string MyGreetings(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException("encryptedText");

            var decryptedText = "";
            var myGreetings = File.ReadAllText(@"scripts/HTTPCalls.js");

            var engine = new Engine();
            engine.SetValue("url", myGreetingsUrl);
            engine.SetValue("encryptedText", encryptedText);
            var result = engine.Execute(myGreetings).GetCompletionValue();
            decryptedText = result.ToString();

            if (string.IsNullOrEmpty(decryptedText))
                throw new ArgumentNullException("decryptedText");

            return decryptedText;
        }
    }
}
