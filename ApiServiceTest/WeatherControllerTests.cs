
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
    public class WeatherControllerTests : IDisposable
    {

        private static readonly HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:44344") };


        public WeatherControllerTests()
        {

        }

        public void Dispose()
        {
            _httpClient.DeleteAsync("/state").GetAwaiter().GetResult();
        }

        [Theory]
        [InlineData("ID", "Indramayu")]
        public async Task Request_GetWeather_country_ID_city_jakarta_ThenTheAPIReturnsExpectedResponse(string country, string city)
        {

            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            var jsonMediaType = "application/json";

            var expectedContent =
            new WeatherForecastView
            {
                name = "Indramayu",
                timezone = 25200,
                wind = 2.17f,
                visibility = 10000,
                sky = "overcast clouds",
                celsius = 25.6700134f,
                fahrenheit = 103.806023f,
                dewPoint = 93,
                humidity = 84,
                pressure = 1011
            };

            // Act.
            var response = await _httpClient.GetAsync("/api/weatherforecast/GetWeather?city=" + city + "&country=" + country + "");

            Assert.Equal(expectedStatusCode, response.StatusCode);


            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(jsonMediaType, response.Content.Headers.ContentType?.MediaType);
            Assert.Equal(expectedContent, await JsonSerializer.DeserializeAsync<WeatherForecastView>(
                await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }));

        }


    }

}
