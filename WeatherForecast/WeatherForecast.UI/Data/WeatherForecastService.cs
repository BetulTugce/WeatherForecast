using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherForecast.UI.Data
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration; // Konfigürasyon bilgilerini okumak için

        public WeatherForecastService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // OpenWeatherMap API'den hava durumu tahminini almak için..
        public async Task<WeatherForecast> GetWeatherForecastAsync()
        {
            // API anahtarý ve API'nin çaðrýlacaðý url bilgisini konfigürasyondan alýr..
            var apiKey = _configuration["OpenWeatherMap:ApiKey"];
            var weatherUrl = _configuration["OpenWeatherMap:WeatherUrl"];

            // API'ya GET isteði gönderiliyor..
            HttpResponseMessage response = await _httpClient.GetAsync($"{weatherUrl}weather?units=metric&lang=tr&q=istanbul&appid={apiKey}");

            // API'dan gelen yanýt baþarýlýysa..
            if (response.IsSuccessStatusCode)
            {
                // API yanýtýný okunuyor..
                var apiResponseJson = await response.Content.ReadAsStringAsync();
                // JSON yanýtý WeatherForecast sýnýfýna deserializasyon yaparak döner..
                var result = JsonConvert.DeserializeObject<WeatherForecast>(apiResponseJson);
                return result;
            }

            return null;
        }

        // OpenWeatherMap API'den hava durumu ikonlarýný almak için..
        public async Task<string> GetWeatherIconAsync(string iconId)
        {
            // Ýkonlarýn bulunduðu url bilgisini konfigürasyondan alýr..
            var iconUrl = _configuration["OpenWeatherMap:IconUrl"];
            // Ýkonun url bilgisini oluþturur..
            var _iconUrl = $"{iconUrl}{iconId}.png";

            if (_iconUrl is not null)
            {
                return _iconUrl;
            }

            return null;
        }
    }
}
