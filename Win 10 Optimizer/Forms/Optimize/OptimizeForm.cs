using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_10_Optimizer.Forms
{
    public partial class OptimizeForm : Form
    {
        public OptimizeForm()
        {
            InitializeComponent();
        }
        private void EnergyOptimize_Load_1(object sender, EventArgs e)
        {
            /* Проверка отличного DNS */
            Task.Factory.StartNew(async () =>
            {
                Forms.Optimize.DNSSettings DNSSettings = new Optimize.DNSSettings();
                Forms.Optimize.DNSSettings.DNS bestdns = DNSSettings.GetBestDNSAsync().Result;
                try
                {
                    if (Forms.Optimize.DNSSettings.DNS.GetActiveEthernetOrWifiNetworkInterface().GetIPProperties().DnsAddresses.ToArray()[0].ToString() == bestdns.dns.Split('*')[0] && Forms.Optimize.DNSSettings.DNS.GetActiveEthernetOrWifiNetworkInterface().GetIPProperties().DnsAddresses.ToArray()[1].ToString() == bestdns.dns.Split('*')[1])
                    {
                        bunifuCheckbox4.Invoke(new MethodInvoker(() =>
                        {
                            bunifuCheckbox4.Checked = true;
                        }));
                    }
                }
                catch { }
            });
            /* Проверка максимальной производительности */
            Forms.EnergyOptimize.EnergyClass energy = new Forms.EnergyOptimize.EnergyClass();
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
                    }
                }
            });
            /* Проверка гибернаций */
            Forms.EnergyOptimize.GybernateClass gybernate = new Forms.EnergyOptimize.GybernateClass();
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
                    )
                    {
                        enabled = true;
                    }
                    RegistryKey Software = reg.OpenSubKey(@"Software\Microsoft\MSMQ\Parameters", false);
                    if (Software == null)
                    {
                        reg.CreateSubKey(@"Software\Microsoft\MSMQ\Parameters");
                    }
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
                Forms.EnergyOptimize.EnergyClass energy = new Forms.EnergyOptimize.EnergyClass();
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
                Forms.EnergyOptimize.GybernateClass gybernate = new Forms.EnergyOptimize.GybernateClass();
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

                    new Utilites.ProcessUtils().StartCmd("netsh interface ip delete arpcache" 
                        + " & netsh winsock reset catalog"
                        + " & netsh int ip reset c:resetlog.txt"
                        + " & netsh int ip reset C:\tcplog.txt"
                        + " & netsh winsock reset catalog"
                        + " & netsh int tcp set global rsc=enabled"
                        + " & netsh int tcp set heuristics disabled"
                        + " & netsh int tcp set global dca=enabled"
                        + " & netsh int tcp set global netdma=enabled"
                        );
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

        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox4.Checked)
            {
                Task.Factory.StartNew(async () =>
                {
                    Forms.Optimize.DNSSettings DNSSettings = new Optimize.DNSSettings();
                    Forms.Optimize.DNSSettings.DNS bestdns = await DNSSettings.GetBestDNSAsync();
                    bestdns.Set();
                    NotificationManager.Manager notify = new NotificationManager.Manager();
                    notify.MaxTextWidth = 400;
                    notify.EnableOffset = false;
                    notify.Alert("Установлен DNS: " + bestdns.company_or_name + " (" + bestdns.dns.Replace("*", ", ") + ")", NotificationManager.NotificationType.Info);
                    notify.StopTimer(1000);
                });
            }
            else
            {
                Forms.Optimize.DNSSettings.DNS.UnsetDNS();
            }
        }
    }
}