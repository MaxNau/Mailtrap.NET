using Mailtrap.NET.Endpoints;

namespace Mailtrap.NET
{
    /// <summary>
    /// Mailtrap API client interface
    /// </summary>
    public interface IMailtrapClient
    {
        /// <summary>
        /// EmailSending endpoint
        /// </summary>
        IEmailSending EmailSending { get; set; }
    }
}
