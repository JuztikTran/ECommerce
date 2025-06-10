using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjetcs.Models
{
    public class Account : IdentityUser
    {
        [Key]
        [StringLength(32)]
        public string ID { get; set; } = Guid.NewGuid().ToString("N");

        [DefaultValue(false)]
        public bool IsBanned { get; set; }
        public string? ReasonBan { get; set; }

        [StringLength(10)]
        [DefaultValue("user")]
        public string Role { get; set; } = default!;
    }
}
