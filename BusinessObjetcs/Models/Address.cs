using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjetcs.Models
{
    public class Address : BaseModel
    {
        [Required]
        [StringLength(32)]
        public string UserID { get; set; } = default!;
        [ForeignKey(nameof(UserID))]
        public virtual User User { get; set; } = default!;

        [Required]
        [StringLength(20)]
        public string Receiver { get; set; } = default!;

        [Required]
        [StringLength(150)]
        public string Location { get; set; } = default!;

        [Required]
        [StringLength(15)]
        [Phone]
        public string Phonenumber { get; set; } = default!;

        public string? Note { get; set; }
    }
}
