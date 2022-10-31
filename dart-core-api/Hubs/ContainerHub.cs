using dart_core_api.Services.Diagnostic;
using dart_core_api.Services.System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Reflection;

namespace dart_core_api.Hubs
{
    public class ContainerHub : Hub
    {
        public async Task ServiceHandler(string container, string method, object[] obj,
            [FromServices] IServiceFactory serviceFactory)
        {
            DiagnosticTracker diagnosticTracker = new DiagnosticTracker();
            object? service = serviceFactory.GetService(container);
            if (service == null) return;
            Type? serviceType = service.GetType();
            if (serviceType == null) return;
            MethodInfo? serviceMethodInfo = serviceType.GetMethod(method);
            if (serviceMethodInfo == null) return;
            ParameterInfo[] paramInfo = serviceMethodInfo.GetParameters();
            List<object> invokedParams = new List<object>();
            foreach (var param in paramInfo)
            {
                object? paramValue = null;
                foreach (object obj2 in obj)
                {
                    if (obj2.GetType() == param.ParameterType)
                    {
                        paramValue = obj2;
                    }
                }
                if (paramValue == null)
                {
                    if (param.ParameterType == typeof(ContainerHub))
                    {
                        paramValue = this;
                    }
                    else
                    {
                        var serviceBinding = serviceFactory.GetServiceByType(param.ParameterType);
                        if (serviceBinding != null)
                        {
                            paramValue = serviceBinding;
                        }
                        else
                        {
                            paramValue = Activator.CreateInstance(param.ParameterType);
                        }
                    }
                }
                if (paramValue == null) throw new NullReferenceException();
                invokedParams.Add(paramValue);
            }
            var arg = serviceMethodInfo.Invoke(service, invokedParams.ToArray());
            await Clients.All.SendAsync(method, arg);
        }
    }
}
