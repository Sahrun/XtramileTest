using Newtonsoft.Json;

namespace WeatherAPI.Model
{
    public class Country
    {

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
