using Aspose.Pdf;
using Microsoft.AspNetCore.Mvc;

namespace AsposePdfDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Test")]
        public FileContentResult Test()
        {
            MemoryStream output = new MemoryStream();
            HtmlLoadOptions options = new HtmlLoadOptions();
            Document pdfDocument = new Document("asd.html", options);
            pdfDocument.Save(output);

            FileContentResult fileContentResult = new FileContentResult(output.ToArray(), "application/pdf")
            {
                FileDownloadName = "Dekont.pdf",
            };

            return fileContentResult;
        }
    }
}
