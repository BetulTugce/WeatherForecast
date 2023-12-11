# WeatherForecast

A weather application developed with Blazor Server using .NET 7.0. It retrieves weather information using the OpenWeatherMap API.

## Installation

1. Clone the project:

    ```bash
    git clone https://github.com/BetulTugce/WeatherForecast.git
    ```

2. Navigate to the project directory:

    ```bash
    cd WeatherForecast
    ```

3. Run the project:

    ```bash
    dotnet run
    ```

## Dependencies

- [Blazored.SessionStorage](https://github.com/Blazored/SessionStorage) v2.4.0
- [MudBlazor](https://github.com/MudBlazor/MudBlazor) v6.11.1
- [Newtonsoft.Json] v13.0.3

## Configuration

The `appsettings.json` file is not included in the repository as it contains sensitive information, such as API keys. Instead, you should create your own `appsettings.json` file with the following structure:

```json
{
  "OpenWeatherMap": {
    "ApiKey": "your_api_key_here",
    "WeatherUrl": "https://api.openweathermap.org/data/2.5/",
    "IconUrl": "https://openweathermap.org/img/w/"
  }
}
