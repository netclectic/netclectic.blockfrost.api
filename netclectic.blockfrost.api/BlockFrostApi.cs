using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;

namespace netclectic.blockfrost.api
{
    public class BlockFrostApi
    {
        public IBlockFrostApi Api { get; }
        public event EventHandler<RequestSent> SendRequest;
        public event EventHandler<ResponseReceived> ReceiveResponse;

        public BlockFrostApi(string serverAddress, string apiKey, IWebProxy proxy = null)
        {
            var handler = new CustomHttpClientHandler(proxy);
            handler.SendRequest += Handler_SendRequest;
            handler.ReceiveResponse += Handler_ReceiveResponse;

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(serverAddress),
            };

            var settings = new JsonSerializerSettings()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                TypeNameHandling = TypeNameHandling.Auto
            };
            settings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
            settings.Converters.Add(new VersionConverter());

            Api = new RestEase.RestClient(httpClient)
            {
                ResponseDeserializer = new CustomJsonResponseDeserializer(),
                JsonSerializerSettings = settings
            }.For<IBlockFrostApi>();
            Api.ApiKey = apiKey;
        }

        private void Handler_SendRequest(object sender, RequestSent e)
        {
            SendRequest?.Invoke(this, e);
        }

        private void Handler_ReceiveResponse(object sender, ResponseReceived e)
        {
            ReceiveResponse?.Invoke(this, e);
        }
    }
}

namespace System.Runtime.CompilerServices
{
    public record IsExternalInit;
}