using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherForecast.UI.Data
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration; // Konfig�rasyon bilgilerini okumak i�in

        public WeatherForecastService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        // OpenWeatherMap API'den hava durumu tahminini almak i�in..
        public async Task<WeatherForecast> GetWeatherForecastAsync()
        {
            // API anahtar� ve API'nin �a�r�laca�� url bilgisini konfig�rasyondan al�r..
            var apiKey = _configuration["OpenWeatherMap:ApiKey"];
            var weatherUrl = _configuration["OpenWeatherMap:WeatherUrl"];

            // API'ya GET iste�i g�nderiliyor..
            HttpResponseMessage response = await _httpClient.GetAsync($"{weatherUrl}weather?units=metric&lang=tr&q=istanbul&appid={apiKey}");

            // API'dan gelen yan�t ba�ar�l�ysa..
            if (response.IsSuccessStatusCode)
            {
                // API yan�t�n� okunuyor..
                var apiResponseJson = await response.Content.ReadAsStringAsync();
                // JSON yan�t� WeatherForecast s�n�f�na deserializasyon yaparak d�ner..
                var result = JsonConvert.DeserializeObject<WeatherForecast>(apiResponseJson);
                return result;
            }

            return null;
        }

        // OpenWeatherMap API'den hava durumu ikonlar�n� almak i�in..
        public async Task<string> GetWeatherIconAsync(string iconId)
        {
            // �konlar�n bulundu�u url bilgisini konfig�rasyondan al�r..
            var iconUrl = _configuration["OpenWeatherMap:IconUrl"];
            // �konun url bilgisini olu�turur..
            var _iconUrl = $"{iconUrl}{iconId}.png";

            if (_iconUrl is not null)
            {
                return _iconUrl;
            }

            return null;
        }
    }
}
