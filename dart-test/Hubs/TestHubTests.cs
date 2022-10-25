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


    }
}
