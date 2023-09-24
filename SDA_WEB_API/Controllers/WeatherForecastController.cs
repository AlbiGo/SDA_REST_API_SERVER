using Microsoft.AspNetCore.Mvc;

namespace SDA_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpDelete("deletesummary")]
        public async Task<IActionResult> DeleteSummary(int index)
        {
            try
            {
                var summaries = Summaries.ToList();
                summaries.RemoveAt(index);
                return new OkObjectResult(summaries);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("addsummary")]
        public async Task<IActionResult> AddSummary(string summary)
        {
            try
            {
                var summaries = Summaries.ToList();
                summaries.Add(summary);
                return new OkObjectResult(summaries);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(string summary)
        {
            try
            {
                var summaries = Summaries.ToList();
                var index = -1;
                int i = 0;
                foreach (var su in summaries)
                {
                    if (su == summary)
                    {
                        //Index where update is found
                        index = i;
                        break;
                    }
                    i++;
                }
                if (index != -1)
                {
                    summaries.RemoveAt(index);
                    summaries.Insert(index,"Not Cool");
                    return new OkObjectResult(summaries);
                }
                else
                {
                    return StatusCode(500, "Th property cannot be found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}