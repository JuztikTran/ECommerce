using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjetcs.Models
{
    public class Cart : BaseModel
    {
        [Required]
        [StringLength(32)]
        public string UserID { get; set; } = default!;

        [Required]
        [StringLength(32)]
        public string OptionID { get; set; } = default!;
        [ForeignKey(nameof(OptionID))]
        public virtual ProductOption Option { get; set; } = default!;

        [Range(1, int.MaxValue)]
        [DefaultValue(1)]
        public int Quantity { get; set; }
    }
}
