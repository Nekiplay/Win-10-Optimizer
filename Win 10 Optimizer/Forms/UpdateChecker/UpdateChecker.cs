﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Forms.UpdateChecker
{
    public class UpdateChecker
    {
        public bool NeedUpdate
        {
            get
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        string githubversion = wc.DownloadString(@"https://raw.githubusercontent.com/Nekiplay/Win-10-Optimizer/master/Win%2010%20Optimizer/Resources/Version.txt");
                        using (StreamReader output = new StreamReader(Properties.Resources.Version))
                        {
                            string currentversion = output.ReadToEnd();
                            if (githubversion == currentversion)
                            {
                                return true;
                            }
                        }
                    }
                } catch { }
                return false;
            }
        }
    }
}
