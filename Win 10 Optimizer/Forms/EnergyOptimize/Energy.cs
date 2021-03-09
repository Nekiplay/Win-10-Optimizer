using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Forms.EnergyOptimize
{
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

}
