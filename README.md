# Configuring and API Endpoint to Correctly Handle Enumerations
This project uses the resulting project from the Web API template and changes 
the default Weather Summary string constants into a Enumeration type.
````
public enum WeatherSummary {
    Freezing, Bracing, Chilling, Cool, Mild, Warm, Balmy, Hot, Sweltering, Scorching
}


public class WeatherForecast {
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    [JsonPropertyName("Summary")]
    public WeatherSummary Summary { get; set; }
}
````

Creates a client class in a separate library project that will also handle correctly the enumeration.

Test the generated client in a Web Application that will get and post data from the API
using the correspoding client exposed methods.