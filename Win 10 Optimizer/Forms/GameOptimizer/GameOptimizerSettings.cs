using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_10_Optimizer.Forms.GameOptimizer.Games;
using Win_10_Optimizer.Utilites;

namespace Win_10_Optimizer.Forms.GameOptimizer
{
    public class GameOptimizerSettings
    {
        public List<IOptimizer> games = new List<IOptimizer>();

        public GameOptimizerSettings()
        {
            games.Add(new Minecraft());
            games.Add(new GarrysMod());
        }

        public interface IOptimizer
        {
            string GetName();     // Имя игры
            bool Optimize();      // Оптимизация
            bool FileDetect();    // Детект файла
            TabPage GetTabPage(Bunifu.UI.WinForms.BunifuPages pages); // Получение страницы
        }
    }
}
