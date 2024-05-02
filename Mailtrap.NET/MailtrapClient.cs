using Mailtrap.NET.Configuration;
using Mailtrap.NET.Contracts.Response;
using Mailtrap.NET.Data;
using Mailtrap.NET.Endpoints;
using Mailtrap.NET.Serializers;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mailtrap.NET
{
    /// <summary>
    /// Mailtrap API client
    /// </summary>
    public sealed class MailtrapClient : IMailtrapClient, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly MailtrapApiConfiguration _configuration;
        private readonly ISerializer _serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MailtrapClient"/> class. 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="configuration"></param>
        /// <param name="serializer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MailtrapClient(HttpClient httpClient, MailtrapApiConfiguration configuration, ISerializer serializer = null)

        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            
            _serializer = serializer ?? DefaultSerializer.Serializer;
         
            _httpClient.DefaultRequestHeaders.Add(ApiHeaderNames.ApiToken, configuration.ApiToken);

            EmailSending = new EmailSending(this);
        }

        /// <summary>
        /// Email Sending client
        /// </summary>
        public IEmailSending EmailSending { get; set; }

        internal async Task<MailtrapResponse> SendAsync(HttpMethod httpMethod, string path, IQueryString queryString = default, IRequestData data = default)
        {
            if (httpMethod == null)
            {
                throw new ArgumentNullException(nameof(httpMethod));
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (httpMethod == HttpMethod.Post && data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return await SendInternalAsync(httpMethod, path, queryString, data).ConfigureAwait(false);
        }

        private async Task<MailtrapResponse> SendInternalAsync(HttpMethod httpMethod, string path, IQueryString queryString, IRequestData data)
        {
            var requestMessage = CreateRequest(httpMethod, path, queryString, data);
            var response = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            return await _serializer.DeserializeAsync<MailtrapResponse>(await response.Content.ReadAsStreamAsync())
                .ConfigureAwait(false);
        }

        private HttpRequestMessage CreateRequest(HttpMethod httpMethod, string path, IQueryString queryString, IRequestData data)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, BuildUri(_configuration.BaseUri, path, queryString))
            {
                Content = data.GetContent(_serializer),
            };

            return requestMessage;
        }

        private Uri BuildUri(Uri baseUri, string path, IQueryString queryString)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException(nameof(baseUri));
            }

            var builder = new UriBuilder(baseUri);

            if (!string.IsNullOrWhiteSpace(path))
            {
                builder.Path += path;
            }

            if (queryString != null)
            {
                builder.Query = queryString.GetQueryString();
            }

            return builder.Uri;
        }

        /// <summary>
        /// Releases the unmanaged recources of underlying objects
        /// </summary>
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
