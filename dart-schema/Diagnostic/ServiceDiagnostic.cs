using dart_schema.Helper.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dart_schema.Diagnostic
{
    public class ServiceDiagnostic
    {
        public Guid ServiceDiagnosticId { get; set; }

        public Benchmark Benchmark { get; set; }
    }
}
