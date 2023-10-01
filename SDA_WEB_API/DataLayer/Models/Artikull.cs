using System.ComponentModel.DataAnnotations;

namespace SDA_WEB_API.DataLayer.Models
{
    public class Artikull
    {
        [Key]
        public int Id { get; set; }
        public string Emri { get; set; }
        public string Pershkrimi { get; set; }
        public decimal Cmimi { get; set; }
    }
}
