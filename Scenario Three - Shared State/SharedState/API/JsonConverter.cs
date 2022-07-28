using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedState.API
{
    public static class JsonConverter
    {
        public static Content ContentDeserializer(string jsonString) => JsonConvert.DeserializeObject<Content>(jsonString);

        public static string ContentSerializer(Content jsonContent) => JsonConvert.SerializeObject(jsonContent);
    }
}
