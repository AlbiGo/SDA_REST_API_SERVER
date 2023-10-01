using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDA_WEB_API.DataLayer.Models
{
    public class FaturaDaljes
    {
        [Key]
        public int ID { get; set; }
        public decimal Totali { get; set; }
        public double TVSH { get; set; }

        [ForeignKey("User")] //Foreign key to user
        public int UserID { get; set; }
        public User User { get; set; }

        public bool Completed { get; set; }
    }
}
