using System.Collections.Generic;

namespace Mailtrap.NET.Contracts.Request
{
    /// <summary>
    /// Email with text
    /// </summary>
    public class EmailWithText : Email
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailWithText"/> class.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="text"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="attachments"></param>
        public EmailWithText(EmailInfo from, List<EmailInfo> to, string subject, string text,
            List<EmailInfo> cc = null, List<EmailInfo> bcc = null, List<Attachment> attachments = null)
            : base(from, to, subject, cc, bcc, attachments)
        {
            Text = text;
        }

        /// <summary>
        /// Text version of the body of the email. Can be used along with html to create a fallback for non-html clients. Required in the absence of html
        /// </summary>
        public string Text { get; }
    }
}
