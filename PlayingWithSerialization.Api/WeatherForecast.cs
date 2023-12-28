using System.Text.Json.Serialization;

namespace PlayingWithSerialization.Api {
    public class WeatherForecast {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [JsonPropertyName("Summary")]
        public WeatherSummary Summary { get; set; }
    }
}
