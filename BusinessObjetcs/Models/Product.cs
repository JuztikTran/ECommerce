using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjetcs.Models
{
    public class Product : BaseModel
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = default!;

        [Required]
        public string Description { get; set; } = default!;

        [Required]
        public string Thumbnail { get; set; } = default!;

        [Range(0, double.MaxValue)]
        [DefaultValue(0)]
        [Column(TypeName = "money")]
        public double Price { get; set; }

        [Range(0, 1)]
        [DefaultValue(0)]
        [Column(TypeName = "numeric(3,2)")]
        public double Discount { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = default!;
        public virtual ICollection<ProductOption> Options { get; set; } = default!;
    }

    public class ProductOption : BaseModel
    {
        [Required]
        [StringLength(32)]
        public string ProductID { get; set; } = default!;
        [ForeignKey(nameof(ProductID))]
        public virtual Product Product { get; set; } = default!;

        [Required]
        [StringLength(10)]
        public string Size { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Color { get; set; } = default!;

        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public int Quantity { get; set; }
    }
}
