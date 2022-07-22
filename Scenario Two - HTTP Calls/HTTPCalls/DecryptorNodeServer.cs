using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCalls
{
    public static class DecryptorNodeServer
    {
        private static readonly HttpClient client = new HttpClient();

        private static string myGreetingsUrl { get; set; } = "http://localhost:5000/mygreetings";

        public static async Task<string> MyGreetings(string encryptedText)
        {
            if (string.IsNullOrEmpty(encryptedText))
                throw new ArgumentNullException("encryptedText");

            var decryptedText = "";
            var mediaType = "text/plain";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(myGreetingsUrl),
                Content = new StringContent(encryptedText, Encoding.UTF8, mediaType),

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
