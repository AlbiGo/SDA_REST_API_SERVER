
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ArtikullController : ControllerBase
    {
        [HttpGet("shtoartikull")]
        public async Task<IActionResult> KrijoFature([FromQuery] string emri, [FromQuery] string pershkrimi)
        {
            try
            {
               
                //dbcontext.artikujt.add(art)
                //db.savechanges()
                return new OkObjectResult(new List<Artikull>());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("shtoartikullv2")]
        public async Task<IActionResult> KrijoFature([FromBody] Artikull artikull)
        {
            try
            {
                
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// get By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getBydID")]
        public async Task<IActionResult> MerByID([FromQuery] int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
