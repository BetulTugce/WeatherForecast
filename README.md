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
- [BrowserInterop] v1.1.2

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
```

## Screenshot

*If permission is granted for location information:*

![WeatherForecast](https://github.com/BetulTugce/WeatherForecast/assets/79140478/cccfd7b8-1dcd-4fa1-a9d2-f18c045cf688)

*If permission is not granted for location information:*

![WeatherForecast](https://github.com/BetulTugce/WeatherForecast/assets/79140478/b5acbd41-d225-4b62-a8b8-388cbcf44cbf)


