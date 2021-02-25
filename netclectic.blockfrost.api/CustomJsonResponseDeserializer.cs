using Newtonsoft.Json;
using RestEase;
using System.Net.Http;

namespace netclectic.blockfrost.api
{
    public class CustomJsonResponseDeserializer : ResponseDeserializer
    {
        public JsonSerializerSettings JsonSerializerSettings { get; set; }

        public override T Deserialize<T>(string content, HttpResponseMessage response, ResponseDeserializerInfo info)
        {
            return JsonConvert.DeserializeObject<T>(content, JsonSerializerSettings);
        }
    }
}
