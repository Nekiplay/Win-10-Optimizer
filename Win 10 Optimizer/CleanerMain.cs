using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer
{
    public class CleanerMain
    {
        /* Логи */
        public List<ClearFiles> logsfiles = new List<ClearFiles> {
            /* NVIDIA */
            new ClearFiles("C:\\ProgramData\\NVIDIA\\", @"*.log"),
            new ClearFiles("C:\\ProgramData\\NVIDIA Corporation\\", "*.log"),
            new ClearFiles("C:\\ProgramData\\NVIDIA Corporation\\nvstapisvr\\", "*.log"),
            /* Razer */
            new ClearFiles("C:\\ProgramData\\Razer\\Services\\Logs\\", "*.log"),
            new ClearFiles("C:\\ProgramData\\Razer\\RazerCortexManifestRepair\\Logs\\", "*.log"),
            new ClearFiles("C:\\ProgramData\\Razer\\BigDataSDK\\Logs\\", "*.log"),
            /* Виндовс */
            new ClearFiles("C:\\ProgramData\\Progress\\Installer\\Logs\\", "*.log"),
            /* Манйркрафт */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\logs\\", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.vimeworld\\minigames\\logs\\", "*.*", true),
            /* AnyDesk */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\AnyDesk\\chat\\", "*.*", true),
            /* Discord */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\VideoDecodeStats\\", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\discord\\shared_proto_db\\metadata\\", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\discord\\Session Storage\\", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\IndexedDB\\https_www.youtube.com_0.indexeddb.leveldb\\", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\IndexedDB\\https_www.youtube.com_0.indexeddb.leveldb\\", "*.log"),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Crashpad\\reports\\", "*.dmp"),
        };
        /* Кэш (Cache) */
        public List<ClearFiles> cachefiles = new List<ClearFiles>
        {
            /* Discord */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Code Cache\\", "*.*", true),
        };
        /* Скриншоты */
        public List<ClearFiles> screenshotfiles = new List<ClearFiles> {
            /* Программы */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ShareX\\Screenshots", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Lightshot", "*.*", true),
            new ClearFiles("{drive}:\\Fraps\\Screenshots", "*.*", true),
            /* Майнкрафт */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\screenshots\\", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.vimeworld\\minigames\\screenshots\\", "*.*", true),
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

        /* Find Class */
        public class ClearFiles
        {
            private string dir;
            private string pattern;
            private bool deleteall;
            private bool alldrive;
            public ClearFiles(string dir, string pattern, bool deleteall = false)
            {
                this.dir = dir;
                this.pattern = pattern;
                this.deleteall = deleteall;
            }
            public bool Exist (string path){  try { return System.IO.Directory.Exists(path); } catch { return false; } }
            public void Delete()
            {
                if (!dir.StartsWith("{drive}"))
                {
                    if (Exist(dir))
                    {
                        Clear();
                    }
                }
                else
                {
                    foreach (var drive in DriveInfo.GetDrives())
                    {
                        try 
                        {
                            string drivec = drive.Name.Substring(0, drive.Name.Length - 2);
                            Console.WriteLine(dir.Replace("{drive}", drivec));
                            Clear(dir.Replace("{drive}", drivec)); 
                        } catch { }
                    }
                }    
            }
            private void Clear(string custompath)
            {
                if (Exist(custompath))
                {
                    if (!deleteall)
                    {
                        var result = System.IO.Directory.EnumerateFiles(custompath, pattern);
                        if (result.Count() != 0) { foreach (var m in result) { try { File.Delete(m); } catch { } } }
                    }
                    else
                    {
                        System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(custompath);
                        foreach (FileInfo file in myDirInfo.GetFiles()) { try { file.Delete(); } catch { } }
                        foreach (DirectoryInfo dir in myDirInfo.GetDirectories()) { try { dir.Delete(true); } catch { } }
                        try { Directory.Delete(dir, true); } catch { }
                    }
                }
            }
            private void Clear()
            {
                Clear(dir);
            }
        }
    }
}
