using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Claneder
{
    internal class Tools
    {
        

        public static string ConvertPersianToEnglish(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var persianDigits = new[] { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };

            for (var i = 0; i < persianDigits.Length; i++)
            {
                input = input.Replace(persianDigits[i], i.ToString()[0]);
            }

            return input;
        }
        public static double MileToKm(double mile)
        {
            return (mile * 1.60934);
        }
        //conver 24 hour to 12 hour return int 
        public static int Convert24To12(int hour)
        {
            return hour switch
            {
                0 => 12,
                > 12 => hour - 12,
                _ => hour
            };
        }

      

      
    }
}

