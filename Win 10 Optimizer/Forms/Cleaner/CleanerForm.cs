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

        private Task cheatcfg;
        private Task windows;
        private Task screenshots;
        private Task gametrash;
        private Task backups;
        private Task mediafiles;
        private Task logsfiles;
        private Task cashfiles;
        private async void ClearButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                WindowsFilesCheckBox.Checked = true;
                ScreenShotsFilesCheckBox.Checked = true;
                GameTrashFilesCheckBox.Checked = true;
                MediaFilesCheckBox.Checked = true;
                LogsFilesCheckBox.Checked = true;
                CacheFilesCheckBox.Checked = true;
                BackUpFilesCheckBox.Checked = true;
                CheatConfigFilesCheckBox.Checked = true;
            }
            ClearButton.Enabled = false;
            CleanerSettings cleanermethod = new CleanerSettings();
            long deleted = 0;
            if (CheatConfigFilesCheckBox.Checked)
            {
                cheatcfg = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.cheatconfigfiles)
                    {
                        deleted += clear.Delete();
                    }

                    CheatConfigFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        CheatConfigFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (WindowsFilesCheckBox.Checked)
            {
                windows = Task.Factory.StartNew(() =>
                {
                        /* Settings and Worker */
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOSOUND | RecycleFlags.SHERB_NOCONFIRMATION | RecycleFlags.SHERB_NOPROGRESSUI);

                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.windowsfiles)
                    {
                        deleted += clear.Delete();
                    }

                    WindowsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        WindowsFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (ScreenShotsFilesCheckBox.Checked)
            {
                screenshots = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.screenshotfiles)
                    {
                        deleted += clear.Delete();
                    }

                    ScreenShotsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        ScreenShotsFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (GameTrashFilesCheckBox.Checked)
            {
                gametrash = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.steamfiles)
                    {
                        deleted += clear.Delete();
                    }

                    GameTrashFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        GameTrashFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (BackUpFilesCheckBox.Checked)
            {
                backups = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.backupfiles)
                    {
                        deleted += clear.Delete();
                    }

                    BackUpFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        BackUpFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (MediaFilesCheckBox.Checked)
            {
                mediafiles = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.videofiles)
                    {
                        deleted += clear.Delete();
                    }

                    MediaFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        MediaFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (LogsFilesCheckBox.Checked)
            {
                logsfiles = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.logsfiles)
                    {
                        deleted += clear.Delete();
                    }

                    LogsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        LogsFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (CacheFilesCheckBox.Checked)
            {
                cashfiles = Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.cachefiles)
                    {
                        deleted += clear.Delete();
                    }

                    ScreenShotsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        CacheFilesCheckBox.Checked = false;
                    }));
                });
            }
            await cashfiles;
            await logsfiles;
            await mediafiles;
            await backups;
            await gametrash;
            await screenshots;
            await windows;
            await cheatcfg;
            NotificationManager.Manager notify = new NotificationManager.Manager();
            notify.MaxTextWidth = 150;
            notify.EnableOffset = false;
            notify.Alert("Очищено: " + BytesToString(deleted), NotificationManager.NotificationType.Info);
            notify.StopTimer(1000);
            ClearButton.Enabled = true;
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
