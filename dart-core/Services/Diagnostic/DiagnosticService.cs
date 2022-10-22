using dart_core.Helper.Response;
using dart_core.Helper.Tools;
using dart_schema.Diagnostic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_core.Services.Diagnostic
{
    public class DiagnosticService : IDiagnosticService
    {
        private readonly DbContext _diagnosticDbContext;
        public DiagnosticService(DbContext DiagnosticDbContext)
        {
            _diagnosticDbContext = DiagnosticDbContext;
        }

        public ServiceResponse InvokeWait(int millisecondsTimeout)
        {
            ServiceResponse response = new ServiceResponse();
            Thread.Sleep(millisecondsTimeout);
            return response.PassResponse();
        }

        public void Log(ServiceDiagnostic serviceDiagnostic)
        {
            _diagnosticDbContext.
        }

       
    }
}
