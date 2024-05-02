using System;

namespace Mailtrap.NET.Configuration
{
    /// <summary>
    /// Mailtrap API configuration
    /// </summary>
    public class MailtrapApiConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailtrapApiConfiguration"/> class.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="apiToken"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MailtrapApiConfiguration(Uri baseUri, string apiToken)
        {
            BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));
            ApiToken = apiToken ?? throw new ArgumentNullException(nameof(apiToken));
        }

        /// <summary>
        /// API base uri
        /// </summary>
        public Uri BaseUri { get; }

        /// <summary>
        /// API token
        /// </summary>
        public string ApiToken { get; }
    }
}
