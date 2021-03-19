using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace Win_10_Optimizer.Forms.Optimize.WinTimer
{
    public class PerformanceCounter : WinTimer
    {
        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(
            out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        public PerformanceCounter(DispatcherTimer timer) : base(timer)
        {
        }

        protected override long ReadCount()
        {
            long count;
            QueryPerformanceCounter(out count);
            return count;
        }

        protected override void InitialiseFrequency()
        {
            long freq;
            QueryPerformanceFrequency(out freq);
            Frequency = freq;
        }
    }
}
