using dart_core.Helper.Tools;
using dart_schema.Diagnostic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_core.Services.Diagnostic
{
    public class DiagnosticTracker
    {
        private readonly Benchmark _benchmark;

        public DiagnosticTracker()
        {
            _benchmark = new Benchmark();
        }

        public ServiceDiagnostic Stop()
        {
            return new ServiceDiagnostic
            {

            };
        }
    }
}
