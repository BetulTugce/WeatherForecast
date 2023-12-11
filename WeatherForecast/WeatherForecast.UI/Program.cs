using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using System.Net;
using WeatherForecast.UI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

// API ile ileti�im kurmak i�in servis eklendi.
builder.Services.AddHttpClient();

// Uygulaman�n konfig�rasyonunu olu�turuyor. appsettings.json dosyas�ndaki ayarlar� y�kler.
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Uygulaman�n genelinde ayn� konfig�rasyon nesnesinin kullan�lmas�n� sa�lar..
builder.Services.AddSingleton<IConfiguration>(configuration);

//IWeatherForecastService aray�z�n� WeatherForecastService s�n�f�na ba�lar ve istemci taraf�ndan bir istek yap�ld���nda yeni bir WeatherForecastService �rne�i olu�turulmas�n� sa�lar..
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

//var apiKey = configuration["OpenWeatherMap:ApiKey"];
//var weatherUrl = configuration["OpenWeatherMap:WeatherUrl"];
//var iconUrl = configuration["OpenWeatherMap:IconUrl"];

//builder.Services.AddHttpClient<WeatherForecastService>(options =>
//{
//    options.BaseAddress = new Uri(builder.Configuration["WeatherUrl"]);
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
