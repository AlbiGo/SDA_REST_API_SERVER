
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDA_WEB_API.DataLayer.Models;
using SDA_WEB_API.DataLayer.StaticData;

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
                var artikujt = StaticDataFatura.MerrArtikujt();
                var art = new Artikull()
                {
                    Emri = emri,
                    Pershkrimi = pershkrimi
                };
                artikujt.Add(art);
                //dbcontext.artikujt.add(art)
                //db.savechanges()
                return new OkObjectResult(artikujt);
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
                var artikujt = StaticDataFatura.MerrArtikujt();
                artikujt.Add(artikull);
                return new OkObjectResult(artikujt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("getBydID")]
        public async Task<IActionResult> MerByID([FromQuery] int id)
        {
            try
            {
                var art = StaticDataFatura.MerrArtikujt()
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

                if (art == null)
                {
                    return StatusCode(500, "Artikulli su gjet");
                }
                return new OkObjectResult(art);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
