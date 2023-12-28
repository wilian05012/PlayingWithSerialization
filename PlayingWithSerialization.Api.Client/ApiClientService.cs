namespace PlayingWithSerialization.Api.Client {
    public class ApiClientService {
        public ApiClient WeatherApiClient { get; }
        public ApiClientService(string apiBaseUrl) {
            WeatherApiClient = new ApiClient(apiBaseUrl, new HttpClient());
        }
    }
}
