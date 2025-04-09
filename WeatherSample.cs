using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Claneder
{

  public struct WeatherSample
  {
    public int Id { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string Day { get; set; } // Changed DayStatus to string
  }
  public  class DayStatus
  {
    public  static  string Am = "Am";
    public static  string Pm = "Pm";
    public static string Na = "Na";
  }
  public class WeatherStates
  {
    public static List<WeatherSample> WeatherCollection { get; } = [];


    public static void WeatherStatesFill()
    {
      WeatherCollection.Add(new WeatherSample { Id = 800, ShortDescription = "Clear", Description = "clear sky", Image = "/Assets/weather/sun.png", Day = DayStatus.Am });
      WeatherCollection.Add(new WeatherSample { Id = 8001, ShortDescription = "Clear", Description = "clear sky", Image = "/Assets/weather/moon.png", Day = DayStatus.Pm });
      WeatherCollection.Add(new WeatherSample { Id = 801, ShortDescription = "Clouds", Description = "few clouds", Image = "/Assets/weather/sun.png", Day = DayStatus.Am });
      WeatherCollection.Add(new WeatherSample { Id = 8011, ShortDescription = "Clouds", Description = "few clouds", Image = "/Assets/weather/moon.png", Day = DayStatus.Pm });
      WeatherCollection.Add(new WeatherSample { Id = 802, ShortDescription = "Clouds", Description = "scattered clouds", Image = "/Assets/weather/sun_clouds.png", Day = DayStatus.Am });
      WeatherCollection.Add(new WeatherSample { Id = 8022, ShortDescription = "Clouds", Description = "scattered clouds", Image = "/Assets/weather/moon_clouds.png", Day = DayStatus.Pm });
      WeatherCollection.Add(new WeatherSample { Id = 803, ShortDescription = "Clouds", Description = "broken clouds", Image = "/Assets/weather/moon_clouds.png", Day = DayStatus.Pm });
      WeatherCollection.Add(new WeatherSample { Id = 8033, ShortDescription = "Clouds", Description = "broken clouds", Image = "/Assets/weather/sun_clouds.png", Day = DayStatus.Am });
      WeatherCollection.Add(new WeatherSample { Id = 804, ShortDescription = "Clouds", Description = "overcast clouds", Image = "/Assets/weather/sun_clouds.png", Day = DayStatus.Am });
      WeatherCollection.Add(new WeatherSample { Id = 8044, ShortDescription = "Clouds", Description = "overcast clouds", Image = "/Assets/weather/moon_clouds.png", Day = DayStatus.Pm });
      WeatherCollection.Add(new WeatherSample { Id = 500, ShortDescription = "Rain", Description = "light rain", Image = "/Assets/weather/NA_rain.png", Day = DayStatus.Na });
      WeatherCollection.Add(new WeatherSample { Id = 501, ShortDescription = "Rain", Description = "moderate rain", Image = "/Assets/weather/NA_rain.png", Day = DayStatus.Na });
      WeatherCollection.Add(new WeatherSample { Id = 502, ShortDescription = "Rain", Description = "heavy rain", Image = "/Assets/weather/NA_lighting.png", Day = DayStatus.Na });
      WeatherCollection.Add(new WeatherSample { Id = 511, ShortDescription = "Rain", Description = "freezing rain", Image = "/Assets/weather/NA_lighting.png", Day = DayStatus.Na });
      WeatherCollection.Add(new WeatherSample { Id = 200, ShortDescription = "Thunderstorm", Description = "thunderstorm with light rain", Image = "/Assets/weather/NA_lighting.png", Day = DayStatus.Na });
      WeatherCollection.Add(new WeatherSample { Id = 600, ShortDescription = "Snow", Description = "light snow", Image = "/Assets/weather/NA_rain_snow.png", Day = DayStatus.Na });
      WeatherCollection.Add(new WeatherSample { Id = 601, ShortDescription = "Snow", Description = "snow", Image = "/Assets/weather/NA_rain_snow.png", Day = DayStatus.Na });
      WeatherCollection.Add(new WeatherSample { Id = 701, ShortDescription = "Mist", Description = "mist", Image = "/Assets/weather/fog.png", Day = DayStatus.Na });
      WeatherCollection.Add(new WeatherSample { Id = 741, ShortDescription = "Fog", Description = "fog", Image = "/Assets/weather/fog.png", Day = DayStatus.Na });
      WeatherCollection.Add(new WeatherSample { Id = 761, ShortDescription = "Ash", Description = "ash", Image = "/Assets/weather/ash.png", Day = DayStatus.Na });
    }
    public static WeatherSample GetWeatherSample(string description, string dayStatus)
    {
      List<WeatherSample> filteredWeatherSamples = WeatherCollection.FindAll(x => x.Description == description);
      return filteredWeatherSamples.Count switch
      {
        0 => new WeatherSample
        {
          Id = 0,
          ShortDescription = "Na",
          Description = "Not Available",
          Image = "/Assets/weather/Na.png",
          Day = DayStatus.Na
        },
        1 => filteredWeatherSamples[0],
        _ => dayStatus == DayStatus.Am
          ? filteredWeatherSamples.Find(x => x.Day == DayStatus.Am)
          : filteredWeatherSamples.Find(x => x.Day == DayStatus.Pm)
      };
    }
    
  }
  public class Coord
  {
    [JsonProperty("lon")]
    public double? Lon { get; set; } = 0.0;

    [JsonProperty("lat")]
    public double? Lat { get; set; } = 0.0;
  }

  public class Weather
  {
    [JsonProperty("id")]
    public int? Id { get; set; } = 0;

    [JsonProperty("main")]
    public string Main { get; set; } = string.Empty;

    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    [JsonProperty("icon")]
    public string Icon { get; set; } = string.Empty;
  }

  public class Main
  {
    [JsonProperty("temp")]
    public double? Temp { get; set; } = 0.0;

    [JsonProperty("feels_like")]
    public double? FeelsLike { get; set; } = 0.0;

    [JsonProperty("temp_min")]
    public double? TempMin { get; set; } = 0.0;

    [JsonProperty("temp_max")]
    public double? TempMax { get; set; } = 0.0;

    [JsonProperty("pressure")]
    public int? Pressure { get; set; } = 0;

    [JsonProperty("humidity")]
    public int? Humidity { get; set; } = 0;

    [JsonProperty("sea_level")]
    public int? SeaLevel { get; set; } = 0;

    [JsonProperty("grnd_level")]
    public int? GrndLevel { get; set; } = 0;
  }

  public class Wind
  {
    [JsonProperty("speed")]
    public double? Speed { get; set; } = 0.0;

    [JsonProperty("deg")]
    public int? Deg { get; set; } = 0;
  }

  public class Clouds
  {
    [JsonProperty("all")]
    public int? All { get; set; } = 0;
  }

  public class Sys
  {
    [JsonProperty("type")]
    public int? Type { get; set; } = 0;

    [JsonProperty("id")]
    public int? Id { get; set; } = 0;

    [JsonProperty("country")]
    public string Country { get; set; } = string.Empty;

    [JsonProperty("sunrise")]
    public long? Sunrise { get; set; } = 0;

    [JsonProperty("sunset")]
    public long? Sunset { get; set; } = 0;
  }

  public class OpenWeatherResponse
  {
    [JsonProperty("coord")]
    public Coord Coord { get; set; } 

    [JsonProperty("weather")]
    public List<Weather> Weather { get; set; } = new List<Weather>();

    [JsonProperty("base")]
    public string Base { get; set; } = string.Empty;

    [JsonProperty("main")]
    public Main Main { get; set; } = new Main();

    [JsonProperty("visibility")]
    public int? Visibility { get; set; } = 0;

    [JsonProperty("wind")]
    public Wind Wind { get; set; } = new Wind();

    [JsonProperty("clouds")]
    public Clouds Clouds { get; set; } = new Clouds();

    [JsonProperty("dt")]
    public long? Dt { get; set; } = 0;

    [JsonProperty("sys")]
    public Sys Sys { get; set; } = new Sys();

    [JsonProperty("timezone")]
    public int? Timezone { get; set; } = 0;

    [JsonProperty("id")]
    public int? Id { get; set; } = 0;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("cod")]
    public int? Cod { get; set; } = 0;
  }

public class WeatherExtraInfromation
{
  public double UvIndex;
  public string? WeatherInformation;


}
}