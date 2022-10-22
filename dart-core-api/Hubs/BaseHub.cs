﻿using Microsoft.AspNetCore.SignalR;

namespace dart_core_api.Hubs
{
    public class BaseHub : Hub
    {
        public async Task SendMessage(string user, string message)
            => await Clients.All.SendAsync("ReceiveMessage", user, message);

        public async Task SendMessageToCaller(string user, string message)
            => await Clients.Caller.SendAsync("ReceiveMessage", user, message);

        public async Task SendMessageToGroup(string user, string message)
            => await Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);
    }
}
