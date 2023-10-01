using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDA_WEB_API.BusinessLayer.Interfaces;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.Controllers
{
    [Route("api/v1.2/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public AccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                await _userAccountService.Register(user);

                return StatusCode(200);
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string password )
        {
            try
            {
                var result = await _userAccountService.LogIn(email, password);
                return new OkObjectResult(result); 
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
