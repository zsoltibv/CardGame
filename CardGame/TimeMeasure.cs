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

        public TimeMeasure()
        {
        }

        public TimeMeasure(int totalTimeMinutes)
        {
            TotalTimeInSeconds = totalTimeMinutes * 60;
            Stopwatch = new Stopwatch();
        }

        public TimeMeasure(TimeMeasure t) {
            TotalTimeInSeconds = t.TotalTimeInSeconds;
            Stopwatch = t.Stopwatch;
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
                int remainingTimeSeconds = TotalTimeInSeconds - (int)Stopwatch.Elapsed.TotalSeconds;
                return TimeSpan.FromSeconds(remainingTimeSeconds);
            }
        }
    }
}
