using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_10_Optimizer.Utilites;

namespace Win_10_Optimizer.Forms.GameOptimizer
{
    public partial class GameOptimizerForm : Form
    {
        public GameOptimizerForm()
        {
            InitializeComponent();
        }
        readonly GameOptimizerSettings settings = new GameOptimizerSettings();
        private void GameOptimizerForm_Load(object sender, EventArgs e)
        {
            foreach (GameOptimizerSettings.IOptimizer configurator in settings.games)
            {
                if (configurator.FileDetect())
                {
                    TabPage page = configurator.GetTabPage(bunifuPages1);
                    bunifuPages1.TabPages.Add(page);

                    /* Добавление кнопки перехода на страницу */
                    Bunifu.UI.WinForms.BunifuButton.BunifuButton pagebutton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
                    pagebutton.Text = configurator.GetName();
                    pagebutton.Size = new Size(200, 30);
                    if (bunifuPages1.TabPages.Count - 2 == 0)
                    {
                        pagebutton.Location = new Point(0, 0);
                    }
                    else
                    {
                        pagebutton.Location = new Point(0, 35 * (bunifuPages1.TabPages.Count - 2));
                    }
                    pagebutton.Click += (a, g) =>
                    {
                        bunifuPages1.Page = page;
                    };
                    /* Добавляем кнопку на главную страницу */
                    bunifuPages1.TabPages[0].Controls.Add(pagebutton);
                }
            }
        }
    }
}
