using System;
using System.IO;
using Jint;

namespace CallbackToCrypto
{
    public static class DecryptorJS
    {
        /* 
         * take care of multiple statements
         * dont use if(a > b){x+y}; if(a < b){y-x}; -> before executing each statement JInt resets complition value
         * use function
         * use in every step "engine.Execute(...here your script...)"
        */

        // Todo: using the script in a new js file
        private static string jsSource { get; set; }
            = $@"function myGreetings(encryptedText)
                 {{
                     var decryptedtext = decryptString(encryptedText);
                     return ""Greetings "" + decryptedtext + ""!"";
                 }};
                 
                 function decryptString(encryptedText)
                 {{
                     var key = ""8080808080808080"";
                     var _key = CryptoJS.enc.Utf8.parse(key);
		             var _iv = CryptoJS.enc.Utf8.parse(key);
                     var decryptedbytes = CryptoJS.AES.decrypt(encryptedText, _key, {{iv: _iv}});
                     var decryptedtext = decryptedbytes.toString(CryptoJS.enc.Utf8);
                     return decryptedtext ;
                 }};
                                  
                 myGreetings(encryptedText);";

        public static string myGreetings(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException("encryptedText");

            var engine = new Engine();

            var cryptojs = File.ReadAllText(@"crypto-v3.1.2.js");
            engine.Execute(cryptojs);

            engine.SetValue("encryptedText", encryptedText);
            var result = engine.Execute(jsSource).GetCompletionValue();
            var decryptedText = result.ToString();

            if (string.IsNullOrEmpty(decryptedText))
                throw new ArgumentNullException("decryptedText");

            return decryptedText;
        }
    }
}
