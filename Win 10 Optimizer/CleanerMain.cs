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
        };
        public List<ClearFiles> screenshotfiles = new List<ClearFiles> {
            /* Программы */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ShareX\\Screenshots", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Lightshot", "*.*", true),
            new ClearFiles("{drive}:\\Fraps\\Screenshots", "*.*", true),
            /* Майнкрафт */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\screenshots\\", "*.*", true),
        };
        public List<ClearFiles> videofiles = new List<ClearFiles> {
            /* Программы */
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Bandicam", "*.*", true),
            new ClearFiles("{drive}:\\Fraps\\Movies", "*.*", true),
        };
        public List<ClearFiles> windowsfiles = new List<ClearFiles> {
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache), "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Recent", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Temp", "*.*", true),
            new ClearFiles(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Temp", "*.*", true),
        };

        /* Find Class */
        public class ClearFiles
        {
            public string dir;
            public string pattern;
            public bool deleteall;
            public bool alldrive;
            public ClearFiles(string dir, string pattern, bool deleteall = false)
            {
                this.dir = dir;
                this.pattern = pattern;
                this.deleteall = deleteall;
            }
            public bool Exist { get { try { return System.IO.Directory.Exists(dir); } catch { return false; } } }
            public void Delete()
            {
                if (!dir.StartsWith("{drive}"))
                {
                    if (Exist)
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
                if (!deleteall)
                {
                    var result = System.IO.Directory.EnumerateFiles(custompath, pattern);
                    switch (result.Count()) { case 0: break; default: foreach (var m in result) { try { File.Delete(m); } catch { } } break; }
                }
                else
                {
                    System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(custompath);
                    foreach (FileInfo file in myDirInfo.GetFiles()) { try { file.Delete(); } catch (Exception ex) { } }
                    foreach (DirectoryInfo dir in myDirInfo.GetDirectories()) { try { dir.Delete(true); } catch (Exception ex) { } }
                    try { Directory.Delete(dir, true); } catch { }
                }
            }
            private void Clear()
            {
                Clear(dir);
            }
        }
    }
}
