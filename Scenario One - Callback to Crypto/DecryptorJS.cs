using System;
using System.IO;
using Jint;

namespace EnDecryptWithJint
{
    public static class DecryptorJS
    {
        /* 
         * take care of multiple statements
         * dont use if(a > b){x+y}; if(a < b){y-x}; -> before executing each statement JInt resets complition value
         * use function
         * use in every step "engine.Execute(...here your script...)"
        */
        private static string jsSource { get; set; }
            = $@"function decryptString(encryptedText)
                 {{
                     var gKey = CryptoJS.enc.Utf8.parse(key);
		             var gIV = CryptoJS.enc.Utf8.parse(iv);
                     var decryptedbytes = CryptoJS.AES.decrypt(encryptedText, gKey, {{iv: gIV}});
                     var decryptedtext = decryptedbytes.toString(CryptoJS.enc.Utf8);
                     return ""Greetings "" + decryptedtext + ""!"";
                 }};
                                  
                 decryptString(encryptedText);";

        public static string DecryptString(string encryptedText, string key, string iv)
        {
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException("encryptedText");

            var engine = new Engine();

            var cryptojs = File.ReadAllText(@"crypto-v3.1.2.js");
            engine.Execute(cryptojs);

            engine.SetValue("encryptedText", encryptedText);
            engine.SetValue("key",  key);
            engine.SetValue("iv", iv);
            var decryptedText = engine.Execute(jsSource).GetCompletionValue();

            return decryptedText.ToString();
        }
    }
}
