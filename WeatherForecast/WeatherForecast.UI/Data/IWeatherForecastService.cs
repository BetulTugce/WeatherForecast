namespace WeatherForecast.UI.Data
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast> GetWeatherForecastAsync(string city);
        Task<WeatherForecast> GetWeatherForecastAsync(double lat, double lon);
        Task<string> GetWeatherIconAsync(string iconId);
    }
}
