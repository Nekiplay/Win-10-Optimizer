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
        GameOptimizerSettings settings = new GameOptimizerSettings();
        private void GameOptimizerForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine(SteamUtils.CurrentUserSteamID);
            foreach (GameOptimizerSettings.GameOptimizerFinderAndConfigurator configurator in settings.games)
            {
                if (configurator.FileDetect())
                {
                    TabPage page = new TabPage();
                    page.BackColor = Color.FromArgb(44, 43, 60);
                    page.Text = configurator.game_name;
                    page.AccessibleName = configurator.game_name;

                    /* Название игры */
                    Label gamelabel = new Label();
                    gamelabel.Text = configurator.game_name;
                    gamelabel.AutoSize = true;
                    gamelabel.ForeColor = Color.Gainsboro;
                    gamelabel.Font = new Font("Arial", (float)8.25, FontStyle.Bold);
                    /* Кнопка оптимизаций */
                    Bunifu.UI.WinForms.BunifuButton.BunifuButton button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
                    button.Text = "Оптимизировать";
                    button.Location = new Point(0, 15);
                    button.Size = new Size(200, 30);
                    button.Click += (a, g) =>
                    {
                        configurator.Optimize();

                        /* Уведомление */
                        NotificationManager.Manager notify = new NotificationManager.Manager();
                        notify.MaxTextWidth = 750;
                        notify.EnableOffset = false;
                        notify.Alert(configurator.game_name + " оптимизирован'а", NotificationManager.NotificationType.Info);
                        notify.StopTimer(1000);
                    };
                    /* Кнопка возврата */
                    Bunifu.UI.WinForms.BunifuButton.BunifuButton backbutton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
                    backbutton.Text = "Назад";
                    backbutton.Location = new Point(0, 50);
                    backbutton.Size = new Size(200, 30);
                    backbutton.Click += (a, g) =>
                    {
                        bunifuPages1.SetPage(0);
                    };

                    /* Добавление контролов на страницу */
                    page.Controls.Add(backbutton);
                    page.Controls.Add(gamelabel);
                    page.Controls.Add(button);

                    bunifuPages1.TabPages.Add(page);
                    /* Добавление кнопки перехода на страницу */
                    Bunifu.UI.WinForms.BunifuButton.BunifuButton pagebutton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
                    pagebutton.Text = configurator.game_name;
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
                    bunifuPages1.TabPages[0].Controls.Add(pagebutton);
                }
            }
        }

        private void GamesLayouot_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
