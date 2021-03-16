﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Forms.Optimize
{
    public class DNSSettings
    {
        public List<DNS> DNSList = new List<DNS>
        {
            new DNS("1.1.1.1*1.0.0.1", "AU", "CloudFlare"),
            new DNS("77.88.8.1*77.88.8.8", "RU", "Yandex"),
            new DNS("8.8.4.4*8.8.8.8", "US", "Google Public DNS"),
            new DNS("156.154.71.1*156.154.70.1", "US", "Neustar 1"),
            new DNS("208.67.220.222*208.67.222.220", "US", "OpenDNS - 2"),
            new DNS("64.6.65.6*64.6.64.6", "US", "VerSign Public DNS"),
            new DNS("156.154.71.22*156.154.70.22", "US", "Comodo"),
            new DNS("156.154.70.5*156.154.71.5", "US", "Neustar 2"),
            new DNS("74.82.42.42", "US", "Hurricane Electric"),
            new DNS("7199.85.126.10*199.85.127.10", "US", "Norton ConnectionSafe Basic"),
            new DNS("204.69.234.1*204.74.101.1", "US", "Ultra DNS"),
            new DNS("198.153.192.1*198.153.194.1", "US", "Norton DNS"),
            new DNS("149.112.112.112*9.9.9.9", "US", "Quad9 Security"),
            new DNS("4.2.2.4*4.2.2.3", "US", "Level 3 - C"),
            new DNS("84.200.70.40*84.200.69.80", "US", "DNS Watch"),
            new DNS("209.244.0.3*209.244.0.4", "US", "Level 3 - A"),
            new DNS("176.103.130.131*176.103.130.130", "RU", "AdGuard"),
        };

        public async Task<DNS> GetBestDNSAsync()
        {
            List<Task> asyncs = new List<Task>();
            DNS best = DNSList.FirstOrDefault();
            Tuple<long, long> templat = new Tuple<long, long>(-1, -1);
            foreach (DNS dns in DNSList)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    Tuple<long, long> lat = dns.GetLatency(dns.dns);
                    if (templat.Item1 == 99999999999 && templat.Item2 == 99999999999)
                    {
                        templat = lat;
                        best = dns;
                    }
                    else
                    {
                        if (templat.Item1 > lat.Item1 && templat.Item2 > lat.Item2)
                        {
                            best = dns;
                        }
                    }
                });
                asyncs.Add(temp);
            }
            foreach (Task t in asyncs)
            {
                await t;
            }
            return best;
        }

        public class DNS
        {

            public string dns;
            public string countiry;
            public string company_or_name;
            public long latency_res;
            public long latency_sen;

            public DNS(string dns, string countury, string company_or_name)
            {
                this.dns = dns;
                this.countiry = countiry;
                this.company_or_name = company_or_name;
            }
            public Tuple<long, long> GetLatency(string dnss)
            {
                long firsttime = 99999999999;
                long doubletime = 99999999999;
                try
                {
                    Ping p1 = new Ping();
                    PingReply r1 = p1.Send(dnss.Split('*')[0]);
                    if (r1.Status == IPStatus.Success)
                    {
                        firsttime = r1.RoundtripTime;
                    }
                }
                catch { }

                try
                {
                    Ping p2 = new Ping();
                    PingReply r2 = p2.Send(dnss.Split('*')[1]);
                    if (r2.Status == IPStatus.Success)
                    {
                        doubletime = r2.RoundtripTime;
                    }
                }
                catch { }
                return new Tuple<long, long>(firsttime, doubletime);
            }

            public void Set()
            {
                SetDNS(this.dns);
            }

            public static NetworkInterface GetActiveEthernetOrWifiNetworkInterface()
            {
                var Nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
                    a => a.OperationalStatus == OperationalStatus.Up &&
                    (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                    a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

                return Nic;
            }
            public static void UnsetDNS()
            {
                var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
                if (CurrentInterface == null) return;

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();
                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Caption"].ToString().Contains(CurrentInterface.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            if (objdns != null)
                            {
                                objdns["DNSServerSearchOrder"] = null;
                                objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                            }
                        }
                    }
                }
            }
            private void SetDNS(string DnsString)
            {
                string[] Dns = DnsString.Split('*');
                foreach (string d in Dns)
                {
                    Console.WriteLine(d);
                }
                var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
                if (CurrentInterface == null) return;

                ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection objMOC = objMC.GetInstances();
                foreach (ManagementObject objMO in objMOC)
                {
                    if ((bool)objMO["IPEnabled"])
                    {
                        if (objMO["Caption"].ToString().Contains(CurrentInterface.Description))
                        {
                            ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                            objdns["DNSServerSearchOrder"] = Dns;
                            objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                    }
                }
            }
        }
    }
}