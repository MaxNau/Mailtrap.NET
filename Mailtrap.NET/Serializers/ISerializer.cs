using System.IO;
using System.Threading.Tasks;

namespace Mailtrap.NET.Serializers
{
    /// <summary>
    /// Message serializer interface
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Serializes object to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="object"></param>
        /// <returns></returns>
        string Serialize<T>(T @object);

        /// <summary>
        /// Deserializes stream into provided type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        ValueTask<T> DeserializeAsync<T>(Stream stream);
    }
}
