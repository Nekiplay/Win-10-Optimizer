using Microsoft.Win32;
using System.Management;

namespace Win_10_Optimizer.WinUtils
{
    public static class CWin
    {
        public static string HKLM_GetString(string path, string key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null)
                {
                    return "";
                }
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public static string FriendlyName()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            if (ProductName != "")
            {
                return ProductName;
            }
            return "";
        }
    }
}
