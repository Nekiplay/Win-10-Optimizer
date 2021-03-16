using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Forms.Cleaner
{
    public class CleanerRegeditSettings
    {
        public List<RegeditFiles> lastactivity = new List<RegeditFiles>
        {
            new RegeditFiles(Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\Local Settings\\Software\\Microsoft\\Windows\\Shell\\BagMRU", true), true),
            new RegeditFiles(Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\ComDlg32\\OpenSavePidlMRU", true), true),
            /* Удаленные программы */
            new RegeditFiles(Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true), true),
            new RegeditFiles(Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true), true),
        };
        public CleanerRegeditSettings()
        {

        }
        public class RegeditFiles
        {
            private RegistryKey regedit;
            private bool delete_all;
            public RegeditFiles(RegistryKey path)
            {
                this.regedit = path;
            }
            public RegeditFiles(RegistryKey path, bool delete_all)
            {
                this.regedit = path;
                this.delete_all = delete_all;
            }
            public void Delete()
            {
                if (regedit != null)
                {
                    if (delete_all)
                    {
                        foreach (string reg in regedit.GetSubKeyNames())
                        {
                            try
                            {
                                regedit.DeleteSubKeyTree(reg);
                            }
                            catch { }
                        }
                    }
                }
            }
        }
    }
}
