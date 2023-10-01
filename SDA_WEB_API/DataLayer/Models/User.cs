using System.ComponentModel.DataAnnotations;

namespace SDA_WEB_API.DataLayer.Models
{
    public class User
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
