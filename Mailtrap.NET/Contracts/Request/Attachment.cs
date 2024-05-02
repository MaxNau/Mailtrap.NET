using System.Runtime.Serialization;

namespace Mailtrap.NET.Contracts.Request
{
    /// <summary>
    /// Enum of email attachment disposition
    /// </summary>
    public enum Disposition
    {
        /// <summary>
        /// Disposition as attachment
        /// </summary>
        [EnumMember(Value = "attachment")]
        Attachment,
        /// <summary>
        /// Disposition as inline attachment (for images only)
        /// </summary>
        [EnumMember(Value = "inline")]
        Inline
    }

    /// <summary>
    /// Email attachment
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Attachment"/> class.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        public Attachment(string content, string fileName, string type = null)
        {
            Content = content;
            Filename = fileName;
            Type = type;
        }

        /// <summary>
        /// The Base64 encoded content of the attachment.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// The MIME type of the content you are attaching (e.g., “text/plain” or “text/html”)
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// The attachment's filename.
        /// </summary>
        public string Filename { get; }

        /// <summary>
        /// The attachment's content-disposition, specifying how you would like the attachment to be displayed. 
        /// For example, “inline” results in the attached file are displayed automatically within the message while “attachment”
        /// results in the attached file require some action to be taken before it is displayed, such as opening or downloading the file.
        /// </summary>
        public virtual Disposition Disposition { get; }
    }
}
