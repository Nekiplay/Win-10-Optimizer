using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Win_10_Optimizer.Forms.Optimize.WinTimer
{
    /// <summary>
    /// A timer class based around the GetTickCount() call
    /// </summary>
    public class TickCounter : WinTimer
    {
        [DllImport("KERNEL32")]
        private static extern uint GetTickCount();

        public TickCounter(DispatcherTimer timer) : base(timer)
        {
        }

        protected override long ReadCount()
        {
            return GetTickCount();
        }

        protected override void InitialiseFrequency()
        {
            Frequency = 1000; // 1 tick = 1 millisecond
        }
    }
}
