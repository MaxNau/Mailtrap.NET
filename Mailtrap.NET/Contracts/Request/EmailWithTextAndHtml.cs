using System.Collections.Generic;

namespace Mailtrap.NET.Contracts.Request
{
    /// <summary>
    /// Email that has both text and html markup in it
    /// </summary>
    public class EmailWithTextAndHtml : EmailWithText
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailWithTextAndHtml"/> class.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="text"></param>
        /// <param name="html"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="attachments"></param>
        public EmailWithTextAndHtml(EmailInfo from, List<EmailInfo> to, string subject, string text,
            string html, List<EmailInfo> cc = null, List<EmailInfo> bcc = null, List<Attachment> attachments = null)
            : base(from, to, subject, text, cc, bcc, attachments)
        {
            Html = html;
        }

        /// <summary>
        /// HTML version of the body of the email. Can be used along with text to create a fallback for non-html clients. Required in the absence of text
        /// </summary>
        public string Html { get; }
    }
}
