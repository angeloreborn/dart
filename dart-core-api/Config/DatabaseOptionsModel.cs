using dart_core_api.Attributes.ReadonlyAnnotations;
using dart_core_api.Helper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            /// controls lifetime and health of database
            /// </summary>
            public static class Lifetime
            {
                /// <summary>
                /// sets maximum records for intance of the database context
                /// </summary>
                [DefaultValue(long.MaxValue)]
                public static long MaximumRecords { get; set; }
                /// <summary>
                /// will purge old records on fullfilment <see cref="MaximumRecords"/>
                /// </summary>
                [DefaultValue(false)]
                public static bool PurgeOldRecords { get; set; }
                /// <summary>
                /// ovverides existing lifetime fullfillments and ditributes to a new shard 
                /// </summary>
                [DefaultValue(true)]
                public static bool ShardDatabase { get; set; }
            }

        }
    }
  
}
