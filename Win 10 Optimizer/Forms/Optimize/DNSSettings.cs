using System;
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
            /* Русские DNS */
            /* Rostelecom */
            new DNS("213.24.238.26*8.8.8.8", "RU", "Rostelecom"),
            new DNS("213.24.237.210*8.8.8.8", "RU", "Rostelecom"),
            new DNS("212.58.212.83*8.8.8.8", "RU", "Rostelecom"),
            new DNS("195.46.112.170*8.8.8.8", "RU", "Rostelecom"),
            new DNS("109.172.10.70*8.8.8.8", "RU", "Rostelecom"),
            new DNS("91.122.77.189*8.8.8.8", "RU", "Rostelecom"),
            new DNS("85.175.46.122*8.8.8.8", "RU", "Rostelecom"),
            new DNS("84.54.226.50*8.8.8.8", "RU", "Rostelecom"),
            new DNS("82.208.99.185*8.8.8.8", "RU", "Rostelecom"),
            /* PVimpelCom */
            new DNS("212.46.234.217*8.8.8.8", "RU", "PVimpelCom"),
            new DNS("195.239.36.27*8.8.8.8", "RU", "PVimpelCom"),
            new DNS("195.14.50.21*8.8.8.8", "RU", "PVimpelCom"),
            new DNS("89.179.83.118*8.8.8.8", "RU", "PVimpelCom"),
            new DNS("83.69.120.1*8.8.8.8", "RU", "PVimpelCom"),
            new DNS("81.211.96.62*8.8.8.8", "RU", "PVimpelCom"),
            new DNS("80.243.64.67*8.8.8.8", "RU", "PVimpelCom"),
            /* Yandex */
            new DNS("77.88.8.88*8.8.8.8", "RU", "YANDEX LLC"),
            new DNS("77.88.8.81*8.8.8.8", "RU", "YANDEX LLC"),
            new DNS("77.88.8.3*8.8.8.8", "RU", "YANDEX LLC"),
            new DNS("77.88.8.2*8.8.8.8", "RU", "YANDEX LLC"),
            new DNS("77.88.8.1*8.8.8.8", "RU", "YANDEX LLC"),
            /* MTS */
            new DNS("95.104.194.3*8.8.8.8", "RU", "MTS PJSC"),
            new DNS("80.71.178.68*8.8.8.8", "RU", "MTS PJSC"),
            new DNS("62.168.251.166*8.8.8.8", "RU", "MTS PJSC"),
            /* Other */
            new DNS("84.237.112.130*8.8.8.8", "RU", "Federal Research Center for Information and Computational Technologies"),
            new DNS("62.113.51.133*8.8.8.8", "RU", "SFT Company"),
            new DNS("212.75.208.170*8.8.8.8", "RU", "E-Light-Telecom Ltd"),
            new DNS("178.210.42.50*8.8.8.8", "RU", "KVANT-TELEKOM Closed Joint Stock Company"),
            new DNS("195.98.79.117*8.8.8.8", "RU", "Ic-voronezh82.208.99.185"),
            new DNS("31.204.180.44*8.8.8.8", "RU", "Unknow"),
            new DNS("195.191.183.60*8.8.8.8", "RU", "MediaNet Ltd"),
            new DNS("84.244.59.15*8.8.8.8", "RU", "Unknow"),
            new DNS("62.122.101.59*8.8.8.8", "RU", "Unknow"),
            new DNS("195.112.96.34*8.8.8.8", "RU", "MAXnet Systems Ltd"),
            new DNS("217.150.35.129*8.8.8.8", "RU", "Joint Stock Company TransTeleCom"),
            new DNS("195.69.65.98*8.8.8.8", "RU", "BILLING SOLUTION Ltd"),
            new DNS("37.29.119.100*8.8.8.8", "RU", "PJSC MegaFon"),
            new DNS("195.208.5.1*8.8.8.8", "RU", "Unknow"),
            new DNS("46.16.229.223*8.8.8.8", "RU", "JSC Elektrosvyaz"),
            new DNS("77.95.89.99*8.8.8.8", "RU", "Speckless Enterprise Ltd"),
            new DNS("94.100.86.238*8.8.8.8", "RU", "Unknow"),
            new DNS("91.205.3.65*8.8.8.8", "RU", "Joint Stock Company TransTeleCom"),
            new DNS("213.234.9.198*8.8.8.8", "RU", "JSC RDE Unico"),
            new DNS("91.217.62.219*8.8.8.8", "RU", "LLC Megacom-IT"),
            new DNS("95.129.58.55*8.8.8.8", "RU", "Azimut-R Ltd"),
            new DNS("195.208.4.1*8.8.8.8", "RU", "Joint-stock company Internet Exchange MSK-IX"),
            new DNS("62.76.76.62*8.8.8.8", "RU", "Joint-stock company Internet Exchange MSK-IX"),
            new DNS("92.223.109.31*8.8.8.8", "RU", "G-Core Labs S.A"),
            new DNS("92.223.65.32*8.8.8.8", "RU", "G-Core Labs S.A"),
            new DNS("81.3.169.172*8.8.8.8", "RU", "PJSC MegaFon"),
            new DNS("176.103.130.137*8.8.8.8", "RU", "Serveroid, LLC"),
            new DNS("185.51.61.101*8.8.8.8", "RU", "ZAO ElectronTelecom"),
            new DNS("213.183.100.154*8.8.8.8", "RU", "JSC ER-Telecom Holding"),
            new DNS("176.103.130.136*8.8.8.8", "RU", "Serveroid, LLC"),
            new DNS("37.195.200.66*8.8.8.8", "RU", "Novotelecom Ltd"),
            new DNS("176.103.130.131*8.8.8.8", "RU", "Serveroid, LLC"),
            new DNS("77.88.8.7*8.8.8.8", "RU", " LLC"),
            new DNS("193.58.251.251*8.8.8.8", "RU", "SkyDNS Ltd"),
            new DNS("176.103.130.130*8.8.8.8", "RU", "Serveroid, LLC"),
            new DNS("37.193.226.251*8.8.8.8", "RU", "Novotelecom Ltd"),
            new DNS("81.1.217.134*8.8.8.8", "RU", "JSC Zap-Sib TransTeleCom, Novosibirsk"),
            new DNS("37.235.70.59*8.8.8.8", "RU", "OOO MediaSeti"),
            new DNS("46.231.210.26*8.8.8.8", "RU", "OBIT Ltd"),
            new DNS("89.235.136.61*8.8.8.8", "RU", "MSN Telecom LLC"),
            new DNS("89.113.0.68*8.8.8.8", "RU", "Public Joint Stock Company Vimpel-Communications"),
            new DNS("83.149.227.152*8.8.8.8", "RU", "Federal State Institution Federal Scientific Research Institute for System Analysis of the Ru"),
            new DNS("84.52.103.114*8.8.8.8", "RU", "JSC ER-Telecom Holding"),
            new DNS("217.112.27.34*8.8.8.8", "RU", "PJSC Moscow city telephone network"),
            new DNS("83.246.140.204*8.8.8.8", "RU", "Joint Stock Company TransTeleCom"),
            new DNS("213.5.120.2*8.8.8.8", "RU", "Andrey Chuenkov PE"),
            new DNS("212.100.143.211*8.8.8.8", "RU", "OJSC Comcor"),
            new DNS("109.202.11.6*8.8.8.8", "RU", "JSC Avantel"),
            new DNS("46.20.67.50*8.8.8.8", "RU", "Joint Stock Company TransTeleCom"),
            new DNS("194.247.190.70*8.8.8.8", "RU", "Proxima Ltd"),
            new DNS("91.200.227.141*8.8.8.8", "RU", "Korporatsia Svyazy Ltd"),
            new DNS("91.203.177.216*8.8.8.8", "RU", "MAN net Ltd"),
            new DNS("195.162.8.154*8.8.8.8", "RU", "Telecom Plus Ltd"),
            new DNS("91.122.77.189*176.103.130.130", "RU", "St Petersburg"),
            new DNS("91.203.177.216*176.103.130.130", "RU", "Smolensk"),
            new DNS("195.162.8.154*176.103.130.130", "RU", "Telecom Plus Ltd"),
            new DNS("46.20.67.50*8.8.8.8", "RU", "Proxima Ltd"),
            new DNS("194.247.190.70*176.103.130.130", "RU", "AdGuard"),
            new DNS("91.200.227.141*176.103.130.130", "RU", "Korporatsia Svyazy Ltd"),
            /* AU DNS */
            new DNS("1.1.1.1*1.0.0.1", "AU", "CloudFlare"),
            /* US DNS */
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
                        else if (templat.Item1 > lat.Item1)
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
                    PingReply r1 = p1.Send(dnss.Split('*')[0], 50);
                    if (r1.Status == IPStatus.Success)
                    {
                        firsttime = r1.RoundtripTime;
                    }
                }
                catch { }

                try
                {
                    Ping p2 = new Ping();
                    PingReply r2 = p2.Send(dnss.Split('*')[1], 50);
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
                if (CurrentInterface == null)
                {
                    return;
                }

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
