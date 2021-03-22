using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_10_Optimizer.Utilites;

namespace Win_10_Optimizer.Forms.GameOptimizer
{
    public class GameOptimizerSettings
    {
        public List<GameOptimizerFinderAndConfigurator> games = new List<GameOptimizerFinderAndConfigurator>();

        public GameOptimizerSettings()
        {
            string steamdir = SteamUtils.SteamPath;
            List<string> gmodcontent = new List<string>
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
                "snd_mix_async 1",
                "cl_forcepreload 1",
                "sv_forcepreload 1",
                "gmod_mcore_test 1",
                "mat_specular 0",
            };
            //games.Add(new GameOptimizerFinderAndConfigurator("Minecraft", steamdir + "\\steamapps\\common\\GarrysMod\\garrysmod\\cfg\\autoexec.cfg", gmodcontent));
            games.Add(new GameOptimizerFinderAndConfigurator("Garry's mod", steamdir + "\\steamapps\\common\\GarrysMod\\garrysmod\\cfg\\autoexec.cfg", gmodcontent));
            //games.Add(new GameOptimizerFinderAndConfigurator("CS: GO", steamdir + "\\steamapps\\common\\GarrysMod\\garrysmod\\cfg\\autoexec.cfg", gmodcontent));
        }

        public class GameOptimizerFinderAndConfigurator
        {
            private List<string> file_content;
            public readonly string game_name;
            private readonly string game_file;
            public GameOptimizerFinderAndConfigurator(string game_name, string game_path_to_file, string file_content)
            {
                this.game_file = game_path_to_file;
                this.game_name = game_name;
                List<string> temp_file_content = new List<string>();
                temp_file_content.Add(file_content);
                this.file_content = temp_file_content;
            }
            public GameOptimizerFinderAndConfigurator(string game_name, string game_path_to_file, List<string> file_content)
            {
                this.game_file = game_path_to_file;
                this.game_name = game_name;
                this.file_content = file_content;
            }
            public bool FileDetect()
            {
                if (File.Exists(this.game_file)) { return true; }
                else { return false; }
            }
            public bool Optimize()
            {
                if (FileDetect())
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(this.game_file, false, System.Text.Encoding.UTF8))
                        {
                            foreach (string content in this.file_content)
                            {
                                sw.WriteLine(content);
                            }
                            return true;
                        }
                    }
                    catch { return false; }
                }
                else { return false; }
            }
        }
    }
}
