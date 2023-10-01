using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.BusinessLayer.Interfaces
{
    public interface IUserAccountService
    {
        public Task Register(User user);
        public Task<string> LogIn(string email, string password);
        public Task<int> GetLoggerUser();
    }
}
