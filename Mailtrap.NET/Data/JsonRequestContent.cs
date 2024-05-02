using Mailtrap.NET.Contracts.Request;
using Mailtrap.NET.Serializers;
using System;
using System.Net.Http;
using System.Text;

namespace Mailtrap.NET.Data
{
    internal class JsonRequestContent<T> : IRequestData where T : IMailtrapRequestBody
    {
        private const string JsonMimeType = "application/json";

        private readonly T _data;

        public JsonRequestContent(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            _data = data;
        }

        public HttpContent GetContent(ISerializer serializer)
        {
            return new StringContent(serializer.Serialize(_data), Encoding.UTF8, JsonMimeType);
        }
    }
}
