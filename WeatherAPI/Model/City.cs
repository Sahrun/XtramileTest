using Newtonsoft.Json;

namespace WeatherAPI.Model
{

    public class City
    {
        [JsonProperty("id")]
        public decimal Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("coord")]
        public Coord Coord { get; set; }
    }

    public class Coord
    {
        [JsonProperty("lon")]
        public float Lon { get; set; }
        [JsonProperty("lat")]
        public float Lat { get; set; }
    }


}
