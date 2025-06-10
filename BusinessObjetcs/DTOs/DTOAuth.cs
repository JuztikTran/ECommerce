using System.ComponentModel.DataAnnotations;

namespace BusinessObjetcs.DTOs
{
    public class DTOAuth
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }
}
