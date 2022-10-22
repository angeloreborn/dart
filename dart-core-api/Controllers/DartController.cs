using dart_core.Helper.Response;
using dart_core.Services.Diagnostic;
using Microsoft.AspNetCore.Mvc;

namespace dart_core_api.Controllers
{
    public class DartController : ControllerBase
    {
        private readonly IDiagnosticService DiagnosticService;
        public DartController(IDiagnosticService DiagnosticService)
        {
            this.DiagnosticService = DiagnosticService;
        }
        [HttpGet(Name = "Ping")]
        public ServiceResponse Ping(int waitMilliseconds = 0)
        {
            return DiagnosticService.InvokeWait(waitMilliseconds);
        }
    }
}
