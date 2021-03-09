using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Forms.EnergyOptimize
{
    public class Gybernate
    {
        public bool Activated()
        {
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/c chcp 1251 & powercfg /a")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };

            proc.Start();

            string line;
            using (StreamReader sr = proc.StandardOutput)
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.Contains("Режим гибернации не включен"))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public void Enable(bool on)
        {
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/c chcp 1251 & powercfg /h " + on.ToString().Replace("True", "on").Replace("False", "off"))
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            proc.Start();
        }
    }
}
