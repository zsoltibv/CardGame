using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace CardGame
{
    internal class TimerService
    {
        private static Timer timer;

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // This method will be called every time the timer elapses
            Console.WriteLine("Timer elapsed at {0}", e.SignalTime);
        }

        public static void SetTimerInterval(int interval)
        {
            timer.Interval = interval;
        }

        public static void StartTimer()
        {
            timer.Start();
        }

        public static void StopTimer()
        {
            timer.Stop();
        }
    }
}
