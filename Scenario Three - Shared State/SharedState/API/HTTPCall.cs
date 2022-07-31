using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Threading;

namespace SharedState.API
{
    public static class HTTPCall
    {
        public static string EncryptedText { private get; set; } = "";

        public static string ApiUrl { private get; set; } = "http://localhost:1773/hello";


        public static async Task<string> MyGreetingsGetAsync()
        {
            if (string.IsNullOrEmpty(EncryptedText))
                throw new NullReferenceException($"The encryptedText can not be null neither empty, the text: {EncryptedText}");

            using var client = new HttpClient();

            if (client == null)
                throw new ArgumentNullException("HTTP Client error!");

            Console.WriteLine($"HTTP Get - {ApiUrl} ...");

            var myContent = new Content()
            {
                Name = "Gyuri",
                Message = EncryptedText
            };

            var jsonString = JsonConverter.ContentSerializer(myContent);
            // for test
            //jsonString = @"{"""",""""}";
            var mediaType = "application/json";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(ApiUrl),
                Content = new StringContent(jsonString, Encoding.UTF8, mediaType),

            };

            var response = await client.SendAsync(request).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseJSON = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var message = JsonConverter.ContentDeserializer(responseJSON).Message;

                if (string.IsNullOrEmpty(message))
                    throw new NullReferenceException($"The response measge is not correct, the message: {message}");

                return message;
            }
            else
            {
                throw new Exception($"HTTP Client error response! Status code: {response.StatusCode}");
            }
        }
    }
}