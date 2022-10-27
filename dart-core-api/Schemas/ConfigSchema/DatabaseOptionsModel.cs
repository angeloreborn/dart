using dart_core_api.Attributes.ReadonlyAnnotations;
using dart_core_api.Helper;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;

namespace dart_core_api.Schemas.ConfigSchema
{
    /// <summary>
    /// Should not generate <see cref="ExportTsClassAttribute"/> or <see cref="ExportTsInterfaceAttribute"/>
    /// </summary>
    public class BaseDatabaseOptionsModel
    {
        [DefaultValue(false)]
        public bool TrackStateChanges { get; set; }
        [DefaultValue(false)]
        public bool TrackDetailedStateChanges { get; set; }
        [DefaultValue(long.MaxValue)]
        public long MaximumRecords { get; set; }
    }
}
