using Mailtrap.NET.Contracts.Request;
using Mailtrap.NET.Contracts.Response;
using System.Threading.Tasks;

namespace Mailtrap.NET.Endpoints
{
    /// <summary>
    /// Interface for EmailSending
    /// </summary>
    public interface IEmailSending
    {
        /// <summary>
        /// Send email (text, html, text and html, templates)
        /// </summary>
        /// <param name="email"></param>
        /// <returns>MailtrapResponse</returns>
        Task<MailtrapResponse> SendAsync(Email email);
    }
}
