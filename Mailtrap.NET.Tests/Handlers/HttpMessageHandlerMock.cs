using Mailtrap.NET.Contracts.Request;
using Mailtrap.NET.Contracts.Response;
using Mailtrap.NET.Serializers;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Mailtrap.NET.Tests.Handlers
{
    internal class HttpMessageHandlerMock : HttpMessageHandler
    {
        private readonly ISerializer _serializer = DefaultSerializer.Serializer;
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await HandleResponseAsync(request);
        }

        private async Task<HttpResponseMessage> HandleResponseAsync(HttpRequestMessage request)
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK
            };

            if (request.Content != null)
            {
                dynamic content = await _serializer.DeserializeAsync<dynamic>(await request.Content.ReadAsStreamAsync());
                if (content is JsonElement jsonElement)
                {
                    jsonElement.TryGetProperty(nameof(EmailWithText.Text).ToLowerInvariant(), out var text);
                    if (string.IsNullOrEmpty(text.GetString()))
                    {
                        response.Content = new StringContent(_serializer.Serialize(new MailtrapResponse { Success = false, Errors = new List<string> { "Text is required" } }), Encoding.UTF8, "application/json");
                        return response;
                    }
                }
            }

            response.Content = new StringContent(_serializer.Serialize(new MailtrapResponse { Success = true, MessageIds = new List<Guid> { Guid.NewGuid() } }), Encoding.UTF8, "application/json");
            return response;
        }
    }
}
