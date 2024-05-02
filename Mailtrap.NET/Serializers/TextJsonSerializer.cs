using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mailtrap.NET.Serializers
{
    internal class TextJsonSerializer : ISerializer
    {
        private readonly JsonSerializerOptions _options;
        public TextJsonSerializer(JsonSerializerOptions options)
        {
            _options = options;
        }

        public async ValueTask<T> DeserializeAsync<T>(Stream stream)
        {
            return await JsonSerializer.DeserializeAsync<T>(stream, _options).ConfigureAwait(false);
        }

        public string Serialize<T>(T @object)
        {
            return JsonSerializer.Serialize(@object, @object.GetType(), _options);
        }
    }
}
