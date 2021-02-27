using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_10_Optimizer.Forms
{
    public partial class Cleaner : Form
    {
        public Cleaner()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Cleaner_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox6_OnChange(object sender, EventArgs e)
        {

        }
        enum RecycleFlags : int
        {
            // No confirmation dialog when emptying the recycle bin
            SHERB_NOCONFIRMATION = 0x00000001,
            // No progress tracking window during the emptying of the recycle bin
            SHERB_NOPROGRESSUI = 0x00000001,
            // No sound whent the emptying of the recycle bin is complete
            SHERB_NOSOUND = 0x00000004
        }
        // Shell32.dll is where SHEmptyRecycleBin is located
        [DllImport("Shell32.dll")]
        // The signature of SHEmptyRecycleBin (located in Shell32.dll)
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuFlatButton1.Enabled = false;
            CleanerMain cleanermethod = new CleanerMain();
            if (bunifuCheckbox1.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    /* Settings and Worker */
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOSOUND | RecycleFlags.SHERB_NOCONFIRMATION | RecycleFlags.SHERB_NOPROGRESSUI);

                    foreach (CleanerMain.ClearFiles clear in cleanermethod.windowsfiles)
                    {
                        clear.Delete();
                    }

                    bunifuCheckbox1.Invoke(new MethodInvoker(() =>
                    {
                        bunifuCheckbox1.Checked = false;
                    }));
                });
            }
            if (bunifuCheckbox5.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (CleanerMain.ClearFiles clear in cleanermethod.videofiles)
                    {
                        clear.Delete();
                    }

                    bunifuCheckbox5.Invoke(new MethodInvoker(() =>
                    {
                        bunifuCheckbox5.Checked = false;
                    }));
                });
            }
            if (bunifuCheckbox4.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (CleanerMain.ClearFiles clear in cleanermethod.screenshotfiles)
                    {
                        clear.Delete();
                    }

                    bunifuCheckbox4.Invoke(new MethodInvoker(() =>
                    {
                        bunifuCheckbox4.Checked = false;
                    }));
                });
            }
            if (bunifuCheckbox6.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (CleanerMain.ClearFiles clear in cleanermethod.logsfiles)
                    {
                        clear.Delete();
                    }

                    bunifuCheckbox6.Invoke(new MethodInvoker(() =>
                    {
                        bunifuCheckbox6.Checked = false;
                    }));
                });
            }
            if (bunifuCheckbox2.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    string strSteamInstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam", "InstallPath", "Nothing");
                    if (!string.IsNullOrEmpty(strSteamInstallPath) || strSteamInstallPath == "Nothing")
                        strSteamInstallPath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam", "InstallPath", "Nothing");

                    if (Directory.Exists(strSteamInstallPath + "\\steamapps\\common\\GarrysMod"))
                    {
                        var result = Directory.EnumerateFiles(strSteamInstallPath + "\\steamapps\\common\\GarrysMod", "*.log");
                        foreach (var m in result)
                        {
                            try
                            {
                                File.Delete(m);
                            }
                            catch { }
                        }
                        var result2 = Directory.EnumerateFiles(strSteamInstallPath + "\\steamapps\\common\\GarrysMod", "*.mdmp");
                        foreach (var m in result2)
                        {
                            try { File.Delete(m); }
                            catch { }
                        }
                        if (Directory.Exists(strSteamInstallPath + "\\steamapps\\common\\GarrysMod\\crashes"))
                        {
                            try
                            {
                                Directory.Delete(strSteamInstallPath + "\\steamapps\\common\\GarrysMod\\crashes", true);
                            }
                            catch { }
                        }
                    }
                    if (Directory.Exists(strSteamInstallPath + "\\steamapps\\common\\Counter-Strike Global Offensive"))
                    {
                        var result = Directory.EnumerateFiles(strSteamInstallPath + "\\steamapps\\common\\Counter-Strike Global Offensive", "*.mdmp");
                        foreach (var m in result)
                        {
                            try
                            {
                                File.Delete(m);
                            }
                            catch { }
                        }
                    }
                    if (Directory.Exists(strSteamInstallPath + "\\steamapps\\common\\Warface\\0_1177\\LogBackups"))
                    {
                        var result = Directory.EnumerateFiles(strSteamInstallPath + "\\steamapps\\common\\Warface\\0_1177\\LogBackups", "*.log");
                        foreach (var m in result)
                        {
                            try
                            {
                                File.Delete(m);
                            }
                            catch { }
                        }
                    }
                    if (Directory.Exists(strSteamInstallPath + "\\steamapps\\common\\Warface\\GameCenter"))
                    {
                        var result = Directory.EnumerateFiles(strSteamInstallPath + "\\steamapps\\common\\Warface\\GameCenter", "*.log");
                        foreach (var m in result)
                        {
                            try
                            {
                                File.Delete(m);
                            }
                            catch { }
                        }
                    }
                    if (Directory.Exists(strSteamInstallPath + "\\steamapps\\common\\Among Us"))
                    {
                        var result = Directory.EnumerateFiles(strSteamInstallPath + "\\steamapps\\common\\Among Us", "*.log");
                        foreach (var m in result)
                        {
                            try
                            {
                                File.Delete(m);
                            }
                            catch { }
                        }
                    }
                    if (Directory.Exists(strSteamInstallPath + "\\steamapps\\common\\Unturned\\Logs"))
                    {
                        var result = Directory.EnumerateFiles(strSteamInstallPath + "\\steamapps\\common\\Unturned\\Logs", "*.log");
                        foreach (var m in result)
                        {
                            try
                            {
                                File.Delete(m);
                            }
                            catch { }
                        }
                    }
                    if (Directory.Exists(strSteamInstallPath + "\\steamapps\\common\\Half-Life 2"))
                    {
                        var result = Directory.EnumerateFiles(strSteamInstallPath + "\\steamapps\\common\\Half-Life 2", "*.log");
                        foreach (var m in result)
                        {
                            try
                            {
                                File.Delete(m);
                            }
                            catch { }
                        }
                    }
                    if (Directory.Exists(strSteamInstallPath + "\\Logs"))
                    {
                        System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(strSteamInstallPath + "\\Logs");
                        foreach (FileInfo file in myDirInfo.GetFiles())
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch (Exception ex) { }
                        }
                        foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                        {
                            try
                            {
                                dir.Delete(true);
                            }
                            catch (Exception ex) { }
                        }
                    }
                    bunifuCheckbox2.Invoke(new MethodInvoker(() =>
                    {
                        bunifuCheckbox2.Checked = false;
                    }));
                });
            }
            bunifuFlatButton1.Enabled = true;
        }
    }
}
