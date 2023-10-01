using Microsoft.EntityFrameworkCore;
using SDA_WEB_API.BusinessLayer.Interfaces;
using SDA_WEB_API.DataLayer;
using SDA_WEB_API.DataLayer.Models;
using System.Text.RegularExpressions;

namespace SDA_WEB_API.BusinessLayer.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly OnlineBuyDBContext _onlineBuyDBContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        //Contructor
        public UserAccountService(OnlineBuyDBContext onlineBuyDBContext, 
            IHttpContextAccessor httpContextAccessor)
        {
            _onlineBuyDBContext = onlineBuyDBContext;
            _httpContextAccessor = httpContextAccessor;
        }

        private void PasswordValidator(string password)
        {
            //password should not be like this
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (regexItem.IsMatch(password))
            {
                throw new Exception("Password is not valid");
            }
        }

        public async Task Register(User user)
        {
            try
            {
                var exists = await _onlineBuyDBContext.Users
                    .Where(p => p.Email == user.Email)
                    .FirstOrDefaultAsync();

                PasswordValidator(user.Password);

                if (exists != null)
                {
                    throw new Exception("This user already exists");
                }
                await _onlineBuyDBContext.Users.AddAsync(user);
                await _onlineBuyDBContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<int> GetLoggerUser()
        {
            try
            {
                var token = _httpContextAccessor.HttpContext.Request.Headers["token"];

                if (string.IsNullOrEmpty(token))
                    throw new Exception("Token missing please log in");

                var user = await _onlineBuyDBContext.UsersToken
                    .Where(p => p.Token == token.ToString() &&
                           p.Expires > DateTime.Now)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new Exception("Token expired please re login");
                }

                return user.UserID;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> LogIn(string email, string password)
        {
            try
            {
                var user = await _onlineBuyDBContext.Users
                    .Where(p => p.Password == password && 
                                p.Email == email &&
                                p.IsActive == true)
                    .FirstOrDefaultAsync();

                if (user == null) 
                {
                    throw new Exception("Authentication Failed");
                }

                var token = GenerateToken();

                await _onlineBuyDBContext.UsersToken.AddAsync(new UserToken()
                {
                    Token = token,
                    UserID = user.ID,
                    Expires = DateTime.Now.AddDays(5)
                });
                await _onlineBuyDBContext.SaveChangesAsync();

                return token;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private string GenerateToken()
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string token = string.Empty;

            for (int i = 0; i<= 20; i ++)
            {
                var random = new Random();
                int index = random.Next(25);
                var character = alphabet[index];
                token = token + character;
            }
            return token;
        }
    }
}
