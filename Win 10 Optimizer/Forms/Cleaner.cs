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
            Task.Factory.StartNew(() =>
            {
                bunifuFlatButton1.Enabled = false;
                if (bunifuCheckbox1.Checked)
                {
                    Task.Factory.StartNew(() =>
                    {
                        SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOSOUND | RecycleFlags.SHERB_NOCONFIRMATION | RecycleFlags.SHERB_NOPROGRESSUI);
                        string md = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
                        if (Directory.Exists(md))
                        {
                            System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(md);
                            foreach (FileInfo file in myDirInfo.GetFiles())
                            {
                                try { 
                                    file.Delete(); 
                                }
                                catch (Exception ex) { }
                            }
                            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                            {
                                try { 
                                    dir.Delete(true); 
                                }
                                catch (Exception ex) { }
                            }
                        }
                        string md2 = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Roaming\Microsoft\Windows\Recent";
                        if (Directory.Exists(md2))
                        {
                            System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(md2);
                            foreach (FileInfo file in myDirInfo.GetFiles())
                            {
                                try { 
                                    file.Delete(); 
                                }
                                catch (Exception ex) { }
                            }
                            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                            {
                                try { 
                                    dir.Delete(true); 
                                }
                                catch (Exception ex) { }
                            }
                        }
                        string md3 = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp";
                        if (Directory.Exists(md3))
                        {
                            System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(md3);
                            foreach (FileInfo file in myDirInfo.GetFiles())
                            {
                                try { 
                                    file.Delete(); 
                                }
                                catch (Exception ex) { }
                            }
                            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                            {
                                try { 
                                    dir.Delete(true);
                                }
                                catch (Exception ex) { }
                            }
                        }
                        string md4 = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Temp";
                        if (Directory.Exists(md4))
                        {
                            System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(md4);
                            foreach (FileInfo file in myDirInfo.GetFiles())
                            {
                                try { 
                                    file.Delete(); 
                                }
                                catch (Exception ex) { }
                            }
                            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                            {
                                try { 
                                    dir.Delete(true); 
                                }
                                catch (Exception ex) { }
                            }
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
                        string md = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Bandicam";//путь к Документам
                        if (Directory.Exists(md))
                        {
                            System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(md);
                            foreach (FileInfo file in myDirInfo.GetFiles())
                            {
                                try { 
                                    file.Delete(); 
                                }
                                catch (Exception ex) { }
                            }
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
                        string md = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ShareX";//путь к Документам
                        if (Directory.Exists(md))
                        {
                            System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(md);
                            foreach (FileInfo file in myDirInfo.GetFiles())
                            {
                                try { 
                                    file.Delete(); 
                                }
                                catch (Exception ex) { }
                            }
                            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                            {
                                try { 
                                    dir.Delete(true); 
                                }
                                catch (Exception ex) { }
                            }
                        }
                        string md2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\screenshots\\";//путь к Документам
                        if (Directory.Exists(md2))
                        {
                            System.IO.DirectoryInfo myDirInfo = new DirectoryInfo(md2);
                            foreach (FileInfo file in myDirInfo.GetFiles())
                            {
                                try { 
                                    file.Delete(); 
                                }
                                catch (Exception ex) { }
                            }
                            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                            {
                                try { 
                                    dir.Delete(true); 
                                }
                                catch (Exception ex) { }
                            }
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
                        /* NVIDIA */
                        string md2 = @"C:\ProgramData\NVIDIA\";
                        if (Directory.Exists(md2))
                        {
                            var result = Directory.EnumerateFiles(@"C:\ProgramData\NVIDIA\", "*.log");
                            foreach (var m in result)
                            {
                                try { 
                                    File.Delete(m); 
                                }
                                catch { }
                            }
                        }
                        string md3 = @"C:\ProgramData\NVIDIA Corporation\";
                        if (Directory.Exists(md3))
                        {
                            var result = Directory.EnumerateFiles(@"C:\ProgramData\NVIDIA Corporation", "*.log");
                            foreach (var m in result)
                            {
                                try {
                                    File.Delete(m);
                                }
                                catch { }
                            }
                        }
                        string md4 = @"C:\ProgramData\NVIDIA Corporation\nvstapisvr\";
                        if (Directory.Exists(md4))
                        {
                            var result = Directory.EnumerateFiles(@"C:\ProgramData\NVIDIA Corporation\nvstapisvr\", "*.log");
                            foreach (var m in result)
                            {
                                try {
                                    File.Delete(m);
                                }
                                catch { }
                            }
                        }
                        /* Razer */
                        string md5 = @"C:\ProgramData\Razer\Services\Logs\";
                        if (Directory.Exists(md5))
                        {
                            var result = Directory.EnumerateFiles(@"C:\ProgramData\Razer\Services\Logs\", "*.log");
                            foreach (var m in result)
                            {
                                try {
                                    File.Delete(m);
                                }
                                catch { }
                            }
                        }
                        string md6 = @"C:\ProgramData\Razer\RazerCortexManifestRepair\Logs\";
                        if (Directory.Exists(md6))
                        {
                            var result = Directory.EnumerateFiles(@"C:\ProgramData\Razer\RazerCortexManifestRepair\Logs\", "*.log");
                            foreach (var m in result)
                            {
                                try { 
                                    File.Delete(m);
                                }
                                catch { }
                            }
                        }
                        string md7 = @"C:\ProgramData\Razer\BigDataSDK\Logs\";
                        if (Directory.Exists(md7))
                        {
                            var result = Directory.EnumerateFiles(@"C:\ProgramData\Razer\BigDataSDK\Logs\", "*.log");
                            foreach (var m in result)
                            {
                                try { 
                                    File.Delete(m);
                                }
                                catch { }
                            }
                        }
                        /* Windows */
                        string md8 = @"C:\ProgramData\Progress\Installer\Logs\";
                        if (Directory.Exists(md8))
                        {
                            var result = Directory.EnumerateFiles(@"C:\ProgramData\Progress\Installer\Logs\", "*.log");
                            foreach (var m in result)
                            {
                                try {
                                    File.Delete(m);
                                }
                                catch { }
                            }
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
                                try { 
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
                                try { 
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
                                try { 
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
                                try { 
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
                                try { 
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
                                try { 
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
                                try { 
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
                                try {
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
                                try {
                                    file.Delete();
                                }
                                catch (Exception ex) { }
                            }
                            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
                            {
                                try {
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
            });
        }
    }
}
