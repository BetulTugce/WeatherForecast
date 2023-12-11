namespace WeatherForecast.UI.Data
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast> GetWeatherForecastAsync();
        Task<string> GetWeatherIconAsync(string iconId);
    }
}
