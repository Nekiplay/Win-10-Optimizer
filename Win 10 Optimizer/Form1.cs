using Bunifu.Framework.UI;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            panelMenu.Controls.Add(leftBorderBtn);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Opacity = 100;
        }
        private BunifuFlatButton currentBtn;
        public void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (BunifuFlatButton)senderBtn;
                currentBtn.ForeColor = color;
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
            ActivateButton(bunifuFlatButton1, RGBColors.color1);
            OpenChildForm(new Forms.EnergyOptimize(), true);
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            WinAPI.Programm.MoveForm(this);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Forms.EnergyOptimize(), true);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new Forms.Cleaner(), true);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new Forms.Services(), true);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
