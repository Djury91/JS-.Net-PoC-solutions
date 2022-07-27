using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shared.Class
{
    public static class HTTPCalls
    {
        public static string EncryptedText { private get; set; } = "";

        public static string ApiUrl { private get; set; } = "http://localhost:5000/mynodeapp";

        private static readonly HttpClient client = new HttpClient();

        
        public static async Task<string> MyGreetingsPost(string encryptedText)
        {
            EncryptedText = encryptedText;

            var decryptedText = await MyGreetingsPost();

            return decryptedText;
        }

        public static async Task<string> MyGreetingsPost()
        {
            if (string.IsNullOrEmpty(EncryptedText))
                Console.WriteLine($"The EncryptedText can not be empty or null! The value: {EncryptedText}");

            var decryptedText = "";
            var mediaType = "text/plain";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(ApiUrl),
                Content = new StringContent(EncryptedText, Encoding.UTF8, mediaType),

            };


            var retryNum = 0;
            var response = new HttpResponseMessage();
            var success = false;

            do
            {
                try
                {
                    // ConfigureAwait(false)
                    // using in library code
                    // improving performance, avoiding deddlocks
                    // https://devblogs.microsoft.com/dotnet/configureawait-faq/
                    response = await client.SendAsync(request).ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Send request and catch error!!! " + e.Message);
                }

                success = response.IsSuccessStatusCode;

                if (!success)
                {
                    retryNum++;

                    if (retryNum >= 3)
                    {
                        success = true;
                        Console.WriteLine("It could not send the request.");
                    }
                    else
                        Thread.Sleep(300);
                }

            } while (!success);
            

            decryptedText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (string.IsNullOrEmpty(decryptedText))
                Console.WriteLine($"The decryptedText can not be empty or null! The value: {decryptedText}");

            return decryptedText;
        }
    }
}
