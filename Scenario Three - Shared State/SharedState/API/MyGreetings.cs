using System;
using Microsoft.ClearScript.V8;
using System.IO;
using SharedState.Helpers;
using System.Threading.Tasks;

namespace SharedState.API
{
    public static class MyGreetings
    {
        private static string myGreetingsJSPath { get; set; } = @"../Scripts/myGreetings.js";


        public static void Greetings()
        {
            using (var engine = new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging))
            {
                var myGreetings = File.ReadAllText(myGreetingsJSPath);
                engine.AddHostObject("myGreetingsPost", new Func<Task<string>>(HTTPCall.MyGreetingsPost));
                engine.AddHostObject("decryptString", new Func<string, string>(CryptoHelper.DecryptString));
                engine.AddHostObject("log", new Action<string>(Console.WriteLine));
                engine.Execute(myGreetings);
            }
        }
    }
}