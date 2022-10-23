using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace dart_core_api.Hubs
{
    [EnableCors("TestCors")]
    public class TestHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
       
    }
}
