using System;
using Microsoft.ClearScript.V8;
using System.IO;
using Microsoft.ClearScript;
using Microsoft.ClearScript.JavaScript;

namespace HTTPCallsViaJSEngine
{
    public static class DecryptorJS
    {
        private static string myGreetingsUrl { get; set; } = "http://localhost:5000/mygreetings";

        private static string jsPath { get; set; } = @"C:\Work\CGM\JS-.Net-PoC-solutions\Scenario Two - HTTP Calls\HTTPCallsViaJSEngine\scripts";
        
        private static string axiosJSPath { get; set; } = @"scripts/axios-v0.27.2.js";
        
        private static string myGreetingsJSPath { get; set; } = @"scripts/HTTPCalls.js";


        public static string MyGreetings(string encryptedtext)
        {
            if (string.IsNullOrEmpty(encryptedtext))
                throw new ArgumentNullException("encryptedText");

            var decryptedText = "default";
            var axios = File.ReadAllText(axiosJSPath);
            var myGreetings = File.ReadAllText(myGreetingsJSPath);

            using (var engine = new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging))
            {
                //engine.Execute(axios);
                engine.DocumentSettings.SearchPath = jsPath;
                engine.DocumentSettings.AccessFlags = DocumentAccessFlags.EnableFileLoading;
                engine.Script.url = new Uri(myGreetingsUrl);
                engine.Script.encryptedtext = encryptedtext;
                //decryptedText = engine.Evaluate(myGreetings).ToString();
                engine.Execute(new DocumentInfo() { Category = ModuleCategory.CommonJS }, myGreetings);
            }

            if (string.IsNullOrEmpty(decryptedText))
                throw new ArgumentNullException("decryptedText");

            return decryptedText;
        }
    }
}
