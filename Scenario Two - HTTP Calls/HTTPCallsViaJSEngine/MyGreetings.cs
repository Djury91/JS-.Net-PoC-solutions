using System;
using Microsoft.ClearScript.V8;
using System.IO;
using System.Threading.Tasks;
using Shared.Class;

namespace HTTPCallsViaJSEngine
{
    public static class MyGreetings
    {
        private static string myGreetingsJSPath { get; set; } = @"scripts/myGreetings.js";


        public static void Greetings()
        {
            using (var engine = new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging))
            {
                var myGreetings = File.ReadAllText(myGreetingsJSPath);
                engine.AddHostObject("myGreetingsPost", new Func<Task<string>>(HTTPCalls.MyGreetingsPost));
                engine.AddHostObject("decryptString", new Func<string, string>(Encryptor.DecryptString));
                engine.AddHostObject("log", new Action<string>(Console.WriteLine));
                engine.Execute(myGreetings);
            }
        }
    }
}
