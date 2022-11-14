using dart_core_api.Models;
using System.ComponentModel;
using System.Diagnostics;
using TypeGen.Core.TypeAnnotations;

namespace dart_core_api.Schemas.DiagnosticSchema
{
    [ExportTsClass]
    [ExportTsInterface]
    public class DiagnosticModel : BaseModel
    {
        [DefaultValue(-1)]
        public double NaRuntime { get; set; }
        [DefaultValue(-1)]
        public double MsRuntime { get; set; }
        [DefaultValue(-1)]
        public double ScRuntime { get; set; }
        public DiagnosticModel(long nanoRuntime) 
        {
            NaRuntime = nanoRuntime;
            MsRuntime = nanoRuntime * 0.000001;
            ScRuntime = nanoRuntime * 0.000000001;
        }
    }
}
