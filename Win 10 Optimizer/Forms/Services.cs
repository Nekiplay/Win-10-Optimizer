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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_10_Optimizer.Forms
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
        }
        private List<string> GetServisec()
        {
            Process proc = new Process()
            {
                StartInfo = new ProcessStartInfo("cmd.exe", "/c chcp 1251 & cd " + Environment.GetFolderPath(Environment.SpecialFolder.Windows) + " & sc query state= all")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };

            proc.Start();
            //proc.BeginOutputReadLine();



            string line;
            var list = new List<string>();
            //using (StreamReader sr = proc.StandardOutput)
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        line = sr.ReadLine();
            //        Console.WriteLine(line);
            //        if (!string.IsNullOrEmpty(line))
            //        {
            //            if (line.Contains("Имя_службы:"))
            //            {
            //                string id = Regex.Match(line, "Имя_службы: (.*)").Groups[1].Value;
            //                list.Add(id);
            //            }
            //        }
            //    }
            //}
            return list;
        }
        private void DeleteService(string name)
        {
            Process proc2 = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c sc delete " + name,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                }
            };
            proc2.Start();
        }
        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Services_Load(object sender, EventArgs e)
        {
            foreach (string serv in GetServisec())
            {
                Console.WriteLine(serv);
            }

        }
        public static void GetComponent(string hwclass, string syntax)
        {

        }
    }
}
