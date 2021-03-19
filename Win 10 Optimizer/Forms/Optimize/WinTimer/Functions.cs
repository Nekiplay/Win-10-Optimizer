using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Forms.Optimize.WinTimer
{
    public class Functions
    {
        public WinTimers WinTimers;
        public Functions()
        {
            WinTimers = new WinTimers();
        }
        public void Start()
        {
            WinTimers.Start();
        }
        public void Pause()
        {
            WinTimers.Pause();
        }
        public void Reset()
        {
            WinTimers.Reset();
        }
    }
}
