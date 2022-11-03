using dart_core_api.Models;

namespace dart_core_api.Schemas.MainSchema
{
    public class PackageReferenceModel : BaseModel
    {
        public string PackageName { get; set; }
        public string PackageVersion { get; set; }
        public bool IncludeAssets { get; set; }
    }
}
