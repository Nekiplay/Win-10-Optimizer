﻿using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
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
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ActivateButton(OptimizeButton, RGBColors.color1);
            OpenChildForm(optimize, false);
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

        readonly Forms.EnergyForm optimize = new Forms.EnergyForm();
        readonly Forms.Cleaner cleaner = new Forms.Cleaner();

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CleanerButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ActivateButton(sender, RGBColors.color2);
                OpenChildForm(cleaner, false);
            }
            else if (e.Button == MouseButtons.Middle)
            {

            }
        }

        private void OptimizeButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ActivateButton(sender, RGBColors.color1);
                OpenChildForm(optimize, false);
            }
        }
    }
}