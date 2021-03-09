﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
            Forms.EnergyOptimize.Energy energy = new Forms.EnergyOptimize.Energy();
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
            Forms.EnergyOptimize.Gybernate gybernate = new Forms.EnergyOptimize.Gybernate();
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
                RegistryKey reg = Registry.LocalMachine;
                RegistryKey Interfaces = reg.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters\Interfaces");
                string[] names = Interfaces.GetSubKeyNames();
                foreach (string name in names)
                {
                    RegistryKey kk = Interfaces.OpenSubKey(name);
                    if (kk.GetValue("TcpAckFrequency") != null && kk.GetValue("TcpNoDelay") != null
                    && kk.GetValue("TcpAckFrequency").ToString() == "1" 
                    && kk.GetValue("TcpNoDelay").ToString() == "1"
                    && kk.GetValue("NameServer") != null
                    && kk.GetValue("DhcpDomain") != null
                    && kk.GetValue("DhcpDomain").ToString() == "lan"
                    )
                    {
                        enabled = true;
                    }
                    RegistryKey Software = reg.OpenSubKey(@"Software\Microsoft\MSMQ\Parameters", false);
                    if (Software.GetValue("TcpNoDelay") == null
                    || Software.GetValue("TcpNoDelay").ToString() != "1"
                    )
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
                Forms.EnergyOptimize.Energy energy = new Forms.EnergyOptimize.Energy();
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
                Forms.EnergyOptimize.Gybernate gybernate = new Forms.EnergyOptimize.Gybernate();
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
                    /* Включение по документаций Microsoft */
                    RegistryKey Software = reg.OpenSubKey(@"Software\Microsoft\MSMQ\Parameters", true);
                    Software.SetValue("TcpNoDelay", 1);
                    Software.SetValue("TcpAckFrequency", 1);
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
                    /* Удаление по документаций Microsoft */
                    RegistryKey Software = reg.OpenSubKey(@"Software\Microsoft\MSMQ\Parameters", true);
                    Software.DeleteValue("TcpNoDelay");
                    Software.DeleteValue("TcpAckFrequency");
                }
            });
        }
    }
}