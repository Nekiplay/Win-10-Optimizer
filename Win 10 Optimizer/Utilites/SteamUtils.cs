using Gameloop.Vdf;
using Gameloop.Vdf.JsonConverter;
using Gameloop.Vdf.Linq;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static string CurrentUserSteamID32
        {
            get
            {
                return (long.Parse(CurrentUserSteamID64.Substring(3)) - 61197960265728).ToString();
            }
        }
        public static string CurrentUserSteamID
        {
            get
            {
                var authserver = (long.Parse(CurrentUserSteamID64) - 76561197960265728) & 1;
                var authid = (long.Parse(CurrentUserSteamID64) - 76561197960265728 - authserver) / 2;
                return $"STEAM_0:{authserver}:{authid}";
            }
        }
        public static string CurrentUserSteamID64
        {
            get
            {
                //Console.WriteLine(SteamPath + "\\config\\loginusers.vdf");
                try
                {
                    VProperty volvo = VdfConvert.Deserialize(File.ReadAllText(SteamPath + "\\config\\loginusers.vdf"));
                    JProperty importantJsonObject = volvo.ToJson();
                    var accounts = importantJsonObject.Value;
                    foreach (var v1 in accounts)
                    {
                        var recent = v1.Children();
                        foreach (var v2 in recent)
                        {
                            if (v2.Children().ElementAt(3).First.ToString() == "1")
                            {
                                return v1.Path.ToString().Substring(6);
                            }
                        }
                    }
                } catch { }
                return "";
            }
        }
        public static string CurrentUserAccountLogin
        {
            get
            {
                //Console.WriteLine(SteamPath + "\\config\\loginusers.vdf");
                try
                {
                    VProperty volvo = VdfConvert.Deserialize(File.ReadAllText(SteamPath + "\\config\\loginusers.vdf"));
                    JProperty importantJsonObject = volvo.ToJson();
                    var accounts = importantJsonObject.Value;
                    foreach (var v1 in accounts)
                    {
                        var recent = v1.Children();
                        foreach (var v2 in recent)
                        {
                            if (v2.Children().ElementAt(3).First.ToString() == "1")
                            {
                                return v2.Children().ElementAt(0).First.ToString();
                            }
                        }
                    }
                }
                catch { }
                return "";
            }
        }
        public static string CurrentUserNickname
        {
            get
            {
                //Console.WriteLine(SteamPath + "\\config\\loginusers.vdf");
                try
                {
                    VProperty volvo = VdfConvert.Deserialize(File.ReadAllText(SteamPath + "\\config\\loginusers.vdf"));
                    JProperty importantJsonObject = volvo.ToJson();
                    var accounts = importantJsonObject.Value;
                    foreach (var v1 in accounts)
                    {
                        var recent = v1.Children();
                        foreach (var v2 in recent)
                        {
                            if (v2.Children().ElementAt(3).First.ToString() == "1")
                            {
                                return v2.Children().ElementAt(1).First.ToString();
                            }
                        }
                    }
                }
                catch { }
                return "";
            }
        }
    }
}
