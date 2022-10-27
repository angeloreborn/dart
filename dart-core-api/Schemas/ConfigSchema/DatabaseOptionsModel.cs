using dart_core_api.Attributes.ReadonlyAnnotations;
using TypeGen.Core.TypeAnnotations;

namespace dart_core_api.Schemas.ConfigSchema
{
    [@ShouldNotBeExportedToTsAttribute]
    public class DatabaseOptionsModel
    {
        public int MyProperty { get; set; }
    }
}
