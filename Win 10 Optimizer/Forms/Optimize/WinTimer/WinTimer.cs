using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;
using Win_10_Optimizer.Properties;

namespace Win_10_Optimizer.Forms.Optimize.WinTimer
{
    abstract public class WinTimer : INotifyPropertyChanged
    {
        private long startCount;
        private long currentCount;
        private DispatcherTimer timer;

        public event PropertyChangedEventHandler PropertyChanged;

        protected WinTimer(DispatcherTimer timer)
        {
            this.timer = timer;
            timer.Tick += Timer_Tick;

            Initialise();
        }

        protected abstract long ReadCount();
        protected abstract void InitialiseFrequency();

        public void Initialise()
        {
            InitialiseFrequency();
            OnPropertyChanged("Frequency");
        }

        public void Start()
        {
            startCount += ReadCount() - currentCount;
        }

        public void Pause()
        {
            UpdateDuration();
        }

        public void Reset()
        {
            startCount = currentCount;
            Duration = 0.0;
            OnPropertyChanged("Duration");
        }

        protected void UpdateDuration()
        {
            currentCount = ReadCount();
            Duration = ((double)(currentCount - startCount) / (double)Frequency);
            OnPropertyChanged("Duration");
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDuration();
        }

        public double Duration { get; set; }

        public long Frequency { get; set; }
    }

    /// <summary>
    /// Contains and controls (ie Stop, Start etc) two WinTimer objects.
    /// </summary>
    public class WinTimers : INotifyPropertyChanged
    {
        private readonly DispatcherTimer timer;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool RatioOk()
        {
            if (Ratio > 0.8 && Ratio < 1.2)
            {
                return true;
            }
            return false;
        }

        private void CalculateRatio()
        {
            if (TickCounter.Duration == 0)
            {
                Ratio = 0;
            }
            else
            {
                Ratio = PerfCounter.Duration / TickCounter.Duration;
            }
            OnPropertyChanged("Ratio");
        }

        protected void Timer_Tick(object sender, EventArgs e)
        {
            CalculateRatio();
        }

        public WinTimers()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;

            PerfCounter = new PerformanceCounter(timer);
            TickCounter = new TickCounter(timer);
        }

        public void Start()
        {
            PerfCounter.Start();
            TickCounter.Start();
            timer.Start();
        }

        public void Pause()
        {
            PerfCounter.Pause();
            TickCounter.Pause();
            timer.Stop();
        }

        public void Reset()
        {
            PerfCounter.Reset();
            TickCounter.Reset();
            CalculateRatio();
        }

        public void Log()
        {
            double perfFrequency = PerfCounter.Frequency;
            double perfDuration = PerfCounter.Duration;
            double tickDuration = TickCounter.Duration;
            double ratio = Ratio;
            Trace.TraceInformation("*********" + DateTime.Now.ToString(CultureInfo.InvariantCulture) + "*********");
            Trace.TraceInformation("QueryPerformanceFrequency: {0}", perfFrequency);
            Trace.TraceInformation("QueryPerformanceCounter: {0}", perfDuration);
            Trace.TraceInformation("GetTickCount: {0}", tickDuration);
            Trace.TraceInformation("Ratio: {0}", ratio);
            if (!RatioOk())
            {
                Trace.TraceError("Ratio outside of limits");
            }
            Trace.Flush();
        }

        public PerformanceCounter PerfCounter { get; set; }

        public TickCounter TickCounter { get; set; }

        public Double Ratio { get; set; }

        public bool AutoTestEnabled { get; set; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
