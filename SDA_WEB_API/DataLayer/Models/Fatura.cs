using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDA_WEB_API.DataLayer.Models
{
    public class Fatura
    {
        [Key]
        public int ID { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("Artikull")] //Same as Artikull in 12 row
        public int ArtikullID { get; set; }
        public Artikull Artikull { get; set; }
        public int Sasia { get; set; }

        [ForeignKey("FaturaDaljes")]
        public int FaturaDaljesID { get; set; }
        public FaturaDaljes FaturaDaljes { get; set; }
    }
}
