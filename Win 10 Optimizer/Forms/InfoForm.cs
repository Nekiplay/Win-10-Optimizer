using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_10_Optimizer.Forms
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void GameOptimizeButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcommunity.com/tradeoffer/new/?partner=392286814&token=RfNNLKbN");
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://vk.com/neki_play");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcommunity.com/profiles/76561198352552542");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Process.Start("https://yougame.biz/threads/185427");
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {

        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            cv.Text = "Current verson: " + UpdateChecker.UpdateChecker.CurrentVersion;
            lv.Text = "Last verson: " + UpdateChecker.UpdateChecker.LastVersion;
            if (UpdateChecker.UpdateChecker.NeedUpdate)
            {
                panel2.Size = new Size(130, 76);
                bunifuButton4.Visible = true;
            }
            else
            {
                panel2.Size = new Size(130, 54);
                bunifuButton4.Visible = false;
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Nekiplay/Win-10-Optimizer/releases/tag/" + UpdateChecker.UpdateChecker.LastVersion);
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCmBN0V9320Laqnjv-ZOCkKg");
        }
    }
}
