using System;
using System.Collections.Generic;

namespace Mailtrap.NET.Contracts.Request
{
    /// <summary>
    /// Email that has template in it
    /// </summary>
    public class EmailFromTemplate : Email
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailFromTemplate"/> class.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="templateUuid"></param>
        /// <param name="cc"></param>
        /// <param name="bcc"></param>
        /// <param name="attachments"></param>
        /// <param name="templateVariables"></param>
        public EmailFromTemplate(EmailInfo from, List<EmailInfo> to, string subject, Guid templateUuid,
            List<EmailInfo> cc = null, List<EmailInfo> bcc = null, List<Attachment> attachments = null, object templateVariables = null)
            : base(from, to, subject, cc, bcc, attachments)
        {
            TemplateUuid = templateUuid;
            TemplateVariables = templateVariables;
        }

        /// <summary>
        /// UUID of email template. Subject, text and html will be generated from template using optional template_variables.
        /// If template_uuid is provided then subject, text and html params are forbidden
        /// </summary>
        public Guid TemplateUuid { get; }

        /// <summary>
        /// Optional template variables that will be used to generate actual subject, text and html from email template
        /// </summary>
        public object TemplateVariables { get; }
    }
}
