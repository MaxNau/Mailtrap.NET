using Mailtrap.NET.Contracts.Request;
using Mailtrap.NET.Contracts.Response;
using Mailtrap.NET.Data;
using Mailtrap.NET.Endpoints.Constants;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mailtrap.NET.Endpoints
{
    /// <summary>
    /// Mailtrap Email Sending Endpoint
    /// </summary>
    public class EmailSending : IEmailSending
    {
        private readonly MailtrapClient _mailtrapClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSending"/> class. 
        /// </summary>
        /// <param name="mailtrapClient"></param>
        public EmailSending(MailtrapClient mailtrapClient)
        {
            _mailtrapClient = mailtrapClient;
        }

        /// <summary>
        /// Send email (text, html, text and html, templates)
        /// </summary>
        /// <param name="email"></param>
        /// <returns>MailtrapResponse</returns>
        public async Task<MailtrapResponse> SendAsync(Email email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            return await _mailtrapClient.SendAsync(
                HttpMethod.Post,
                EndpointsLocation.EmailSending.Send,
                data: new JsonRequestContent<Email>(email))
                .ConfigureAwait(false);
        }
    }
}
