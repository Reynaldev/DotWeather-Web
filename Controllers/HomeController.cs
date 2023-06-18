using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DotWeather_Web.Models;

namespace DotWeather_Web.Controllers;

public class HomeController : Controller
{
    HttpClient _httpClient = new HttpClient();

    static List<UserLocation> _location = new List<UserLocation>();
    static OpenWeather _weather = new OpenWeather();

    HttpResponseMessage _response;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Forecast()
    {
        if (_location.Count > 0)
        {
            WeatherData weatherData = new WeatherData()
            {
                location = _location[0],
                weather = _weather
            };

            return View(weatherData);
        }
        else
        {
            return View();
        }
    }

    [HttpGet("geo/{loc}")]
    public async Task<IActionResult> GetLocation(string loc)
    {
        _response = await _httpClient.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={loc}&limit=5&appid=18ccbbd129b7bdecaaf072a9f9977f01");

        if (!_response.IsSuccessStatusCode)
            return NotFound();

        string content = await _response.Content.ReadAsStringAsync();
        _location = JsonSerializer.Deserialize<List<UserLocation>>(content);

        return RedirectToAction("GetWeather", new { lat = _location[0].lat, lon = _location[0].lon });
        // return $"{_location[0].name}";
    }

    [HttpGet("data/{lat}/{lon}")]
    public async Task<IActionResult> GetWeather(double lat, double lon)
    {
        _response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&units=metric&appid=18ccbbd129b7bdecaaf072a9f9977f01");
            
        if (!_response.IsSuccessStatusCode)
            return NotFound();

        string content = await _response.Content.ReadAsStringAsync();
        _weather = JsonSerializer.Deserialize<OpenWeather>(content);

        return RedirectToPage("Index");
        // return $"{_weather.current.temp}";
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
