using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObjetcs.Models
{
    public class Category : BaseModel
    {
        [Required]
        [StringLength(32)]
        public string ParentID { get; set; } = default!;
        [ForeignKey(nameof(ParentID))]
        public virtual Category Parent { get; set; } = default!;
        [JsonIgnore]
        public virtual ICollection<Category> Children { get; set; } = default!;

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = default!;
        public virtual ICollection<Product> Products { get; set; } = default!;
    }
}
