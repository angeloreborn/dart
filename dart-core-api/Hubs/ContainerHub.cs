using dart_core.Services.Project;
using dart_core.Services.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Reflection;

namespace dart_core_api.Hubs
{
    public class ContainerHub : Hub
    {
        public async Task ServiceHandler(string container, string method, object[] obj, [FromServices] IServiceFactory serviceFactory)
        {
            object? service = serviceFactory.GetService(container);

            if (service == null) return;

            Type? serviceType = service.GetType(); //_serviceProvider.GetService(t);

            if (serviceType == null) return;

            MethodInfo? serviceMethodInfo = serviceType.GetMethod(method);

            if (serviceMethodInfo == null) return;

            serviceMethodInfo.Invoke(service, obj);

            await Clients.All.SendAsync("ReceiveMessage", "");

        }
    }
}
