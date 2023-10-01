using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDA_WEB_API.BusinessLayer.Interfaces;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.Controllers
{
    [Route("api/v1.2/[controller]")]
    [ApiController]
    public class eBuyController : ControllerBase
    {
        private readonly IeBuyService _ieBuyService;
        private readonly IUserAccountService _userAccountService;

        public eBuyController(IeBuyService ieBuyService, 
            IUserAccountService userAccountService)
        {
            _ieBuyService = ieBuyService;
            _userAccountService = userAccountService;
        }

        [HttpPost]
        [Route("addtocart")]
        public async Task<IActionResult> AddToCart([FromBody] FaturaDTO fatura)
        {
            try
            {
                //Get Logged User ID
                var userID = await _userAccountService.GetLoggerUser();

                //Add to cart
                await _ieBuyService.AddToCart(new Fatura()
                    {
                        ArtikullID = fatura.ArtikullID,
                        Created = fatura.Created,
                        Sasia = fatura.Sasia
                    }, userID);
                return Ok();    
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public class FaturaDTO
        {
            public int ArtikullID { get; set; }
            public int Sasia { get; set; }
            public DateTime Created { get; set; }
        }

    }
}
