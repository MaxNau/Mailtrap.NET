using System;
using System.Collections.Generic;

namespace Mailtrap.NET.Contracts.Response
{
    /// <summary>
    /// Mailtrap API response
    /// </summary>
    public class MailtrapResponse
    {
        /// <summary>
        /// Indicates if request was successfull or not 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// A list of message IDs, one per recipient, in order of To, Cc, Bcc
        /// </summary>
        public List<Guid> MessageIds { get; set; }

        /// <summary>
        /// A list of errors that might tell why request was unsuccessfull
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
