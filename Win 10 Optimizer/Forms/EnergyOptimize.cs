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
        }

        private void EnergyOptimize_Load_1(object sender, EventArgs e)
        {
            /* Проверка максимальной производительности */
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
            /* Проверка гибернаций */
            Gybernate gybernate = new Gybernate();
            Task.Factory.StartNew(() =>
            {
                bool on = gybernate.Activated();
                bunifuCheckbox2.Invoke(new MethodInvoker(() =>
                {
                    bunifuCheckbox2.Checked = !on;
                }));
            });
            /* Проверка алгоритма нейгла */
            Task.Factory.StartNew(() =>
            {
                bool enabled = false;
                /* Проверка по документаций Microsoft */
                RegistryKey reg = Registry.LocalMachine;
                RegistryKey Interfaces = reg.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces");
                string[] names = Interfaces.GetSubKeyNames();
                foreach (string name in names)
                {
                    RegistryKey kk = Interfaces.OpenSubKey(name);
                    object value2 = kk.GetValue("TcpAckFrequency");
                    object value3 = kk.GetValue("TcpNoDelay");
                    if (value2 != null && value3 != null && value2.ToString() == "1" && value3.ToString() == "1")
                    {
                        enabled = true;
                    }
                    else
                    {
                        enabled = false;
                    }
                }
                bunifuCheckbox3.Invoke(new MethodInvoker(() =>
                {
                    bunifuCheckbox3.Checked = enabled;
                }));
            });
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Energy energy = new Energy();
                energy.Enable(bunifuCheckbox1.Checked);
                if (!bunifuCheckbox1.Checked)
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

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                RegistryKey reg = Registry.LocalMachine;
                if (bunifuCheckbox3.Checked)
                {
                    /* Включение в интерфейсах */
                    RegistryKey Interfaces = reg.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces", true);
                    string[] names = Interfaces.GetSubKeyNames();
                    foreach (string name in names)
                    {
                        RegistryKey keys = Interfaces.OpenSubKey(name, true);
                        keys.SetValue("TcpNoDelay", 1);
                        keys.SetValue("TcpAckFrequency", 1);
                    }
                }
                else
                {
                    /* Удаление в интерфейсах */
                    RegistryKey Interfaces = reg.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces", true);
                    string[] names = Interfaces.GetSubKeyNames();
                    foreach (string name in names)
                    {
                        RegistryKey keys = Interfaces.OpenSubKey(name, true);
                        keys.DeleteValue("TcpNoDelay");
                        keys.DeleteValue("TcpAckFrequency");
                    }
                }
            });
        }
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
                        {
                            list.Add(new Tuple<string, string, bool>(id, type, true));
                        }
                        else
                        {
                            list.Add(new Tuple<string, string, bool>(id, type, false));
                        }
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
                    {
                        SetActiv(standart);
                    }
                    Delete(s.Item1);
                }
            }
        }
    }
}
