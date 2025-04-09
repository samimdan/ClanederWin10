#region

using System;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


#endregion

namespace Claneder;

internal class GetDatafromApi
{
    public static async   Task<DateInfo> FetchDataContentAsync()
    {
        const string url = "https://api.keybit.ir/time/";

        try
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage timeApiResponseStatus = await httpClient.GetAsync(url);
            if (!timeApiResponseStatus.IsSuccessStatusCode)
                return new DateInfo
                {
                    DateText = "00",
                    MonthText = "00",
                    DayText = "00",
                   
                };
            string timeApiResponse = await timeApiResponseStatus.Content.ReadAsStringAsync();
            ShamsiDate? shamsiDate = JsonConvert.DeserializeObject<ShamsiDate>(timeApiResponse);

            // Assuming you have logic to extract the required fields from shamsiDate
         
            DateInfo? dateInfo = new DateInfo
            {
                
                DateText = shamsiDate?.Date.Day.Number.En ?? throw new InvalidOperationException(),
                MonthText = shamsiDate?.Date.Month.Name ?? throw new InvalidOperationException(),
                DayText = shamsiDate?.Date.Weekday.Name ?? throw new InvalidOperationException(),
             
            };
            return dateInfo;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching data: {ex.Message}");
            return new DateInfo
            {
                DateText = "00",
                MonthText = "00",
                DayText = "00",
              
            };
        }
    }
    public static async Task<HollyTimes> GetHollyTimesAsync()
    {
        const string city = "همدان";
        const string url = $"https://api.keybit.ir/owghat/?city={city}";
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage hollyTimesResponseMessage = await httpClient.GetAsync(url);

        var hollyTimesResponse = await hollyTimesResponseMessage.Content.ReadAsStringAsync();
        HollyTimeResult? hollyTimesResponseMessageObject = JsonConvert.DeserializeObject<HollyTimeResult>(hollyTimesResponse);

        return new HollyTimes
        {
            MorningHollyTime = new MorningHollyTime
            {

                Hour = int.Parse(hollyTimesResponseMessageObject?.Result.AzanSobh.Split(":")[0] ?? throw new InvalidOperationException()),
                Minute = int.Parse(hollyTimesResponseMessageObject?.Result.AzanSobh.Split(":")[1] ?? throw new InvalidOperationException())
            },
            EveningHollyTime = new EveningHollyTime
            {
                Hour = int.Parse(hollyTimesResponseMessageObject?.Result.AzanZohr.Split(":")[0] ?? throw new InvalidOperationException()),
                Minute = int.Parse(hollyTimesResponseMessageObject?.Result.AzanZohr.Split(":")[1] ?? throw new InvalidOperationException())
            },
            AfternoonHollyTime = new AfternoonHollyTime
            {
                Hour = int.Parse(hollyTimesResponseMessageObject?.Result.AzanMaghreb.Split(":")[0] ?? throw new InvalidOperationException()),
                Minute = int.Parse(hollyTimesResponseMessageObject?.Result.AzanMaghreb.Split(":")[1] ?? throw new InvalidOperationException())
            }

        };





        


    } 

    public static async Task<OpenWeatherResponse> GetWeatherDataAsync(string cityName)
    {
        const string apiKey = "eb56f50ab7a5ef07ba1e5165eeef8da7"; // Replace with your API key
        const string baseUrl = "https://api.openweathermap.org/data/2.5/weather";
        using var client = new HttpClient();
        var url = $"{baseUrl}?q={cityName}&units=metric&appid={apiKey}";
        var weatherResponse = new OpenWeatherResponse();
        try
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                dynamic? json = await response.Content.ReadAsStringAsync();
                OpenWeatherResponse? deserializedWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(json);

                weatherResponse = deserializedWeather ?? throw new Exception("Failed to get weather.");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching weather data: {ex.Message}");
            return new OpenWeatherResponse
            {
                Id = 0,
                Main = new Main(), // Initialize Main object properly

                Wind = new Wind()
            };
        }



        return weatherResponse;
    }
    public static async Task<WeatherExtraInfromation> GetWeatherExtraInfromation(string cityName)
    {
        WeatherExtraInfromation weatherExtraInfromation=new WeatherExtraInfromation();
        const string uVApiKey = "S8VLXMD9R3FE7FRCHFQN396RU";
        dynamic? uVUrl =
            $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{cityName}?unitGroup=us&key={uVApiKey}&contentType=json";

        using var uVClient = new HttpClient();
        try
        {
            var response = await uVClient.GetAsync(uVUrl);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                dynamic? uVObject = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());
                dynamic? uVIndexNode = uVObject?.days?[0]?.uvindex;
            
                dynamic? description = uVObject?.description;
                

               weatherExtraInfromation =new WeatherExtraInfromation { UvIndex = uVIndexNode, WeatherInformation = description };
            }
              return weatherExtraInfromation;
    }

        
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching UV index data: {ex.Message}");
            return new WeatherExtraInfromation { UvIndex=0,WeatherInformation="0"};
        }
        
    }
}