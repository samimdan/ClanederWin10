#region

using System.Diagnostics;
using System.Windows;

#endregion

namespace Claneder;

public sealed partial class MainWindow : Window
{
    private static ManualResetEvent _suspendEvent = new(true);
    private static Stopwatch _stopwatch = new();
    private Thread _worker;

    private void TimerToggled(object sender, RoutedEventArgs e)
    {
        _worker = new Thread(WorkTimer);
        _worker.Start();
        _stopwatch.Start();


        ResumeThread();
    }

    private void TimerToggledOff(object sender, RoutedEventArgs e)
    {
        SuspendThread();
        _stopwatch.Stop();
    }


    private void WorkTimer()
    {
        while (true)
        {
            _suspendEvent.WaitOne();
            // Add your timer logic here  
            Thread.Sleep(1000); // Simulate work  
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