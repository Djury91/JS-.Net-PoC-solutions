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
                Console.WriteLine($"The encryptedText can not be null neither empty, the text: {EncryptedText}");

            try
            {
                using var client = new HttpClient();

                if (client == null)
                {
                    Console.WriteLine("HTTP Client instance error!");
                    return null;
                }

                var myContent = new Content()
                {
                    Name = "Gyuri",
                    Message = EncryptedText
                };

                var jsonString = JsonConverter.ContentSerializer(myContent);
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
                        Console.WriteLine($"The response measge is not correct, the message: {message}");

                    return message;
                }
                else
                {
                   Console.WriteLine($"HTTP Client error response! Status code: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"HTTP Client Error: {ex.Message}");
                return null;
            }
        }
    }
}