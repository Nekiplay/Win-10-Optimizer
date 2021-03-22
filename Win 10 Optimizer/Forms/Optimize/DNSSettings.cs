using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Forms.Optimize
{
    public class DNSSettings
    {
        public List<DNS> DNSList = new List<DNS>
        {
            /* Русские DNS */
            /* PVimpelCom */
            new DNS("212.46.234.217", "RU", "PVimpelCom"),
            new DNS("195.239.36.27", "RU", "PVimpelCom"),
            new DNS("195.14.50.21", "RU", "PVimpelCom"),
            new DNS("89.179.83.118", "RU", "PVimpelCom"),
            new DNS("83.69.120.1", "RU", "PVimpelCom"),
            new DNS("81.211.96.62", "RU", "PVimpelCom"),
            new DNS("80.243.64.67", "RU", "PVimpelCom"),
            /* Yandex */
            new DNS("77.88.8.88", "RU", "YANDEX LLC"),
            new DNS("77.88.8.81", "RU", "YANDEX LLC"),
            new DNS("77.88.8.3", "RU", "YANDEX LLC"),
            new DNS("77.88.8.2", "RU", "YANDEX LLC"),
            new DNS("77.88.8.1", "RU", "YANDEX LLC"),
            /* MTS */
            new DNS("95.104.194.3", "RU", "MTS PJSC"),
            new DNS("80.71.178.68", "RU", "MTS PJSC"),
            new DNS("62.168.251.166", "RU", "MTS PJSC"),
            /* Rostelecom */
            new DNS("213.24.238.26", "RU", "Rostelecom"),
            new DNS("213.24.237.210", "RU", "Rostelecom"),
            new DNS("212.58.212.83", "RU", "Rostelecom"),
            new DNS("195.46.112.170", "RU", "Rostelecom"),
            new DNS("109.172.10.70", "RU", "Rostelecom"),
            new DNS("91.122.77.189", "RU", "Rostelecom"),
            new DNS("85.175.46.122", "RU", "Rostelecom"),
            new DNS("84.54.226.50", "RU", "Rostelecom"),
            new DNS("82.208.99.185", "RU", "Rostelecom"),
            /* Other */
            new DNS("84.237.112.130", "RU", "Federal Research Center for Information and Computational Technologies"),
            new DNS("62.113.51.133", "RU", "SFT Company"),
            new DNS("212.75.208.170", "RU", "E-Light-Telecom Ltd"),
            new DNS("178.210.42.50", "RU", "KVANT-TELEKOM Closed Joint Stock Company"),
            new DNS("195.98.79.117", "RU", "Ic-voronezh82.208.99.185"),
            new DNS("31.204.180.44", "RU", "Unknow"),
            new DNS("195.191.183.60", "RU", "MediaNet Ltd"),
            new DNS("84.244.59.15", "RU", "Unknow"),
            new DNS("62.122.101.59", "RU", "Unknow"),
            new DNS("195.112.96.34", "RU", "MAXnet Systems Ltd"),
            new DNS("217.150.35.129", "RU", "Joint Stock Company TransTeleCom"),
            new DNS("195.69.65.98", "RU", "BILLING SOLUTION Ltd"),
            new DNS("37.29.119.100", "RU", "PJSC MegaFon"),
            new DNS("195.208.5.1", "RU", "Unknow"),
            new DNS("46.16.229.223", "RU", "JSC Elektrosvyaz"),
            new DNS("77.95.89.99", "RU", "Speckless Enterprise Ltd"),
            new DNS("94.100.86.238", "RU", "Unknow"),
            new DNS("91.205.3.65", "RU", "Joint Stock Company TransTeleCom"),
            new DNS("213.234.9.198", "RU", "JSC RDE Unico"),
            new DNS("91.217.62.219", "RU", "LLC Megacom-IT"),
            new DNS("95.129.58.55", "RU", "Azimut-R Ltd"),
            new DNS("195.208.4.1", "RU", "Joint-stock company Internet Exchange MSK-IX"),
            new DNS("62.76.76.62", "RU", "Joint-stock company Internet Exchange MSK-IX"),
            new DNS("92.223.109.31", "RU", "G-Core Labs S.A"),
            new DNS("92.223.65.32", "RU", "G-Core Labs S.A"),
            new DNS("81.3.169.172", "RU", "PJSC MegaFon"),
            new DNS("176.103.130.137", "RU", "Serveroid, LLC"),
            new DNS("185.51.61.101", "RU", "ZAO ElectronTelecom"),
            new DNS("213.183.100.154", "RU", "JSC ER-Telecom Holding"),
            new DNS("176.103.130.136", "RU", "Serveroid, LLC"),
            new DNS("37.195.200.66", "RU", "Novotelecom Ltd"),
            new DNS("176.103.130.131", "RU", "Serveroid, LLC"),
            new DNS("77.88.8.7", "RU", " LLC"),
            new DNS("193.58.251.251", "RU", "SkyDNS Ltd"),
            new DNS("176.103.130.130", "RU", "Serveroid, LLC"),
            new DNS("37.193.226.251", "RU", "Novotelecom Ltd"),
            new DNS("81.1.217.134", "RU", "JSC Zap-Sib TransTeleCom, Novosibirsk"),
            new DNS("37.235.70.59", "RU", "OOO MediaSeti"),
            new DNS("46.231.210.26", "RU", "OBIT Ltd"),
            new DNS("89.235.136.61", "RU", "MSN Telecom LLC"),
            new DNS("89.113.0.68", "RU", "Public Joint Stock Company Vimpel-Communications"),
            new DNS("83.149.227.152", "RU", "Federal State Institution Federal Scientific Research Institute for System Analysis of the Ru"),
            new DNS("84.52.103.114", "RU", "JSC ER-Telecom Holding"),
            new DNS("217.112.27.34", "RU", "PJSC Moscow city telephone network"),
            new DNS("83.246.140.204", "RU", "Joint Stock Company TransTeleCom"),
            new DNS("213.5.120.2", "RU", "Andrey Chuenkov PE"),
            new DNS("212.100.143.211", "RU", "OJSC Comcor"),
            new DNS("109.202.11.6", "RU", "JSC Avantel"),
            new DNS("46.20.67.50", "RU", "Joint Stock Company TransTeleCom"),
            new DNS("194.247.190.70", "RU", "Proxima Ltd"),
            new DNS("91.200.227.141", "RU", "Korporatsia Svyazy Ltd"),
            new DNS("91.203.177.216", "RU", "MAN net Ltd"),
            new DNS("195.162.8.154", "RU", "Telecom Plus Ltd"),
            new DNS("91.122.77.189", "RU", "St Petersburg"),
            new DNS("91.203.177.216", "RU", "Smolensk"),
            new DNS("195.162.8.154", "RU", "Telecom Plus Ltd"),
            new DNS("46.20.67.50", "RU", "Proxima Ltd"),
            new DNS("194.247.190.70", "RU", "AdGuard"),
            new DNS("91.200.227.141", "RU", "Korporatsia Svyazy Ltd"),
            /* AU DNS */
            new DNS("1.1.1.1", "AU", "CloudFlare"),
            new DNS("1.0.0.1", "AU", "CloudFlare"),
            /* US DNS */
            new DNS("8.8.8.8", "US", "Google Public DNS"),
            new DNS("8.8.4.4", "US", "Google Public DNS"),
            new DNS("156.154.71.1", "US", "Neustar 1"),
            new DNS("156.154.70.1", "US", "Neustar 1"),
            new DNS("208.67.220.222", "US", "OpenDNS - 2"),
            new DNS("208.67.222.220", "US", "OpenDNS - 2"),
            new DNS("64.6.65.6", "US", "VerSign Public DNS"),
            new DNS("64.6.64.6", "US", "VerSign Public DNS"),
            new DNS("156.154.71.22", "US", "Comodo"),
            new DNS("156.154.70.22", "US", "Comodo"),
            new DNS("156.154.70.5", "US", "Neustar 2"),
            new DNS("156.154.71.5", "US", "Neustar 2"),
            new DNS("74.82.42.42", "US", "Hurricane Electric"),
            new DNS("7199.85.126.10", "US", "Norton ConnectionSafe Basic"),
            new DNS("199.85.127.10", "US", "Norton ConnectionSafe Basic"),
            new DNS("204.74.101.1", "US", "Ultra DNS"),
            new DNS("204.69.234.1", "US", "Ultra DNS"),
            new DNS("198.153.194.1", "US", "Norton DNS"),
            new DNS("198.153.192.1", "US", "Norton DNS"),
            new DNS("149.112.112.112", "US", "Quad9 Security"),
            new DNS("4.2.2.4", "US", "Level 3 - C"),
            new DNS("4.2.2.3", "US", "Level 3 - C"),
            new DNS("84.200.70.40", "US", "DNS Watch"),
            new DNS("84.200.69.80", "US", "DNS Watch"),
            new DNS("209.244.0.4", "US", "Level 3 - A"),
            new DNS("209.244.0.3", "US", "Level 3 - A"),
            new DNS("9.9.9.9", "US", "Quad9 Security"),
        };
        private async Task<DNS> GetBestDNSAsync()
        {
            return await GetBestDNSAsync("");
        }
        public async Task<DNS> GetDNS()
        {
            DNS on1 = await GetBestDNSAsync();
            DNS on2 = await GetBestDNSAsync(on1.dns);
            return new DNS(on1.dns + "*" + on2.dns, on1.countiry, on1.company_or_name);
        }
        private async Task<DNS> GetBestDNSAsync(string ignore)
        {
            List<Task> asyncs = new List<Task>();
            DNS best = DNSList.FirstOrDefault();
            long templat = -1;
            foreach (DNS dns in DNSList)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    if (dns.dns != ignore)
                    {
                        long lat = dns.GetLatency(dns.dns);
                        dns.latency = lat;
                        if (lat == -1 || templat == -1)
                        {
                            templat = lat;
                            best = dns;
                        }
                        else
                        {
                            if (templat > lat)
                            {
                                templat = lat;
                                best = dns;
                            }
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
            public long latency;

            public DNS(string dns, string countury, string company_or_name)
            {
                this.dns = dns;
                this.countiry = countiry;
                this.company_or_name = company_or_name;
            }
            public long GetLatency(string dnss)
            {
                int timeout = 50;
                long firsttime = 99999999999;
                try
                {
                    Ping p1 = new Ping();
                    PingReply r1 = p1.Send(dnss, timeout);
                    if (r1.Status == IPStatus.Success)
                    {
                        firsttime = r1.RoundtripTime;
                    }
                }
                catch { }
                return firsttime;
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
                            objdns["DNSServerSearchOrder"] = Dns;
                            objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                    }
                }
            }
        }
    }
}
