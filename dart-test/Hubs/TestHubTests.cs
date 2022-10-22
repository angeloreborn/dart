using Moq;
using NUnit.Framework;
using dart_core_api.Hubs;
using System.Dynamic;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using IClientProxy = Microsoft.AspNetCore.SignalR.IClientProxy;

namespace dart_test.Hubs
{
    [TestFixture]
    public class TestHubTests
    {
        private MockRepository mockRepository;



        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private TestHub CreateTestHub()
        {
            return new TestHub();
        }

        [Test]
        public async Task Client_ReceivesMessageFrom_Hub()
        {
            // arrange
            Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
            Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();

            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            TestHub simpleHub = new TestHub()
            {
                Clients = mockClients.Object
            };

            // act
            await simpleHub.SendMessage(String.Empty, String.Empty);

            // assert
            mockClients.Verify(clients => clients.All, Times.AtMostOnce);
        }

        [Test]
        public async Task Client_ReceivesMultipleMessagesFrom_Hub()
        {
            // arrange
            Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
            Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();

            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            TestHub simpleHub = new TestHub()
            {
                Clients = mockClients.Object
            };

            // act
            await simpleHub.SendMessage(String.Empty, String.Empty);
            await simpleHub.SendMessage(String.Empty, String.Empty);

            // assert
            mockClients.Verify(clients => clients.All, Times.AtLeast(2));
        }
    }
}
