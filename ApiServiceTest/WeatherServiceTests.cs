
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherAPI.BL;
using WeatherAPI.Model.Weather;
using Xunit;

namespace ApiServiceTest
{
    public class WeatherServiceTests
    {

        private static readonly HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/weather") };
        private readonly Mock<IHttpClientFactory> _httpClientFactory;

        private readonly IWeaterService _service;

        public WeatherServiceTests()
        {
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _service = new WeaterService(_httpClientFactory.Object);
        }

        [Theory]
        [InlineData("ID", "Jakarta")]
        public async Task Request_GetWeather_Service_CountryIDCityJakarta(string country, string city)
        {

            var expectedStatusCode = System.Net.HttpStatusCode.OK;


            var response = await _httpClient.GetAsync("?q=" + city + "," + country + "&appid=1d12aa37baa8e0cee75bb42acc519968");
            var resultContent = await JsonSerializer.DeserializeAsync<WeatherForecastObject>(
                await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = false });

            float fahrenheit_expected = ((resultContent.main.temp - 273.15f) + 32) * 1.8f;
            float celcius_expected = resultContent.main.temp - 273.15f;

            float fahrenheit_actual = _service.ConverToFahrenheit(resultContent.main.temp);
            float celcius_actual = _service.ConverToCencius(resultContent.main.temp);


            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(fahrenheit_expected, fahrenheit_actual);
            Assert.Equal(celcius_expected, celcius_actual);

        }




    }

}
