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

// API ile iletiþim kurmak için servis eklendi.
builder.Services.AddHttpClient();

// Uygulamanýn konfigürasyonunu oluþturuyor. appsettings.json dosyasýndaki ayarlarý yükler.
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Uygulamanýn genelinde ayný konfigürasyon nesnesinin kullanýlmasýný saðlar..
builder.Services.AddSingleton<IConfiguration>(configuration);

//IWeatherForecastService arayüzünü WeatherForecastService sýnýfýna baðlar ve istemci tarafýndan bir istek yapýldýðýnda yeni bir WeatherForecastService örneði oluþturulmasýný saðlar..
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
