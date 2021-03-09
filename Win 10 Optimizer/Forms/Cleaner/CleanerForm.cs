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

        private void ClearButton_MouseClick(object sender, MouseEventArgs e)
        {
            ClearButton.Enabled = false;
            CleanerSettings cleanermethod = new CleanerSettings();
            if (WindowsFilesCheckBox.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    /* Settings and Worker */
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOSOUND | RecycleFlags.SHERB_NOCONFIRMATION | RecycleFlags.SHERB_NOPROGRESSUI);

                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.windowsfiles)
                    {
                        clear.Delete();
                    }

                    WindowsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        WindowsFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (ScreenShotsFilesCheckBox.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.screenshotfiles)
                    {
                        clear.Delete();
                    }

                    ScreenShotsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        ScreenShotsFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (GameTrashFilesCheckBox.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.steamfiles)
                    {
                        clear.Delete();
                    }

                    GameTrashFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        GameTrashFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (MediaFilesCheckBox.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.videofiles)
                    {
                        clear.Delete();
                    }

                    MediaFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        MediaFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (LogsFilesCheckBox.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.logsfiles)
                    {
                        clear.Delete();
                    }

                    LogsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        LogsFilesCheckBox.Checked = false;
                    }));
                });
            }
            if (CacheFilesCheckBox.Checked)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (CleanerSettings.ClearFiles clear in cleanermethod.cachefiles)
                    {
                        clear.Delete();
                    }

                    ScreenShotsFilesCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        CacheFilesCheckBox.Checked = false;
                    }));
                });
            }
            ClearButton.Enabled = true;
        }
    }
}
