using dart_core_api.Services.Diagnostic;
using dart_core_api.Services.System;
using dart_schema.Diagnostic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Reflection;

namespace dart_core_api.Hubs
{
    public class ContainerHub : Hub
    {
        public async Task ServiceHandler(string container,  string method, object[] obj, 
            [FromServices] IServiceFactory serviceFactory, 
            [FromServices]IDiagnosticService diagnosticService)
        {
            DiagnosticTracker diagnosticTracker = new DiagnosticTracker();
            object? service = serviceFactory.GetService(container);
            if (service == null) return;
            Type? serviceType = service.GetType();
            if (serviceType == null) return;
            MethodInfo? serviceMethodInfo = serviceType.GetMethod(method);
            if (serviceMethodInfo == null) return;
            var arg = serviceMethodInfo.Invoke(service, obj);
            await Clients.All.SendAsync(method, arg);
            ServiceDiagnostic serviceDiagnositc = diagnosticTracker.Stop();

        }
    }
}
