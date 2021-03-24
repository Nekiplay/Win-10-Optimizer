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
            ClearButton.Enabled = false;
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
            }
            foreach (Task task in tasks)
            {
                await task;
            }
            NotificationManager.Manager notify = new NotificationManager.Manager();
            notify.MaxTextWidth = 150;
            notify.EnableOffset = false;
            notify.Alert("Очищено: " + BytesToString(deleted), NotificationManager.NotificationType.Info);
            notify.StopTimer(1000);
            ClearButton.Enabled = true;
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
                RegeditCheckBox.Checked = true;
                CheatConfigFilesCheckBox.Checked = true;
                WindowsFilesCheckBox.Checked = true;
                ScreenShotsFilesCheckBox.Checked = true;
                CrashFilesCheckBox.Checked = true;
                MediaFilesCheckBox.Checked = true;
                LogsFilesCheckBox.Checked = true;
                CacheFilesCheckBox.Checked = true;
                BackUpFilesCheckBox.Checked = true;
            }
            await Optimize();
        }
        static String BytesToString(long byteCount)
        {
            string[] suf = { "Байт", "KB", "MB", "GB", "TB", "PB", "EB" }; //
            if (byteCount == 0)
            {
                return "0" + suf[0];
            }
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }
}
