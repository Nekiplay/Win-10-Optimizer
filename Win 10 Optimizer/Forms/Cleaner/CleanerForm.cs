using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_10_Optimizer.Forms.Cleaner;

namespace Win_10_Optimizer.Forms
{
    public partial class CleanerForm : Form
    {
        public CleanerForm()
        {
            InitializeComponent();
        }
        public async Task Optimize()
        {
            ClearButton.Invoke(new MethodInvoker(() =>
            {
                ClearButton.Enabled = false;
            }));
            CleanerFileSettings cleanermethod = new CleanerFileSettings();
            CleanerRegeditSettings regeditmethod = new CleanerRegeditSettings();
            long deleted = 0;
            if (RegeditCheckBox.Checked)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerRegeditSettings.RegeditFiles clear in regeditmethod.lastactivity)
                    {
                        clear.Delete();
                    }

                    RegeditCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        RegeditCheckBox.Checked = false;
                    }));
                });
                tasks.Add(temp);
                Task updatecounter = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            string newclears = wc.DownloadString("http://nekiplay.000webhostapp.com/Win10Optimizer/Clear.php?type=Registry");
                            RegistryClears.Invoke(new MethodInvoker(() =>
                            {
                                RegistryClears.Text = newclears + " clears";
                                RegistryClears.Visible = true;
                            }));
                        }
                    }
                    catch { }
                });
                tasks.Add(updatecounter);
            }
            if (CheatConfigFilesCheckBox.Checked)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.cheatconfigfiles)
                    {
                        deleted += clear.Delete();
                    }

                    CheatConfigFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        CheatConfigFilesCheckBox.Checked = false;
                    }));
                });
                tasks.Add(temp);
                Task updatecounter = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            string newclears = wc.DownloadString("http://nekiplay.000webhostapp.com/Win10Optimizer/Clear.php?type=CheatSettings");
                            CheatSettingsClears.Invoke(new MethodInvoker(() =>
                            {
                                CheatSettingsClears.Text = newclears + " clears";
                                CheatSettingsClears.Visible = true;
                            }));
                        }
                    }
                    catch { }
                });
                tasks.Add(updatecounter);
            }
            if (WindowsFilesCheckBox.Checked)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.windowsfiles)
                    {
                        deleted += clear.Delete();
                    }

                    WindowsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        WindowsFilesCheckBox.Checked = false;
                    }));
                });
                tasks.Add(temp);
                Task temp2 = Task.Factory.StartNew(() =>
                {
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOSOUND | RecycleFlags.SHERB_NOCONFIRMATION | RecycleFlags.SHERB_NOPROGRESSUI);
                });
                tasks.Add(temp2);
                Task updatecounter = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            string newclears = wc.DownloadString("http://nekiplay.000webhostapp.com/Win10Optimizer/Clear.php?type=Windows");
                            WindowsGarbageClears.Invoke(new MethodInvoker(() =>
                            {
                                WindowsGarbageClears.Text = newclears + " clears";
                                WindowsGarbageClears.Visible = true;
                            }));
                        }
                    }
                    catch { }
                });
                tasks.Add(updatecounter);
            }
            if (ScreenShotsFilesCheckBox.Checked)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.screenshotfiles)
                    {
                        deleted += clear.Delete();
                    }

                    ScreenShotsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        ScreenShotsFilesCheckBox.Checked = false;
                    }));
                });
                tasks.Add(temp);
                Task updatecounter = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            string newclears = wc.DownloadString("http://nekiplay.000webhostapp.com/Win10Optimizer/Clear.php?type=Screenshots");
                            ScreenshotsClears.Invoke(new MethodInvoker(() =>
                            {
                                ScreenshotsClears.Text = newclears + " clears";
                                ScreenshotsClears.Visible = true;
                            }));
                        }
                    }
                    catch { }
                });
                tasks.Add(updatecounter);
            }
            if (CrashFilesCheckBox.Checked)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.crashfiles)
                    {
                        deleted += clear.Delete();
                    }

                    CrashFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        CrashFilesCheckBox.Checked = false;
                    }));
                });
                tasks.Add(temp);
                Task updatecounter = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            string newclears = wc.DownloadString("http://nekiplay.000webhostapp.com/Win10Optimizer/Clear.php?type=Crashes");
                            CrashesClears.Invoke(new MethodInvoker(() =>
                            {
                                CrashesClears.Text = newclears + " clears";
                                CrashesClears.Visible = true;
                            }));
                        }
                    }
                    catch { }
                });
                tasks.Add(updatecounter);
            }
            if (BackUpFilesCheckBox.Checked)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.backupfiles)
                    {
                        deleted += clear.Delete();
                    }

                    BackUpFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        BackUpFilesCheckBox.Checked = false;
                    }));
                });
                tasks.Add(temp);
                Task updatecounter = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            string newclears = wc.DownloadString("http://nekiplay.000webhostapp.com/Win10Optimizer/Clear.php?type=Backups");
                            BackupsClears.Invoke(new MethodInvoker(() =>
                            {
                                BackupsClears.Text = newclears + " clears";
                                BackupsClears.Visible = true;
                            }));
                        }
                    }
                    catch { }
                });
                tasks.Add(updatecounter);
            }
            if (MediaFilesCheckBox.Checked)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.videofiles)
                    {
                        deleted += clear.Delete();
                    }

                    MediaFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        MediaFilesCheckBox.Checked = false;
                    }));
                });
                tasks.Add(temp);
                Task updatecounter = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            string newclears = wc.DownloadString("http://nekiplay.000webhostapp.com/Win10Optimizer/Clear.php?type=Media");
                            MediaClears.Invoke(new MethodInvoker(() =>
                            {
                                MediaClears.Text = newclears + " clears";
                                MediaClears.Visible = true;
                            }));
                        }
                    }
                    catch { }
                });
                tasks.Add(updatecounter);
            }
            if (LogsFilesCheckBox.Checked)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.logsfiles)
                    {
                        deleted += clear.Delete();
                    }

                    LogsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        LogsFilesCheckBox.Checked = false;
                    }));
                });
                tasks.Add(temp);
                Task updatecounter = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            string newclears = wc.DownloadString("http://nekiplay.000webhostapp.com/Win10Optimizer/Clear.php?type=Logs");
                            LogsClears.Invoke(new MethodInvoker(() =>
                            {
                                LogsClears.Text = newclears + " clears";
                                LogsClears.Visible = true;
                            }));
                        }
                    } catch { }
                });
                tasks.Add(updatecounter);
            }
            if (CacheFilesCheckBox.Checked)
            {
                Task temp = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.cachefiles)
                    {
                        deleted += clear.Delete();
                    }

                    ScreenShotsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        CacheFilesCheckBox.Checked = false;
                    }));
                });
                tasks.Add(temp);
                Task updatecounter = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            string newclears = wc.DownloadString("http://nekiplay.000webhostapp.com/Win10Optimizer/Clear.php?type=Cache");
                            CacheClears.Invoke(new MethodInvoker(() =>
                            {
                                CacheClears.Text = newclears + " clears";
                                CacheClears.Visible = true;
                            }));
                        }
                    }
                    catch { }
                });
                tasks.Add(updatecounter);
            }
            foreach (Task task in tasks)
            {
                await task;
            }
            if (deleted != 0)
            {
                NotificationManager.Manager notify = new NotificationManager.Manager();
                notify.MaxTextWidth = 150;
                notify.EnableOffset = false;
                notify.Alert("Cleared: " + BytesToString(deleted), NotificationManager.NotificationType.Info);
                notify.StopTimer(1000);
            }
            ClearButton.Invoke(new MethodInvoker(() =>
            {
                ClearButton.Enabled = true;
            }));
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

        private List<Task> tasks = new List<Task>();
        private async void ClearButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                CheckedAll();
            }
            await Optimize();
        }
        static String BytesToString(long byteCount)
        {
            string[] suf = { "Byte", "KB", "MB", "GB", "TB", "PB", "EB" }; //
            if (byteCount == 0)
            {
                return "0" + suf[0];
            }
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
        public void CheckedAll()
        {
            RegeditCheckBox.Invoke(new MethodInvoker(() =>
            {
                RegeditCheckBox.Checked = true;
            }));
            CheatConfigFilesCheckBox.Invoke(new MethodInvoker(() =>
            {
                CheatConfigFilesCheckBox.Checked = true;
            }));
            WindowsFilesCheckBox.Invoke(new MethodInvoker(() =>
            {
                WindowsFilesCheckBox.Checked = true;
            }));
            ScreenShotsFilesCheckBox.Invoke(new MethodInvoker(() =>
            {
                ScreenShotsFilesCheckBox.Checked = true;
            }));
            CrashFilesCheckBox.Invoke(new MethodInvoker(() =>
            {
                CrashFilesCheckBox.Checked = true;
            }));
            MediaFilesCheckBox.Invoke(new MethodInvoker(() =>
            {
                MediaFilesCheckBox.Checked = true;
            }));
            LogsFilesCheckBox.Invoke(new MethodInvoker(() =>
            {
                LogsFilesCheckBox.Checked = true;
            }));
            CacheFilesCheckBox.Invoke(new MethodInvoker(() =>
            {
                CacheFilesCheckBox.Checked = true;
            }));
            BackUpFilesCheckBox.Invoke(new MethodInvoker(() =>
            {
                BackUpFilesCheckBox.Checked = true;
            }));
        }
        private async void UpdateCounters()
        {
            List<Task> tasks = new List<Task>();
            Task LogsClearsTask = Task.Factory.StartNew(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        Uri ur = new Uri("http://nekiplay.000webhostapp.com/Win10Optimizer/ClearGet.php?type=Logs");
                        string downloaded = await wc.DownloadStringTaskAsync(ur);
                        LogsClears.Invoke(new MethodInvoker(() =>
                        {
                            LogsClears.Text = downloaded + " clears";
                            LogsClears.Visible = true;
                        }));
                    }
                    catch
                    {
                        LogsClears.Invoke(new MethodInvoker(() =>
                        {
                            LogsClears.Text = "0 clears";
                            LogsClears.Visible = false;
                        }));
                    }
                }
            });
            Task CacheClearsTask = Task.Factory.StartNew(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        Uri ur = new Uri("http://nekiplay.000webhostapp.com/Win10Optimizer/ClearGet.php?type=Cache");
                        string downloaded = await wc.DownloadStringTaskAsync(ur);
                        CacheClears.Invoke(new MethodInvoker(() =>
                        {
                            CacheClears.Text = downloaded + " clears";
                            CacheClears.Visible = true;
                        }));
                    }
                    catch
                    {
                        CacheClears.Invoke(new MethodInvoker(() =>
                        {
                            CacheClears.Text = "0 clears";
                            CacheClears.Visible = false;
                        }));
                    }
                }
            });
            Task MediaClearsTask = Task.Factory.StartNew(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        Uri ur = new Uri("http://nekiplay.000webhostapp.com/Win10Optimizer/ClearGet.php?type=Media");
                        string downloaded = await wc.DownloadStringTaskAsync(ur);
                        MediaClears.Invoke(new MethodInvoker(() =>
                        {
                            MediaClears.Text = downloaded + " clears";
                            MediaClears.Visible = true;
                        }));
                    }
                    catch
                    {
                        MediaClears.Invoke(new MethodInvoker(() =>
                        {
                            MediaClears.Text = "0 clears";
                            MediaClears.Visible = false;
                        }));
                    }
                }
            });
            Task WindowsClearsTask = Task.Factory.StartNew(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        Uri ur = new Uri("http://nekiplay.000webhostapp.com/Win10Optimizer/ClearGet.php?type=Windows");
                        string downloaded = await wc.DownloadStringTaskAsync(ur);
                        WindowsGarbageClears.Invoke(new MethodInvoker(() =>
                        {
                            WindowsGarbageClears.Text = downloaded + " clears";
                            WindowsGarbageClears.Visible = true;
                        }));
                    }
                    catch
                    {
                        WindowsGarbageClears.Invoke(new MethodInvoker(() =>
                        {
                            WindowsGarbageClears.Text = "0 clears";
                            WindowsGarbageClears.Visible = false;
                        }));
                    }
                }
            });
            Task ScreenshotsClearsTask = Task.Factory.StartNew(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        Uri ur = new Uri("http://nekiplay.000webhostapp.com/Win10Optimizer/ClearGet.php?type=Screenshots");
                        string downloaded = await wc.DownloadStringTaskAsync(ur);
                        ScreenshotsClears.Invoke(new MethodInvoker(() =>
                        {
                            ScreenshotsClears.Text = downloaded + " clears";
                            ScreenshotsClears.Visible = true;
                        }));
                    }
                    catch
                    {
                        ScreenshotsClears.Invoke(new MethodInvoker(() =>
                        {
                            ScreenshotsClears.Text = "0 clears";
                            ScreenshotsClears.Visible = false;
                        }));
                    }
                }
            });
            Task RegistryClearsTask = Task.Factory.StartNew(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        Uri ur = new Uri("http://nekiplay.000webhostapp.com/Win10Optimizer/ClearGet.php?type=Registry");
                        string downloaded = await wc.DownloadStringTaskAsync(ur);
                        RegistryClears.Invoke(new MethodInvoker(() =>
                        {
                            RegistryClears.Text = downloaded + " clears";
                            RegistryClears.Visible = true;
                        }));
                    }
                    catch
                    {
                        RegistryClears.Invoke(new MethodInvoker(() =>
                        {
                            RegistryClears.Text = "0 clears";
                            RegistryClears.Visible = false;
                        }));
                    }
                }
            });
            Task CrashesClearsTask = Task.Factory.StartNew(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        Uri ur = new Uri("http://nekiplay.000webhostapp.com/Win10Optimizer/ClearGet.php?type=Crashes");
                        string downloaded = await wc.DownloadStringTaskAsync(ur);
                        CrashesClears.Invoke(new MethodInvoker(() =>
                        {
                            CrashesClears.Text = downloaded + " clears";
                            CrashesClears.Visible = true;
                        }));
                    }
                    catch
                    {
                        CrashesClears.Invoke(new MethodInvoker(() =>
                        {
                            CrashesClears.Text = "0 clears";
                            CrashesClears.Visible = false;
                        }));
                    }
                }
            });
            Task BackupsClearsTask = Task.Factory.StartNew(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        Uri ur = new Uri("http://nekiplay.000webhostapp.com/Win10Optimizer/ClearGet.php?type=Backups");
                        string downloaded = await wc.DownloadStringTaskAsync(ur);
                        BackupsClears.Invoke(new MethodInvoker(() =>
                        {
                            BackupsClears.Text = downloaded + " clears";
                            BackupsClears.Visible = true;
                        }));
                    }
                    catch
                    {
                        BackupsClears.Invoke(new MethodInvoker(() =>
                        {
                            BackupsClears.Text = "0 clears";
                            BackupsClears.Visible = false;
                        }));
                    }
                }
            });
            Task CheatSettingsClearsTask = Task.Factory.StartNew(async () =>
            {
                using (WebClient wc = new WebClient())
                {
                    try
                    {
                        Uri ur = new Uri("http://nekiplay.000webhostapp.com/Win10Optimizer/ClearGet.php?type=CheatSettings");
                        string downloaded = await wc.DownloadStringTaskAsync(ur);
                        CheatSettingsClears.Invoke(new MethodInvoker(() =>
                        {
                            CheatSettingsClears.Text = downloaded + " clears";
                            CheatSettingsClears.Visible = true;
                        }));
                    }
                    catch
                    {
                        CheatSettingsClears.Invoke(new MethodInvoker(() =>
                        {
                            CheatSettingsClears.Text = "0 clears";
                            CheatSettingsClears.Visible = false;
                        }));
                    }
                }
            });
            tasks.Add(CheatSettingsClearsTask);
            tasks.Add(LogsClearsTask);
            tasks.Add(CacheClearsTask);
            tasks.Add(MediaClearsTask);
            tasks.Add(WindowsClearsTask);
            tasks.Add(ScreenshotsClearsTask);
            tasks.Add(RegistryClearsTask);
            tasks.Add(CrashesClearsTask);
            tasks.Add(BackupsClearsTask);
            foreach (Task t in tasks)
            {
                await t;
            }
        }
        private async void CleanerForm_Load(object sender, EventArgs e)
        {
            UpdateCounters();
        }
    }
}
    