using dart_core_api.Hubs;
using dart_core_api.Services.Diagnostic;
using dart_core_api.Services.Project;
using dart_core_api.Services.System;
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
