using Mailtrap.NET.Contracts.Request;

namespace Mailtrap.NET.Tests
{
    public class MailtrapClientTests : IClassFixture<TestFixture>
    {
        private IMailtrapClient _client;

        public MailtrapClientTests(TestFixture fixture)
        {
            _client = fixture.MailtrapClient;
        }

        [Fact]
        public async void SendEmailSucceeds()
        {
            var response = await _client.EmailSending.SendAsync(
                new EmailWithText(
                    from: new EmailInfo("mailtrap@demomailtrap.com"),
                    to: [ new EmailInfo ("test@mail.com") ],
                    subject: "Test Subject",
                    text: "API test"));

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotEmpty(response.MessageIds);
        }

        [Fact]
        public async void SendEmailWithNoTextFails()
        {
            var response = await _client.EmailSending.SendAsync(
                new EmailWithText(
                    from: new EmailInfo("mailtrap@demomailtrap.com"),
                    to: [new EmailInfo("test@mail.com")],
                    subject: "Test Subject",
                    text: ""));

            Assert.NotNull(response);
            Assert.False(response.Success);
            Assert.NotEmpty(response.Errors);
        }
    }
}