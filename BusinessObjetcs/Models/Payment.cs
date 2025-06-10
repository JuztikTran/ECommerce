using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjetcs.Models
{
    public class Payment : BaseModel
    {
        [Required]
        [StringLength(32)]
        public string OrderID { get; set; } = default!;
        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; } = default!;

        [Column(TypeName = "timestamp")]
        public DateTime PaidAt { get; set; }

        [Required]
        [StringLength(32)]
        public string MethodID { get; set; } = default!;
        [ForeignKey(nameof(MethodID))]
        public virtual PaymentMethod Method { get; set; } = default!;

        [Required]
        [StringLength(30)]
        [DefaultValue(false)]
        public bool Finished { get; set; }
    }

    public class PaymentMethod : BaseModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = default!;

        [DefaultValue(true)]
        public bool Enable { get; set; }
    }
}
