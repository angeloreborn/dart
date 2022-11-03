using dart_core_api.Helper;
using dart_core_api.Models;
using System.ComponentModel;
using TypeGen.Core.TypeAnnotations;

namespace dart_core_api.Schemas.MainSchema
{
    [ExportTsClass]
    [ExportTsInterface]
    public interface IProjectModel
    {
        public string? Namespace { get; set; }
        public List<ProjectModel>? ProjectReferences { get; set; }
        public List<PackageReference>? PackageReferences { get; set; }
        public ProjectType ProjectType { get; set; }
    }
    [ExportTsClass]
    [ExportTsInterface]
    public class ProjectModel : BaseModel, IProjectModel
    {
        public string? Namespace { get; set; }
        public string? FullPath { get; set; }
        public ProjectType ProjectType { get; set; }
        public List<ProjectModel>? ProjectReferences { get; set; }
        public List<PackageReference>? PackageReferences  { get; set; }
    }
}
