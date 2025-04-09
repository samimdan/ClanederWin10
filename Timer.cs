using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace Claneder
{
    public sealed partial class MainWindow : Window
    {

        public static DispatcherTimer Timer { get; } = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

        private void TimerStart()
        {

            Timer.Tick += (sender, e) =>
            {
                Time.Hour = DateTime.Now.Hour;
                Time.Minute = DateTime.Now.Minute;
                Time.Second = DateTime.Now.Second;
                int hour = DateTime.Now.Hour % 12;
                Time.DayNightIndicator = DateTime.Now.Hour >= 12 ? "Pm" : "Am";
                if (hour == 0) hour = 12;
                                
                HourTb.Text = hour.ToString();
                MinuteTb.Text = DateTime.Now.ToString("mm");
                SecondTb.Text = DateTime.Now.ToString("ss");

             
                CheckAzan();
                CheckHour();
                CheckMidNigth();
            };
            Timer.Start();
        }

        private void CheckMidNigth()
        {
            if (Time.Hour == 0 && Time.Minute == 0 && Time.Second == 0)
            {
                PopulateDateInfo();

            }
        }

        private void CheckHour()
        {
            if (Time.Minute == 0 && Time.Second == 0)
            {
                PlaySound(SoundType.Hour);
                PopulateWeatherInfo();
            }

        }


        private void CheckAzan()
        {
            if (Time.Hour == HollyTime.MorningHollyTime.Hour && Time.Minute == HollyTime.MorningHollyTime.Minute && Time.Second == 0)
            {
                PlaySound(SoundType.Azan);
               
            }
            else if (Time.Hour == HollyTime.EveningHollyTime.Hour && Time.Minute == HollyTime.EveningHollyTime.Minute && Time.Second == 0)
            {
                PlaySound(SoundType.Azan);
            }
            else if (Time.Hour == HollyTime.AfternoonHollyTime.Hour && Time.Minute == HollyTime.AfternoonHollyTime.Minute && Time.Second == 0)
            {
                PlaySound(SoundType.Azan);
                Time.DayNightIndicator = "Pm";
            }
            else if (Time.Hour > HollyTime.MorningHollyTime.Hour && Time.Hour < HollyTime.AfternoonHollyTime.Hour)
            {

            }

      
        }
        internal class Time()
        {
            public static int Hour { get; set; }
            public static int Minute { get; set; }
            public static int Second { get; set; }
            public static string DayNightIndicator { get; set; }
           
            }
        }

    }
