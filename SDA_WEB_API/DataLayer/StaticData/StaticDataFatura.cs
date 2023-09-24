using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.DataLayer.StaticData
{
    public static class StaticDataFatura
    {
        public static List<Artikull> MerrArtikujt()
        {
            return new List<Artikull>()
            {
                new Artikull()
                {
                    Id = 1,
                    Emri = "PC",
                    Pershkrimi = "Electronic Device"
                },
                 new Artikull()
                {
                    Id = 2,
                    Emri = "TV",
                    Pershkrimi = "Electronic Device"
                },
                 new Artikull()
                {
                    Id = 3,
                    Emri = "iPhone",
                    Pershkrimi = "Electronic Device"
                }
            };


        }
        public static List<Fatura> MerrFaturat()
        {
            return new List<Fatura>()
            {
                new Fatura() 
                {
                    ArtikullID = 3,
                    Cmimi = 30,
                    Sasia = 234
                },
                new Fatura()
                {
                    ArtikullID = 8,
                    Cmimi = 30,
                    Sasia = 234
                },
                new Fatura()
                {
                    ArtikullID = 3,
                    Cmimi = 30,
                    Sasia = 234
                },
                new Fatura()
                {
                    ArtikullID = 6,
                    Cmimi = 30,
                    Sasia = 234
                },
                new Fatura()
                {
                    ArtikullID = 7,
                    Cmimi = 30,
                    Sasia = 234
                }
            };
        }
    }
}
