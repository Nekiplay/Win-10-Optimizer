using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Utilites
{
    public static class SteamUtils
    {
        public static string SteamPath
        {
            get
            {
                string steamdir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", "Nothing");
                if (string.IsNullOrEmpty(steamdir) || steamdir == "Nothing")
                {
                    steamdir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", "Nothing");
                }
                return steamdir;
            }
        }
    }
}
