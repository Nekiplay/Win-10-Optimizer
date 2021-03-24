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
        /* Путь до папки Steam */
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
        /* Steam ID текущего пользователя */
        public static string CurrentUserSteamID
        {
            get
            {
                var authserver = (long.Parse(CurrentUserSteamID64) - 76561197960265728) & 1;
                var authid = (long.Parse(CurrentUserSteamID64) - 76561197960265728 - authserver) / 2;
                return $"STEAM_0:{authserver}:{authid}";
            }
        }
        /* Steam ID32 текущего пользователя */
        public static string CurrentUserSteamID32
        {
            get
            {
                return (long.Parse(CurrentUserSteamID64.Substring(3)) - 61197960265728).ToString();
            }
        }
        /* Steam ID64 текущего пользователя */
        public static string CurrentUserSteamID64
        {
            get
            {
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
        /* Steam логин текущего пользователя */
        public static string CurrentUserAccountLogin
        {
            get
            {
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
        /* Steam ник текущего пользователя */
        public static string CurrentUserNickname
        {
            get
            {
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
