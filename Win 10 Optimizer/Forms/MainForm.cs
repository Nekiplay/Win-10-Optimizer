using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_10_Optimizer.Forms.Settings;

namespace Win_10_Optimizer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            leftBorderBtn = new Panel();
            panelMenu.Controls.Add(leftBorderBtn);
            this.Opacity = 100;
            this.bunifuPictureBox1.Image = WinAPI.Programm.GetUserTile(Environment.UserDomainName);
        }
        private BunifuButton currentBtn;
        public void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (BunifuButton)senderBtn;
                //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                //currentBtn.BackColor1 = Color.FromArgb(40, 96, 144);
                //currentBtn.IdleFillColor = Color.FromArgb(40, 96, 144);
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Size = new Size(7, currentBtn.Size.Height);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
            }
        }
        public void DisableButton()
        {
            if (currentBtn != null)
            {
                //currentBtn.IdleFillColor = Color.Transparent;

                currentBtn.ForeColor = Color.Gainsboro;
                //currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            }
        }
        public UserSettings userSettings;
        private async void Form1_Load(object sender, EventArgs e)
        {
            NotificationManager.Manager notify = null;
            if (Forms.UpdateChecker.UpdateChecker.NeedUpdate)
            {
                notify = new NotificationManager.Manager();
                notify.MaxTextWidth = 900;
                notify.EnableOffset = false;
                notify.Alert("Необходимо установить обновление", NotificationManager.NotificationType.Warning);
                notify.StopTimer(1000 * 10);
            }
            userSettings = UserSettings.Load();
            ActivateButton(GameOptimizeButton, RGBColors.color1);
            OpenChildForm(gameoptimize, false);
        }
        private readonly Panel leftBorderBtn;
        private Form currentChildForm;
        private string currentChildFormname;
        public void OpenChildForm(Form childForm, bool newform = false)
        {
            if (currentChildForm != childForm && currentChildFormname != childForm.Name)
            {
                //open only form
                if (currentChildForm != null)
                {
                    if (newform)
                    {
                        currentChildForm.Close();
                    }
                    panelDesktop.Controls.Clear();
                }
                currentChildForm = childForm;
                currentChildFormname = childForm.Name;
                //End
                childForm.BackColor = panelDesktop.BackColor;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelDesktop.Controls.Add(childForm);
                panelDesktop.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
        }
        public struct RGBColors
        {
            public static readonly Color color1 = Color.FromArgb(172, 126, 241);
            public static readonly Color color2 = Color.FromArgb(249, 118, 176);
            public static readonly Color color3 = Color.FromArgb(253, 138, 114);
        }

        public readonly Forms.SettingsForm settings = new Forms.SettingsForm();
        readonly Forms.OptimizeForm optimize = new Forms.OptimizeForm();
        readonly Forms.CleanerForm cleaner = new Forms.CleanerForm();
        readonly Forms.ServicesForm services = new Forms.ServicesForm();
        readonly Forms.GameOptimizer.GameOptimizerForm gameoptimize = new Forms.GameOptimizer.GameOptimizerForm();

        private void GameOptimizeButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(gameoptimize, false);
        }

        private void OptimizeButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(optimize, false);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(services, false);
        }

        private void CleanerButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(cleaner, false);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(settings, false);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
