using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace Claneder
{
    public sealed partial class MainWindow:Window
    {
       public  static  HollyTimes HollyTime { get; set; }
        public void PopulateDateInfo()
        {
            
             HollyTime=Task.Run(async ()=> await GetDatafromApi.GetHollyTimesAsync()).Result;
             var shamsiDate= Task.Run(async () => await GetDatafromApi.FetchDataContentAsync()).Result;
            MorningHolyHourTb.Text = "0" + HollyTime.MorningHollyTime.Hour.ToString();
            MorningHolyMinTb.Text = HollyTime.MorningHollyTime.Minute.ToString();
            EveningHolyHourTb.Text = Tools.Convert24To12(HollyTime.EveningHollyTime.Hour).ToString();
            EveningHolyMinTb.Text = HollyTime.EveningHollyTime.Minute.ToString();
            AfterNoonHolyHourTb.Text = "0"+Tools.Convert24To12(HollyTime.AfternoonHollyTime.Hour).ToString();
            AfterNoonHolyMinTb.Text ="0"+ HollyTime.AfternoonHollyTime.Minute.ToString();
            TodayChDateTb.Text = ChrisitianDate.ChDay.ToString();
            MonthChDateTb.Text = ChrisitianDate.ChMonth.ToString();
            MonthChDateTextTb.Text = ChrisitianDate.ChMonthName;
            DayNumTb.Text =shamsiDate.DateText;
            DayOfWeekTb.Text = shamsiDate.DayText;
            MonthTb.Text = shamsiDate.MonthText;
        }
    }
}
