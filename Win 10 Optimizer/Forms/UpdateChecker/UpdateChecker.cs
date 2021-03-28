using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Forms.UpdateChecker
{
    public static class UpdateChecker
    {
        public static bool NeedUpdate
        {
            get
            {
                Console.WriteLine(int.Parse(LastVersion.Replace(".", "").Replace("v", "")));
                Console.WriteLine(int.Parse(CurrentVersion.Replace(".", "").Replace("v", "")));
                return int.Parse(LastVersion.Replace(".", "").Replace("v", "")) < int.Parse(CurrentVersion.Replace(".", "").Replace("v", ""));
            }
        }
        public static string CurrentVersion
        {
            get
            {
                return Properties.Resources.Version;
            }
        }
        public static string LastVersion
        {
            get
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        string githubversion = wc.DownloadString(@"https://raw.githubusercontent.com/Nekiplay/Win-10-Optimizer/master/Win%2010%20Optimizer/Resources/Version.txt");
                        return githubversion;
                    }
                }
                catch { return Properties.Resources.Version; }
            }
        }
    }
}
