using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mailtrap.NET.Serializers
{
    /// <summary>
    /// DefaultSerializer
    /// </summary>
    public static class DefaultSerializer
    {
        private static readonly JsonSerializerOptions _options;

        static DefaultSerializer()
        {
            _options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
            _options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower, false));
        }

        /// <summary>
        /// Reutrns new instance of TextJsonSerializer
        /// </summary>
        public static ISerializer Serializer => new TextJsonSerializer(_options);
    }
}
