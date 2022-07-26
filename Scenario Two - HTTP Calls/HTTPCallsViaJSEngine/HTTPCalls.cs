using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCallsViaJSEngine
{
    public static class HTTPCalls
    {
        public static string EncryptedText { private get; set; } = "";

        public static string ApiUrl { private get; set; } = "http://localhost:5000/mynodeapp";

        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> MyGreetingsPost()
        {
            if (string.IsNullOrEmpty(EncryptedText))
                throw new ArgumentNullException("encryptedText");

            var decryptedText = "";
            var mediaType = "text/plain";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(ApiUrl),
                Content = new StringContent(EncryptedText, Encoding.UTF8, mediaType),

            };

            var response = await client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            decryptedText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (string.IsNullOrEmpty(decryptedText))
                throw new ArgumentNullException("decryptedText");

            return decryptedText;
        }
    }
}
