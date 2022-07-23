using System;
using Microsoft.ClearScript.V8;
using System.IO;

namespace HTTPCallsViaJSEngine
{
    public static class DecryptorJS
    {
        private static string myGreetingsUrl { get; set; } = "http://localhost:5000/mygreetings";

        public static string MyGreetings(string encryptedtext)
        {
            if (string.IsNullOrEmpty(encryptedtext))
                throw new ArgumentNullException("encryptedText");

            var decryptedText = "default";
            var axios = File.ReadAllText(@"scripts/axios-v0.27.2.js");
            var myGreetings = File.ReadAllText(@"scripts/HTTPCalls.js");

            using (var engine = new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging))
            {
                engine.Execute(axios);
                engine.Script.url = new Uri(myGreetingsUrl);
                engine.Script.encryptedtext = encryptedtext;
                decryptedText = engine.Evaluate(myGreetings).ToString();
            }

            if (string.IsNullOrEmpty(decryptedText))
                throw new ArgumentNullException("decryptedText");

            return decryptedText;
        }
    }
}
