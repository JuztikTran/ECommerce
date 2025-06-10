using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjetcs.Models
{
    public class Order : BaseModel
    {
        [Required]
        [StringLength(32)]
        public string UserID { get; set; } = default!;
        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; } = default!;

        [Required]
        [StringLength(32)]
        public string AddressID { get; set; } = default!;
        [ForeignKey(nameof(AddressID))]
        public virtual Address Address { get; set; } = default!;

        [Required]
        [StringLength(32)]
        public string OptionID { get; set; } = default!;
        [ForeignKey(nameof(OptionID))]
        public virtual ProductOption ProductOption { get; set; } = default!;

        [Range(1, int.MaxValue)]
        [DefaultValue(1)]
        public int Quantity { get; set; }

        [Range(1, double.MaxValue)]
        [Column(TypeName = "money")]
        [DefaultValue(0)]
        public double Price { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "money")]
        [DefaultValue(0)]
        public double ShippingFee { get; set; }

        [Range(0, double.MaxValue)]
        [DefaultValue(0)]
        [Column(TypeName = "money")]
        public double Discount { get; set; }

        [Required]
        [DefaultValue("pending")]
        public string Status { get; set; } = default!;

        public virtual ICollection<OrderTracking> OrderTrackings { get; set; } = default!;
    }

    public class OrderTracking : BaseModel
    {
        [Required]
        [StringLength(32)]
        public string OrderID { get; set; } = default!;
        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; } = default!;

        [Column(TypeName = "timestamp")]
        public DateTime TimeTracking { get; set; }

        [Required]
        public string Status { get; set; } = default!;
    }
}
