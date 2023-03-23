using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class TimeMeasure
    {
        public Stopwatch Stopwatch { get; set; }
        public int TotalTimeInSeconds { get; set; }
        public int RemainingTimeInSeconds { get; set; }

        public TimeMeasure()
        {
        }

        public TimeMeasure(int seconds)
        {
            TotalTimeInSeconds = seconds;
            Stopwatch = new Stopwatch();
        }

        public void Start()
        {
            Stopwatch.Start();
        }

        public void Stop()
        {
            Stopwatch.Stop();
        }

        public TimeSpan RemainingTime
        {
            get
            {
                RemainingTimeInSeconds = TotalTimeInSeconds - (int)Stopwatch.Elapsed.TotalSeconds;
                return TimeSpan.FromSeconds(RemainingTimeInSeconds);
            }
        }
    }
}
