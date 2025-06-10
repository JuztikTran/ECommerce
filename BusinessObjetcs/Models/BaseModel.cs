using System.ComponentModel.DataAnnotations;

namespace BusinessObjetcs.Models
{
    public class BaseModel
    {
        [Key]
        [StringLength(32)]
        public string ID { get; set; } = Guid.NewGuid().ToString("N");
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}
