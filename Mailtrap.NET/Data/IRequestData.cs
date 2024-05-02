using Mailtrap.NET.Serializers;
using System.Net.Http;

namespace Mailtrap.NET.Data
{
    internal interface IRequestData
    {
        HttpContent GetContent(ISerializer serializer);
    }
}
