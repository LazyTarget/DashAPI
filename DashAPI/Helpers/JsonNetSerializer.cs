using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace DashAPI.Helpers
{
    public class JsonNetSerializer : IDeserializer, ISerializer
    {
        private JsonSerializer _serializer;

        public JsonNetSerializer(JsonSerializer serializer)
        {
            Serializer = serializer;
            ContentType = "application/json";
        }

        
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        public string ContentType { get; set; }

        public JsonSerializer Serializer
        {
            get { return _serializer; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                _serializer = value;
            }
        }

        public string Serialize(object obj)
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            _serializer.Serialize(sw, obj);
            var json = sb.ToString();
            return json;
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var sr = new StringReader(response.Content);
            var jtr = new JsonTextReader(sr);
            var result = _serializer.Deserialize<T>(jtr);
            return result;
        }
    }
}