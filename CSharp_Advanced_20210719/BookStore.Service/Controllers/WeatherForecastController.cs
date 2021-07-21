using BookStore.Service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] //ProducesResponseType sagt, welche Http-Status Codes eine Methode ausgeben kann
        [ProducesResponseType(StatusCodes.Status303SeeOther)] //Geben an, dass in dieser Methode auch eine Umleitung eingebaut ist
        public IEnumerable<WeatherForecast> Get()
        {
            PositionOptions posOpt = new();
            _configuration.GetSection(PositionOptions.stringPiosition).Bind(posOpt);


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetById/{Id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public WeatherForecast GetById(int Id)
        {
            return new WeatherForecast() { Date = DateTime.Now, Summary = "Regen", TemperatureC = 12 };
        }

        [HttpGet("GetByIdVarianteB/{Id?}")]
        public IActionResult GetById(int? Id)
        {
            //IActionResult ermöglicht StatusCode + DatenInhalt als Ergebnis zurück zu senden
            if (!Id.HasValue)
                return BadRequest("id not found");

            return Ok(new WeatherForecast() { Date = DateTime.Now, Summary = "Regen", TemperatureC = 12 });
        }

        [HttpGet("Search")]
        public IActionResult Search(string namelike)
        {
            bool isMatch = true;


            if (isMatch)
                return Ok(new WeatherForecast() { Date = DateTime.Now, Summary = "Regen", TemperatureC = 12 });


            return NotFound(namelike);
        }

        [HttpPost("AddWeather")] //Insert
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public void InsertOrUpdate(WeatherForecast weatherForecast) //Von Json -> Object (Casting) nennt man ModelBinding
        {
        }


        
    }
}
