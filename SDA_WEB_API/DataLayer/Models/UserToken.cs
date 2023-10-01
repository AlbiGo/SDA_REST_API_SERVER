using System.ComponentModel.DataAnnotations.Schema;

namespace SDA_WEB_API.DataLayer.Models
{
    public class UserToken
    {
        public int Id { get; set; }

        //User Relationship
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
