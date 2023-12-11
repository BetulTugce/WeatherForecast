namespace WeatherForecast.UI.Data
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast> GetWeatherForecastAsync(string city);
        Task<string> GetWeatherIconAsync(string iconId);
    }
}
