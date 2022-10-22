using dart_core.Helper.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_core.Services.Diagnostic
{
    public interface IDiagnosticService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        ServiceResponse InvokeWait(int millisecondsTimeout);
    }
}
