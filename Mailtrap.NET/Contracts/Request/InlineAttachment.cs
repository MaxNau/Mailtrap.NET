
namespace Mailtrap.NET.Contracts.Request
{
    /// <summary>
    /// Email inline attachment (images only)
    /// </summary>
    public class InlineAttachment : Attachment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InlineAttachment"/> class.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <param name="contentId"></param>
        public InlineAttachment(string content, string fileName, string type = null, string contentId = null) 
            : base(content, fileName, type)
        {
            ContentId = contentId;
        }

        /// <summary>
        /// The attachment's content-disposition, specifying how you would like the attachment to be displayed. 
        /// For example, “inline” results in the attached file are displayed automatically within the message while “attachment”
        /// results in the attached file require some action to be taken before it is displayed, such as opening or downloading the file.
        /// </summary>
        public override Disposition Disposition => Disposition.Inline;

        /// <summary>
        /// The attachment's content ID. This is used when the disposition is set to “inline” and the attachment is an image,
        /// allowing the file to be displayed within the body of your email.
        /// </summary>
        public string ContentId { get; }
    }
}
