using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dart_core_api.Models
{
    public interface IBaseModel : IModifiable, ISoftDeletable, ICreatable
    {
        public long Id { get; set; }
    }
    public class BaseModel : IBaseModel
    {
        [Key]
        public long Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ModifiedDate { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
    public interface IModifiable
    {
        public DateTime ModifiedDate { get; set; }
    }
    public interface ICreatable
    {
        public DateTime CreatedDate { get; set; }
    }
    public interface ISoftDeletable
    {
        public bool Deleted { get; set; }
    }
}
