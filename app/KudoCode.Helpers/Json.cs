using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KudoCode.Helpers
{
    public static class Json
    {
        public static class Serialization
        {

            public static JsonSerializerOptions Default()
            {
                return new System.Text.Json.JsonSerializerOptions();
            }

            public static JsonSerializerSettings Auto()
            {
                return new JsonSerializerSettings
                {
                    //TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameHandling = TypeNameHandling.Auto,
                    //ContractResolver = new DefaultContractResolver()
                };
            }

            public static JsonSerializerSettings Objects()
            {
                return new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full
                };
            }
        }
    }
}