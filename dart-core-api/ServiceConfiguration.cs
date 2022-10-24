using dart_core.Services.Diagnostic;
using dart_core.Services.Project;
using dart_core.Services.System;
using dart_core_api.Hubs;
using dart_core_api.Ninject;
using Microsoft.AspNet.SignalR;

namespace dart_core_api
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IDiagnosticService, DiagnosticService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddScoped<IServiceFactory, ServiceFactory>();
           // services.AddSingleton(new ContainerHub(services.BuildServiceProvider()));

        }
    }

}
