using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.BusinessLayer.Interfaces
{
    public interface IeBuyService
    {
        public Task AddToCart(Fatura fatura, int userID);
    }
}
