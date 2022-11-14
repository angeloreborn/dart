using dart_core.Helper.Response;
using dart_core_api.Services.Diagnostic;
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
    }
}
