namespace DotWeather_Web.Models;

public class UserLocation
{
    public string? name { get; set; }
    public double? lon { get; set; }
    public double? lat { get; set; }
}

public class OpenWeather
{
    public Current? current { get; set; }
    public double? lat { get; set; }
    public double? lon { get; set; }
    public string? timezone { get; set; }
}

public class Current
{
    public List<Weather>? weather { get; set; }
    public int? pressure { get; set; }
    public int? humidity { get; set; }
    public double? temp { get; set; }
    public double? wind_speed { get; set; }
    public double? uvi { get; set; }
}

public class Weather
{
    public int? id { get; set; }
    public string? main { get; set; }
    public string? description { get; set; }
    public string? icon { get; set; }
}

public class WeatherData
{
    public UserLocation? location { get; set; }
    public OpenWeather? weather { get; set; }
}