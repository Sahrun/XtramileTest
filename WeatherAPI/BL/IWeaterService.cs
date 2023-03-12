using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAPI.Model;
using WeatherAPI.Model.Weather;

namespace WeatherAPI.BL
{
    public interface IWeaterService
    {

        List<Country> Countries(string search);
        List<City> Cities(string search);
        Task<WeatherForecastView> GetWeather(string qury);
        float ConverToFahrenheit(float temperature);
        float ConverToCencius(float temperature);
    }


    public class WeaterService : IWeaterService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IHttpClientFactory HttpClientFactory { get; }

        public WeaterService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<Country> Countries(string search)
        {


            string filePath = $"{Environment.CurrentDirectory}\\Data\\country.list.json";

            IEnumerable<Country> Countries = Enumerable.Empty<Country>();
            List<Country> result = new List<Country>();

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                Countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
            }

            if (!String.IsNullOrEmpty(search))
            {
                result = Countries.Where(x => x.Name.Contains(search)).ToList();
            }
            else
            {
                result = Countries.ToList();
            }

            return result;
        }

        public List<City> Cities(string search)
        {
            string filePath = $"{Environment.CurrentDirectory}\\Data\\city.list.json";

            IEnumerable<City> cities = Enumerable.Empty<City>();
            List<City> result = new List<City>();

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                cities = JsonConvert.DeserializeObject<IEnumerable<City>>(json);
            }

            if (!String.IsNullOrEmpty(search))
            {
                result = cities.Where(x => x.Country.Contains(search)).ToList();
            }
            else
            {
                result = cities.ToList();
            }



            return result;
        }

        public async Task<WeatherForecastView> GetWeather(string query)
        {


            WeatherForecastObject jsonObject = new WeatherForecastObject();
            WeatherForecastView result = new WeatherForecastView();
            try
            {

                if (string.IsNullOrEmpty(query))
                {

                    throw new Exception("city or contry is not valid!");
                }

                var httpRequestMessage = new HttpRequestMessage(
                  HttpMethod.Get,query);

                var httpClient = _httpClientFactory.CreateClient();
                var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string _jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

                    jsonObject = JsonConvert.DeserializeObject<WeatherForecastObject>(_jsonResult);

                    jsonObject.fahrenheit = ConverToFahrenheit(jsonObject.main.temp);
                    jsonObject.celsius = ConverToCencius(jsonObject.main.temp);
                }

                result = new WeatherForecastView
                {
                    name = jsonObject.name,
                    timezone = jsonObject.timezone,
                    wind = jsonObject.wind.speed,
                    visibility = jsonObject.visibility,
                    sky = jsonObject.weather[0].description,
                    celsius = ConverToCencius(jsonObject.main.temp),
                    fahrenheit = ConverToFahrenheit(jsonObject.main.temp),
                    dewPoint = jsonObject.clouds.all,
                    humidity = jsonObject.main.humidity,
                    pressure = jsonObject.main.pressure,

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public float ConverToFahrenheit(float temperature)
        {

            float fahrenheit = ((temperature - 273.15f) + 32) * 1.8f;

            return fahrenheit;
        }

        public float ConverToCencius(float temperature)
        {

            float celcius = temperature - 273.15f;

            return celcius;
        }
    }

}
