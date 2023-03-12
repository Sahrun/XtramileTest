using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAPI.BL;
using WeatherAPI.Model.Weather;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeaterService _weaterService;
        private readonly string _openweatherBaseURL;
        private readonly string _openweatherAppId;
        private IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeaterService weaterService,IConfiguration configuration)
        {
            _logger = logger;
            _weaterService = weaterService;
            _configuration = configuration;
            _openweatherBaseURL = this._configuration.GetSection("OpenweatherBaseURL").Value;
            _openweatherAppId = this._configuration.GetSection("OpenweatherAppId").Value;

        }


        [HttpGet(Name = "GetWeather/{city}/{country}")]
        public async Task<IActionResult> GetWeather(string city, string country)
        {
            WeatherForecastView jsonResult = new WeatherForecastView();
            try
            {
                string qury = $"{_openweatherBaseURL}?q={city},{country}&appid={_openweatherAppId}";
                jsonResult = await _weaterService.GetWeather(qury);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(jsonResult);
        }

        [HttpGet(Name = "GetCountries/{search}")]
        public IActionResult GetCountries(string search)
        {
            var Countries = _weaterService.Countries(search);

            return Ok(Countries);

        }

        [HttpGet(Name = "GetCities/{search}")]
        public IActionResult GetCities(string search)
        {
            var Countries = _weaterService.Cities(search);

            return Ok(Countries);

        }

        [HttpGet(Name = "Convert")]
        public IActionResult Convert()
        {
            var Countries = _weaterService.ConverToFahrenheit(300.25f);

            return Ok(Countries);

        }

    }
}
