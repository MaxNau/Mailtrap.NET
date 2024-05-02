using System.Collections.Generic;

namespace Mailtrap.NET.Contracts.Request
{
    /// <summary>
    /// Email that has html markup in it
    /// </summary>
    public class EmailWithHtml : Email
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailWithHtml"/> class.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="html"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="attachments"></param>
        public EmailWithHtml(EmailInfo from, List<EmailInfo> to, string subject, string html,
            List<EmailInfo> cc = null, List<EmailInfo> bcc = null, List<Attachment> attachments = null)
            : base(from, to, subject, cc, bcc, attachments)
        {
            Html = html;
        }

        /// <summary>
        /// HTML version of the body of the email. Can be used along with text to create a fallback for non-html clients. Required in the absence of text
        /// </summary>
        public string Html { get; }
    }
}
