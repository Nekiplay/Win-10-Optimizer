﻿using Microsoft.Win32;
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

        private Task regedittask;
        private Task cheatcfg;
        private Task windows;
        private Task screenshots;
        private Task crashes;
        private Task backups;
        private Task mediafiles;
        private Task logsfiles;
        private Task cashfiles;
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
            ClearButton.Enabled = false;
            CleanerFileSettings cleanermethod = new CleanerFileSettings();
            CleanerRegeditSettings regeditmethod = new CleanerRegeditSettings();
            long deleted = 0;
            if (RegeditCheckBox.Checked)
            {
                regedittask = Task.Factory.StartNew(() =>
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
            }
            if (CheatConfigFilesCheckBox.Checked)
            {
                cheatcfg = Task.Factory.StartNew(() =>
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
            }
            if (WindowsFilesCheckBox.Checked)
            {
                windows = Task.Factory.StartNew(() =>
                {
                        /* Settings and Worker */
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOSOUND | RecycleFlags.SHERB_NOCONFIRMATION | RecycleFlags.SHERB_NOPROGRESSUI);

                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.windowsfiles)
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
                    foreach (CleanerFileSettings.ClearFiles clear in cleanermethod.screenshotfiles)
                    {
                        deleted += clear.Delete();
                    }

                    ScreenShotsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        ScreenShotsFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (CrashFilesCheckBox.Checked)
            {
                crashes = Task.Factory.StartNew(() =>
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
            }
            if (BackUpFilesCheckBox.Checked)
            {
                backups = Task.Factory.StartNew(() =>
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
            }
            if (MediaFilesCheckBox.Checked)
            {
                mediafiles = Task.Factory.StartNew(() =>
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
            }
            if (LogsFilesCheckBox.Checked)
            {
                logsfiles = Task.Factory.StartNew(() =>
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
            }
            if (CacheFilesCheckBox.Checked)
            {
                cashfiles = Task.Factory.StartNew(() =>
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
            }
            if (regedittask != null)
            {
                await regedittask;
            }
            if (windows != null)
            {
                await windows;
            }
            if (cheatcfg != null)
            {
                await cheatcfg;
            }
            if (cashfiles != null)
            {
                await cashfiles;
            }
            if (logsfiles != null)
            {
                await logsfiles;
            }
            if (mediafiles != null)
            {
                await mediafiles;
            }
            if (backups != null)
            {
                await backups;
            }
            if (crashes != null)
            {
                await crashes;
            }
            if (screenshots != null)
            {
                await screenshots;
            }
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
