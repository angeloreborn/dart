using dart_core.Helper.Response;
using dart_core.Helper.Tools;
using dart_core_api.Models;
using dart_core_api.Services.Base;
using dart_core_api.Services.Project;
using dart_schema.Diagnostic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_core_api.Services.Diagnostic
{
    public interface IDiagnosticService : IBaseService<DiagnosticModel>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        ServiceResponse InvokeWait(int millisecondsTimeout);
    }
    public class DiagnosticService : BaseService<DiagnosticModel>, IDiagnosticService
    {
        private readonly DbContext _diagnosticDbContext;
        public DiagnosticService(DbContext diagnosticDbContext) : base(diagnosticDbContext)
        {
            _diagnosticDbContext = diagnosticDbContext;
        }

        public ServiceResponse InvokeWait(int millisecondsTimeout)
        {
            ServiceResponse response = new ServiceResponse();
            Thread.Sleep(millisecondsTimeout);
            return response.PassResponse();
        }     
    }
}
