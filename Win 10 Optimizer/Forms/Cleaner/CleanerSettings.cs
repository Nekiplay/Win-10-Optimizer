using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer
{
    public class CleanerSettings
    {
        /* Логи */
        public List<ClearFiles> logsfiles = new List<ClearFiles> {
            /* NVIDIA */
            new ClearFiles("C:\\ProgramData\\NVIDIA", @"*.log"),
            new ClearFiles("C:\\ProgramData\\NVIDIA Corporation", "*.log"),
            new ClearFiles("C:\\ProgramData\\NVIDIA Corporation\\nvstapisvr", "*.log"),
            new ClearFiles("C:\\ProgramData\\NVIDIA Corporation\\nvStereoInstaller", "*.log"),
            new ClearFiles("C:\\ProgramData\\NVIDIA Corporation\\NvFBCPlugin", "*.txt"),
            /* Razer */
            new ClearFiles("C:\\ProgramData\\Razer\\Services\\Logs\\", "*.log"),
            new ClearFiles("C:\\ProgramData\\Razer\\RazerCortexManifestRepair\\Logs", "*.log"),
            new ClearFiles("C:\\ProgramData\\Razer\\BigDataSDK\\Logs", "*.log"),
            /* Виндовс */
            new ClearFiles("C:\\ProgramData\\Progress\\Installer\\Logs", "*.log"),
            /* Манйркрафт */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\logs", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft", "*log*"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.vimeworld\\minigames\\logs", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.cristalix\\launcher.log", "*.*", true),
            /* OzoneMC (Манйркрафт) */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Olympus\\logs", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Olympus", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Olympus\\HiTech\\liteconfig", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Olympus\\HiTech\\journeymap", "*.log"),
            /* Lunar Client (Манйркрафт) */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.lunarclient\\logs\\launcher", "*.log", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.lunarclient\\offline\\files\\1.7\\logs", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.lunarclient\\offline\\1.7\\logs", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.lunarclient\\offline\\1.8\\logs", "*.*", true),
            /* AnyDesk */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnyDesk\\chat", "*.*", true),
            /* Discord */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\VideoDecodeStats", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\discord\\shared_proto_db\\metadata", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\discord\\Session Storage", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\IndexedDB\\https_www.youtube.com_0.indexeddb.leveldb", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\IndexedDB\\https_www.youtube.com_0.indexeddb.leveldb", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Crashpad\\reports", "*.dmp"),
            /* ShareX */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ShareX\\Logs", "*.txt", true),
            /* VirualBox */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\.VirtualBox", "*.log*"),
            new ClearFiles("C:\\ProgramData\\VirtualBox", "*.*", true),
            /* Avast */
            new ClearFiles("C:\\ProgramData\\Avast Software\\Persistent Data\\Avast\\Logs", "*.*", true),
            /* Unlocker */
            new ClearFiles("C:\\Program Files\\Unlocker", "README.TXT"),
            /* OSU (Game) */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile + "\\AppData\\Local\\osu!\\Logs", "*.log", true),
        };
        /* Кэш (Cache) */
        public List<ClearFiles> cachefiles = new List<ClearFiles>
        {
            /* Discord */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Code Cache", "*.*", true),
            /* Windows (Beta Test) */
            new ClearFiles("C:\\ProgramData\\Package Cache", "*.*", true),
        };
        /* Скриншоты */
        public List<ClearFiles> screenshotfiles = new List<ClearFiles> {
            /* Программы */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ShareX\\Screenshots", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Lightshot", "*.*", true),
            new ClearFiles("{drive}:\\Fraps\\Screenshots", "*.*", true),
            /* Майнкрафт */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\screenshots", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.vimeworld\\minigames\\screenshots", "*.*", true),
        };
        /* Видео */
        public List<ClearFiles> videofiles = new List<ClearFiles> {
            /* Программы */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Bandicam", "*.*", true),
            new ClearFiles("{drive}:\\Fraps\\Movies", "*.*", true),
        };
        /* Windows мусор */
        public List<ClearFiles> windowsfiles = new List<ClearFiles> {
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache), "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Recent", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Temp", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Temp", "*.*", true),
        };
        /* Бэкапы */
        public List<ClearFiles> backupfiles = new List<ClearFiles> {
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ShareX\\Backup", "*.json", true),
        };
        /* Steam Files */
        public List<ClearFiles> steamfiles = new List<ClearFiles>();
        /* Настройки читов */
        public List<ClearFiles> cheatconfigfiles = new List<ClearFiles>
        {
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\Jigsaw", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\LiquidBounce-1.8", "*.*", true),
        };
        public CleanerSettings()
        {
            /* Steam Games */
            string steamdir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", "Nothing");
            if (string.IsNullOrEmpty(steamdir) || steamdir == "Nothing")
            {
                steamdir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", "Nothing");
            }
            steamfiles.Add(new ClearFiles(steamdir + "\\steamapps\\common\\GarrysMod", "*.log"));
            steamfiles.Add(new ClearFiles(steamdir + "\\steamapps\\common\\GarrysMod", "*.mdmp"));
            steamfiles.Add(new ClearFiles(steamdir + "\\steamapps\\common\\GarrysMod\\crashes", "*.*", true));
            steamfiles.Add(new ClearFiles(steamdir + "\\steamapps\\common\\Warface\\0_1177\\LogBackups", "*.log"));
            steamfiles.Add(new ClearFiles(steamdir + "\\steamapps\\common\\Warface\\GameCenter", "*.log"));
            steamfiles.Add(new ClearFiles(steamdir + "\\steamapps\\common\\Among Us", "*.log"));
            steamfiles.Add(new ClearFiles(steamdir + "\\steamapps\\common\\Unturned\\Log", "*.log"));
            steamfiles.Add(new ClearFiles(steamdir + "\\steamapps\\common\\Half-Life 2", "*.log"));
            steamfiles.Add(new ClearFiles(steamdir + "\\logs", "*.*", true));

            cheatconfigfiles.Add(new ClearFiles(steamdir + "\\steamapps\\common\\Counter-Strike Global Offensive\\ot", "*.*", true));
        }
        /* Класс для хранения данных */
        public class ClearFiles
        {
            private readonly string dir;
            private readonly string pattern;
            private readonly bool deleteall;
            public ClearFiles(string dir, string pattern)
            {
                this.dir = dir;
                this.pattern = pattern;
            }
            public ClearFiles(string dir, string pattern, bool deleteall)
            {
                this.dir = dir;
                this.pattern = pattern;
                this.deleteall = deleteall;
            }
            private bool Exist (string path){  try { return System.IO.Directory.Exists(path); } catch { return false; } }
            public long Delete()
            {
                long deleted = 0;
                if (!dir.StartsWith("{drive}"))
                {
                    deleted += Clear();
                }
                else
                {
                    foreach (var drive in System.IO.DriveInfo.GetDrives())
                    {
                        try
                        {
                            string drivec = drive.Name.Substring(0, drive.Name.Length - 2);
                            deleted += Clear(dir.Replace("{drive}", drivec));
                        }
                        catch { }
                    }
                }
                return deleted;
            }
            private long Clear(string custompath)
            {
                long bytesdeleted = 0;
                if (Exist(custompath))
                {
                    if (!deleteall)
                    {
                        var result = System.IO.Directory.EnumerateFiles(custompath, pattern);
                        if (result.Count() != 0) { foreach (var m in result) { try { System.IO.FileInfo file = new System.IO.FileInfo(m); System.IO.File.Delete(m); bytesdeleted += file.Length; } catch { } }  }
                    }
                    else
                    {
                        System.IO.DirectoryInfo myDirInfo = new System.IO.DirectoryInfo(custompath);
                        foreach (System.IO.FileInfo file in myDirInfo.GetFiles()) { try { file.Delete(); bytesdeleted += file.Length; } catch { } }
                        foreach (System.IO.DirectoryInfo diri in myDirInfo.GetDirectories()) 
                        {
                            try 
                            { 
                                foreach (System.IO.FileInfo file in diri.GetFiles())
                                {
                                    file.Delete();
                                    bytesdeleted += file.Length;
                                }
                                diri.Delete(true); 
                            } 
                            catch 
                            { } 
                        }
                        try { System.IO.Directory.Delete(dir, true); } catch { }
                    }
                }
                return bytesdeleted;
            }
            private long Clear()
            {
                return Clear(dir);
            }
        }
    }
}
