namespace Mailtrap.NET.Contracts.Request
{
    /// <summary>
    /// Info about email Sender or Recepient
    /// </summary>
    public class EmailInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailInfo"/> class.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="name"></param>
        public EmailInfo(string email, string name = null)
        {
            Email = email;
            Name = name;
        }

        /// <summary>
        /// Email address of the sender or recipient
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Name of the sender or recipient
        /// </summary>
        public string Name { get; }
    }
}
