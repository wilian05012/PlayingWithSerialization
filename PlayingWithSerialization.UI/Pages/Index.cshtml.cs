using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlayingWithSerialization.Api.Client;

namespace PlayingWithSerialization.UI.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApiClient _weatherApiClient;

        public IndexModel(ILogger<IndexModel> logger, ApiClientService apiClientService) {
            _logger = logger;
            _weatherApiClient = apiClientService.WeatherApiClient;
        }

        public IEnumerable<WeatherForecast> WeatherForecasts { get; set; } = Array.Empty<WeatherForecast>();
        
        [BindProperty]
        public WeatherForecast Correction { get;  } = new WeatherForecast() {
            Date = DateTime.Now,
            TemperatureC = 32,
            Summary = WeatherSummary.Chilling
        };

        public static IEnumerable<SelectListItem> GetSummaryOptions() => 
            Enum.GetNames(typeof(WeatherSummary)).Select((name, index) => new SelectListItem(
                text: name, 
                value: index.ToString()
            ));
        public async Task OnGetAsync() {
            _logger.LogInformation("Retrieving weather forecast from ....{0}", _weatherApiClient.BaseUrl);
            WeatherForecasts = await _weatherApiClient.GetWeatherForecastAsync();
        }

        public async Task<IActionResult> OnPostAsync() {
            try {
                await _weatherApiClient.PostWeatherForecastAsync(Correction);
                return RedirectToAction(nameof(OnGetAsync));
            } catch(Exception e) {
                _logger.LogError(e, e.Message);

                return Page();
            }
        }
    }
}
