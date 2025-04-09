using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Claneder
{
    public sealed partial class MainWindow : Window
    {
        private string DayIndicator()
        {
            int hour = DateTime.Now.Hour;
            int morningHt = HollyTime.MorningHollyTime.Hour;
            int afternoonHt = HollyTime.AfternoonHollyTime.Hour;
            if (hour > morningHt && hour < afternoonHt)
            {
                return "Am";
            }
            if (hour > afternoonHt)
                return "Pm";
            return "Na";
        }

        public void PopulateWeatherInfo()
        {
            WeatherStates.WeatherStatesFill();
            OpenWeatherResponse weatherResponse = Task.Run(async () => await GetDatafromApi.GetWeatherDataAsync("Hamedan")).Result;
            if (weatherResponse.Main.Temp != null) TempTb.Text = weatherResponse.Main.Temp?.ToString("0.0") + "°";
            if (weatherResponse.Main.Humidity != null) HumidityTb.Text = weatherResponse.Main.Humidity?.ToString();
            if (weatherResponse.Wind.Speed != null) WindTb.Text = Math.Round(Tools.MileToKm(weatherResponse.Wind.Speed.Value), 1).ToString(CultureInfo.CurrentCulture);
            WeatherExtraInfromation weatherExtraInfromation = Task.Run(async () => await GetDatafromApi.GetWeatherExtraInfromation("Hamedan")).Result;

            WeatherSample fillterdWeatherSamples = WeatherStates.GetWeatherSample(weatherResponse.Weather[0].Description, DayIndicator());
            String imagePath = $"pack://application:,,,{fillterdWeatherSamples.Image}";
            Debug.WriteLine(imagePath);
            WeatherIcon.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));

            if (weatherExtraInfromation.UvIndex != 0) UvTb.Text = weatherExtraInfromation.UvIndex.ToString();
            if (weatherExtraInfromation.WeatherInformation != null)
            {
                WeatherDescriptionTb.Text = weatherExtraInfromation.WeatherInformation;
                
            }
        }
    }
}
    
