using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_10_Optimizer.Forms.Settings;

namespace Win_10_Optimizer
{
    static class Program
    {
        /// <summary>
        /// Главная форма приложения.
        /// </summary>
        public static MainForm mainform;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainform = new MainForm();
            Application.Run(mainform);
        }
    }
}
