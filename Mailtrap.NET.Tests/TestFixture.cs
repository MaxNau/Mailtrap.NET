using Mailtrap.NET.Configuration;
using Mailtrap.NET.Tests.Handlers;

namespace Mailtrap.NET.Tests
{
    public sealed class TestFixture : IDisposable
    {
        public TestFixture()
        {
            MailtrapClient = new MailtrapClient(new HttpClient(new HttpMessageHandlerMock()), new MailtrapApiConfiguration(new Uri("https://mock"), string.Empty));
        }

        public MailtrapClient MailtrapClient { get; }

        public void Dispose()
        {
            MailtrapClient.Dispose();
        }
    }
}
