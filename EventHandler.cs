using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Claneder
{
    sealed partial class MainWindow:Window 
    {
        public static bool TimerToggeled = false;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            WindowAppearanceUtilities.EnableBlur(this);
            WindowAppearanceUtilities.SetWindowTopMost(this);
           
        }
        private void StartBlinking(string text) { }
        //{
        //   BlinkingText.Text = text;
        //    BlinkingText.Visibility = Visibility.Visible;
        //    BlinkingText.Opacity = 0;
        //    BlinkingText.BeginAnimation(UIElement.OpacityProperty, new System.Windows.Media.Animation.DoubleAnimation(0, 1, TimeSpan.FromSeconds(1))
        //    {
        //        AutoReverse = true,
        //        RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever
        //    });
        
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            StartBtn.Content = TimerToggeled ? "Start" : "Stop";
            TimerToggled(sender, e,TimerToggeled);
            TimerToggeled = !TimerToggeled;
        }
        private void ResetTimer_Click(object sender, RoutedEventArgs e)
        {
            TimerRestart(sender, e);

        }

    }
}
