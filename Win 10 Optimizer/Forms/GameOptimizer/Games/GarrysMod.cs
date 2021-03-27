using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_10_Optimizer.Utilites;
using static Win_10_Optimizer.Forms.GameOptimizer.GameOptimizerSettings;

namespace Win_10_Optimizer.Forms.GameOptimizer.Games
{
    public class GarrysMod : IOptimizer
    {
        readonly string path = SteamUtils.SteamPath + "\\steamapps\\common\\GarrysMod\\garrysmod\\cfg\\autoexec.cfg";

        public string GetName()
        {
            return "Garry's mod";
        }
        public bool FileDetect()
        {
            if (File.Exists(path)) { return true; }
            else { return false; }
        }
        public TabPage GetTabPage(Bunifu.UI.WinForms.BunifuPages pages)
        {
            TabPage page = new TabPage();

            page.BackColor = Color.FromArgb(44, 43, 60);
            page.Text = GetName();
            page.AccessibleName = GetName();

            /* Название игры */
            Label gamelabel = new Label();
            gamelabel.Text = GetName();
            gamelabel.AutoSize = true;
            gamelabel.ForeColor = Color.Gainsboro;
            gamelabel.Font = new Font("Arial", (float)8.25, FontStyle.Bold);
            /* Кнопка оптимизаций */
            Bunifu.UI.WinForms.BunifuButton.BunifuButton button = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            button.Text = "Optimize";
            button.Location = new Point(0, 15);
            button.Size = new Size(200, 30);
            button.Click += async (a, g) =>
            {
                NotificationManager.Manager notify = new NotificationManager.Manager();
                bool optimized = false;
                await Task.Factory.StartNew(() =>
                {
                    /* Вызываем очистку */
                    optimized = Optimize();
                });
                if (optimized)
                {
                    /* Уведомление об успешной оптимизаций */
                    notify.MaxTextWidth = 750;
                    notify.EnableOffset = false;
                    notify.Alert(GetName() + " optimized", NotificationManager.NotificationType.Info);
                    notify.StopTimer(1000);
                }
                else
                {
                    /* Уведомление об не успешной оптимизаций */
                    notify.MaxTextWidth = 750;
                    notify.EnableOffset = false;
                    notify.Alert(GetName() + " was not optimized", NotificationManager.NotificationType.Error);
                    notify.StopTimer(1000);
                }
            };
            /* Кнопка возврата */
            Bunifu.UI.WinForms.BunifuButton.BunifuButton backbutton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            backbutton.Text = "Back";
            backbutton.Location = new Point(0, 50);
            backbutton.Size = new Size(200, 30);
            backbutton.Click += (a, g) =>
            {
                /* Устанавливаем стартовую страницу */
                pages.SetPage(0);
            };

            /* Добавление контролов на страницу */
            page.Controls.Add(backbutton);
            page.Controls.Add(gamelabel);
            page.Controls.Add(button);
            return page;
        }
        public bool Optimize()
        {
            try
            {
                List<string> writelines = new List<string>
                    {
                        "datacachesize 2048",
                        "mem_max_heapsize_dedicated 4096",
                        "r_threaded_particles 1",
                        "r_threaded_renderables 1",
                        "cl_threaded_bone_setup 1",
                        "snd_mix_async 1",
                        "mat_queue_mode 2",
                        "host_thread_mode 1",
                        "r_queued_decals 1",
                        "M9KGasEffect 0",
                        "cl_ejectbrass 0",
                        "muzzleflash_light 0",
                        "r_drawflecks 0",
                        "cl_forcepreload 1",
                        "sv_forcepreload 1",
                        "gmod_mcore_test 1",
                        "mat_specular 0",
                    };

                List<string> textinfile = new List<string>();
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        textinfile.Add(sr.ReadLine());
                    }
                }
                if (textinfile.Count() == 0)
                {
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                    {
                        foreach (string writeline in writelines)
                        {
                            sw.WriteLine(writeline);
                        }
                        return true;
                    }
                }
                else if (textinfile.Count() != 0)
                {
                    List<string> writer = new List<string>();
                    foreach (string readline in textinfile)
                    {
                        string[] split = readline.Split(' ');
                        foreach (string writeline in writelines)
                        {
                            string[] split2 = writeline.Split(' ');
                            if (split[0] == split2[0] && split[1] != split2[1])
                            {
                                writer.Add(writeline);
                            }
                            else if (split[0] == split2[0] && split[1] == split2[1])
                            {
                                writer.Add(writeline);
                            }
                        }
                    }
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
                    {
                        foreach (string writeline in writer)
                        {
                            sw.WriteLine(writeline);
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
