#region

using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#endregion

namespace Claneder;

public sealed partial class MainWindow : Window
{
    private static ManualResetEvent _suspendEvent = new(true);
    private static Stopwatch _stopwatch = new();
    private Thread _worker;

    // Assuming StopWatchTimerTb is a TextBlock control


    private void TimerToggled(object sender, RoutedEventArgs e,bool timerToggled)
    {
        _worker = new Thread(WorkTimer);
        switch (timerToggled)
        {
            case true:
                SuspendThread();
                _stopwatch.Stop();
                break;
            case false:
                _worker.Start();
                _stopwatch.Start();
                ResumeThread();
                break;
        }
    }
    private void TimerRestart(object sender, RoutedEventArgs e)
    {
        _stopwatch.Reset();
        StopWatchTimerTb.Text = "00:00:00";
    }
    private void TimerToggledOff(object sender, RoutedEventArgs e)
    {
      
    }

    private void WorkTimer()
    {
        while (true)
        {
            _suspendEvent.WaitOne();
            // Add your timer logic here  
            Thread.Sleep(1000); // Simulate work  
            Dispatcher.Invoke(() =>
            {
                StopWatchTimerTb.Text = _stopwatch.Elapsed.ToString("hh\\:mm\\:ss");
            });
        }
    }

    private void SuspendThread()
    {
        _suspendEvent.Reset();
    }

    private void ResumeThread()
    {
        _suspendEvent.Set();
    }
}
