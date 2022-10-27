using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dart_core_api.Models
{
    public class BaseModel
    {
        [Key]
        public long Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; }
    }
    public interface IModifiable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ModifiedDate { get; set; }
    }
    public interface ISoftDeletable
    {
        [DefaultValue(false)]
        public bool SoftDeleted { get; set; }
    }
}
