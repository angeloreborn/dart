using dart_core_api.Attributes.ReadonlyAnnotations;
using dart_core_api.Helper;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;

namespace dart_core_api.Config
{
    /// <summary>
    /// Should not generate <see cref="ExportTsClassAttribute"/> or <see cref="ExportTsInterfaceAttribute"/>
    /// </summary> 

    public static class Config
    {
        public static bool Initialize() => default;
        public static class Database
        {
            /// <summary>
            /// controls the state and property tracking of ef core operations
            /// </summary>
            public static class Tracking
            {
                /// <summary>
                /// will track the state of the operation performed
                /// </summary>
                [DefaultValue(false)]
                public static bool TrackStateChanges { get; set; }
                /// <summary>
                /// will track the property value changes
                /// </summary>
                [DefaultValue(false)]
                public static bool TrackDetailedStateChanges { get; set; }
            }

            /// <summary>
            /// sets maximum records for intance of the database context
            /// </summary>
            [DefaultValue(long.MaxValue)]
            public static long MaximumRecords { get; set; }
        }
    }
  
}
