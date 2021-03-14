using Microsoft.Win32;
using System;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_10_Optimizer.Forms
{
    public partial class ServicesForm : Form
    {
        public ServicesForm()
        {
            InitializeComponent();
        }

        private void Services_Load(object sender, System.EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ServiceController windowsupdater = new ServiceController("Центр обновления Windows");
                if (windowsupdater != null)
                {
                    if (windowsupdater.Status == ServiceControllerStatus.Stopped && windowsupdater.StartType == ServiceStartMode.Disabled)
                    {
                        WindowsUpdaterCheckBox.Invoke(new MethodInvoker(() =>
                        {
                            WindowsUpdaterCheckBox.Checked = true;
                        }));
                    }
                }
            });
            Task.Factory.StartNew(() =>
            {
                RegistryKey reg = Registry.LocalMachine;
                RegistryKey windowsdefender = reg.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender");
                if (windowsdefender.GetValue("DisableAntiSpyware") != null && windowsdefender.GetValue("DisableAntiSpyware").ToString() == "1")
                {
                    WindowsDefenderCheckBox.Invoke(new MethodInvoker(() =>
                    {
                        WindowsDefenderCheckBox.Checked = true;
                    }));
                }
            });
        }

        private async void WindowsUpdaterCheckBox_OnChange(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                ServiceController windowsupdater = new ServiceController("Центр обновления Windows");
                if (windowsupdater != null)
                {
                    if (WindowsUpdaterCheckBox.Checked)
                    {
                        Forms.Services.ServiceHelper.ChangeStartMode(windowsupdater, ServiceStartMode.Disabled);
                        if (windowsupdater.Status != ServiceControllerStatus.Stopped)
                        {
                            windowsupdater.Stop();
                        }
                    }
                    else
                    {
                        Forms.Services.ServiceHelper.ChangeStartMode(windowsupdater, ServiceStartMode.Automatic);
                        if (windowsupdater.Status == ServiceControllerStatus.Stopped)
                        {
                            windowsupdater.Start();
                        }
                    }
                }
            });
        }

        private async void WindowsDefenderCheckBox_OnChange(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                RegistryKey reg = Registry.LocalMachine;
                RegistryKey windowsdefender = reg.OpenSubKey(@"SOFTWARE\Policies\Microsoft\Windows Defender", true);
                if (WindowsDefenderCheckBox.Checked)
                {
                    windowsdefender.SetValue("DisableAntiSpyware", 1);
                }
                else
                {
                    windowsdefender.DeleteValue("DisableAntiSpyware");
                }
            });
        }
    }
}
