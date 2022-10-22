using dart_core.Services.Diagnostic;

namespace dart_core_api
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IDiagnosticService, DiagnosticService>();
        }
    }

}
