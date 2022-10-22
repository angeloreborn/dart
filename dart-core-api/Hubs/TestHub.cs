using Microsoft.AspNetCore.SignalR;

namespace dart_core_api.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendMessage(string user, string message)
            => await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
