using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_10_Optimizer.Forms
{
    public partial class EnergyOptimize : Form
    {
        public EnergyOptimize()
        {
            InitializeComponent();
            new Thread(() =>
            {
                while (true)
                {
                    if (true == true)
                    {
                        int cpu = (int)(process_cpu.NextValue());
                        if (cpu != 0 && cpu != cpuold)
                        {
                            if (cpu == 100)
                                cpu = 99;
                            cpuold = cpu;
                            try
                            {
                                bunifuCircleProgressbar1.Invoke(new MethodInvoker(() =>
                                {
                                    bunifuCircleProgressbar1.Value = cpu;
                                }));
                            } catch { }
                            Thread.Sleep(1);
                        }
                    }
                    if (true == true)
                    {
                        ManagementObjectSearcher ramMonitor =    //запрос к WMI для получения памяти ПК
                    new ManagementObjectSearcher("SELECT TotalVisibleMemorySize,FreePhysicalMemory FROM Win32_OperatingSystem");

                        foreach (ManagementObject objram in ramMonitor.Get())
                        {
                            ulong totalRam = Convert.ToUInt64(objram["TotalVisibleMemorySize"]);    //общая память ОЗУ
                            ulong busyRam = totalRam - Convert.ToUInt64(objram["FreePhysicalMemory"]);         //занятная память = (total-free)
                            try
                            {
                                bunifuCircleProgressbar2.Invoke(new MethodInvoker(() =>
                                {
                                    bunifuCircleProgressbar2.Value = (int)((busyRam * 100) / totalRam);
                                }));
                            } catch { }
                            //Console.WriteLine(((busyRam * 100) / totalRam));       //вычисляем проценты занятой памяти
                        }
                    }
                    Thread.Sleep(1000);
                }
            }).Start();
        }

        private void EnergyOptimize_Load_1(object sender, EventArgs e)
        {
            Energy energy = new Energy();
            Task.Factory.StartNew(() =>
            {
                List<Tuple<string, string, bool>> schems = energy.ListSchemes();
                foreach (var s in schems)
                {
                    if (s.Item2 == "Максимальная производительность" && s.Item3)
                    {
                        bunifuCheckbox1.Invoke(new MethodInvoker(() =>
                        {
                            bunifuCheckbox1.Checked = true;
                        }));
                        energy.Delete(s.Item1);
                    }
                }
            });
            Gybernate gybernate = new Gybernate();
            Task.Factory.StartNew(() =>
            {
                bool on = gybernate.Activated();
                bunifuCheckbox2.Invoke(new MethodInvoker(() =>
                {
                    bunifuCheckbox2.Checked = !on;
                }));
            });
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Energy energy = new Energy();
                energy.Enable(bunifuCheckbox1.Checked);
                if (bunifuCheckbox1.Checked)
                {

                }
                else
                {
                    bunifuCheckbox1.Invoke(new MethodInvoker(() =>
                    {
                        bunifuCheckbox1.Checked = false;
                    }));
                }
            });
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Gybernate gybernate = new Gybernate();
                gybernate.Enable(!bunifuCheckbox2.Checked);
            });
        }
        public static string GetComponent(string hwclass, string syntax)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mo in mos.Get())
            {
                return mo[syntax].ToString();
            }
            return "";
        }
        int cpuold;
        PerformanceCounter process_cpu = new PerformanceCounter(
                                   "Процессор",
                                   "% загруженности процессора",
                                   "_Total"
                                        );
    }
}
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
        var list = new List<Tuple<string, string, bool>>();
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
public class Energy
{
    public List<Tuple<string, string, bool>> ListSchemes()
    {
        Process proc = new Process()
        {
            StartInfo = new ProcessStartInfo("cmd.exe", "/c chcp 1251 & powercfg /L")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }
        };

        proc.Start();

        string line;
        var list = new List<Tuple<string, string, bool>>();
        using (StreamReader sr = proc.StandardOutput)
        {
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    if (line.Contains("GUID"))
                    {
                        line = line.Replace(" (", "&");
                        line = line.Replace(")", "&");
                        string type = Regex.Match(line, "&(.*)&").Groups[1].Value;
                        string id = Regex.Match(line, "GUID схемы питания: (.*) &").Groups[1].Value;
                        if (line.Contains("*"))
                            list.Add(new Tuple<string, string, bool>(id, type, true));
                        else
                            list.Add(new Tuple<string, string, bool>(id, type, false));
                    }
                }
            }
        }
        return list;
    }
    public string CreateMaximum()
    {
        Process proc = new Process()
        {
            StartInfo = new ProcessStartInfo("cmd.exe", "/c chcp 1251 & powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61")
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            }
        };

        proc.Start();

        string line;
        var list = new List<Tuple<string, string>>();
        using (StreamReader sr = proc.StandardOutput)
        {
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    if (line.Contains("GUID"))
                    {
                        line = line.Replace(" (", "&");
                        line = line.Replace(")", "&");
                        string id = Regex.Match(line, "GUID схемы питания: (.*) &").Groups[1].Value;
                        return id;
                    }
                }
            }
        }
        return "";
    }
    public void SetActiv(string id)
    {
        Process proc2 = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c powercfg -SETACTIVE " + id,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
            }
        };
        proc2.Start();
    }
    public void Delete(string id)
    {
        Process proc2 = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c powercfg /d " + id,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
            }
        };
        proc2.Start();
    }
    public void Enable(bool on)
    {
        List<Tuple<string, string, bool>> schems = ListSchemes();
        if (on)
        {
            bool find = false;
            foreach (var s in schems)
            {
                if (s.Item2 == "Максимальная производительность")
                {
                    find = true;
                    SetActiv(s.Item1);
                    break;
                }
            }
            if (!find)
            {
                string id = CreateMaximum();
                if (!string.IsNullOrEmpty(id))
                {
                    SetActiv(id);
                }
            }
        }
        else
        {
            string standart = "";
            foreach (var s in schems)
            {
                if (s.Item2 == "Сбалансированная")
                {
                    SetActiv(s.Item1);
                    standart = s.Item1;
                }
            }
            foreach (var s in schems)
            {
                if (s.Item2 == "Максимальная производительность")
                {
                    if (!string.IsNullOrEmpty(standart))
                        SetActiv(standart);
                    Delete(s.Item1);
                }
            }
        }
    }
}
