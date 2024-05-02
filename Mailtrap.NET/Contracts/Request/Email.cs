using System.Collections.Generic;

namespace Mailtrap.NET.Contracts.Request
{
    /// <summary>
    /// Email abstraction
    /// </summary>
    public abstract class Email : IMailtrapRequestBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="attachments"></param>
        public Email(EmailInfo from, List<EmailInfo> to, string subject,
            List<EmailInfo> cc = null, List<EmailInfo> bcc = null,
            List<Attachment> attachments = null)
        {
            From = from;
            To = to;
            Subject = subject;
            Cc = cc;
            Bcc = bcc;
            Attachments = attachments;
        }

        /// <summary>
        /// Sender EmailInfo
        /// </summary>
        public EmailInfo From { get; }
        
        /// <summary>
        /// Recepient EmailInfo
        /// </summary>
        public List<EmailInfo> To { get; }

        /// <summary>
        /// An array of recipients who will receive a carbon copy of your email.
        /// Each object in this array must contain the recipient's email address.
        /// Each object in the array may optionally contain the recipient's name.
        /// </summary>
        public List<EmailInfo> Cc { get; }

        /// <summary>
        /// An array of recipients who will receive a blind carbon copy of your email.
        /// Each object in this array must contain the recipient's email address.
        /// Each object in the array may optionally contain the recipient's name.
        /// </summary>
        public List<EmailInfo> Bcc { get; }

        /// <summary>
        /// The global or 'message level' subject of your email. This may be overridden by subject lines set in personalizations.
        /// </summary>
        public string Subject { get; }

        /// <summary>
        /// An array of objects where you can specify any attachments you want to include.
        /// </summary>
        public List<Attachment> Attachments { get; }
    }
}
