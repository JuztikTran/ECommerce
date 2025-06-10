using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjetcs.Models
{
    public class User : BaseModel
    {
        [Required]
        [StringLength(150)]
        public string FullName { get; set; } = default!;

        public string Avatar { get; set; } = default!;

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required]
        [DefaultValue("unknow")]
        public string Gender { get; set; } = default!;

        [ForeignKey(nameof(ID))]
        public virtual Account Account { get; set; } = default!;

        public virtual ICollection<Address> Addresses { get; set; } = default!;
    }
}
