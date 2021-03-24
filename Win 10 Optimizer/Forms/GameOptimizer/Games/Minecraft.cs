using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win_10_Optimizer.Utilites;
using static Win_10_Optimizer.Forms.GameOptimizer.GameOptimizerSettings;

namespace Win_10_Optimizer.Forms.GameOptimizer.Games
{
    public class Minecraft : IOptimizer
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\optionsof.txt";

        public string GetName()
        {
            return "Minecraft";
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
            button.Text = "Оптимизировать";
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
                    notify.Alert(GetName() + " оптимизирован", NotificationManager.NotificationType.Info);
                    notify.StopTimer(1000);
                }
                else
                {
                    /* Уведомление об не успешной оптимизаций */
                    notify.MaxTextWidth = 750;
                    notify.EnableOffset = false;
                    notify.Alert(GetName() + " не был оптимизирован", NotificationManager.NotificationType.Error);
                    notify.StopTimer(1000);
                }
            };
            /* Кнопка возврата */
            Bunifu.UI.WinForms.BunifuButton.BunifuButton backbutton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            backbutton.Text = "Назад";
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
                        "ofFogType:3",
                        "ofFogStart:0.8",
                        "ofMipmapType:0",
                        "ofOcclusionFancy:false",
                        "ofSmoothFps:true",
                        "ofSmoothWorld:true",
                        "ofAoLevel:1.0",
                        "ofClouds:3",
                        "ofCloudsHeight:0.0",
                        "ofTrees:0",
                        "ofDroppedItems:1",
                        "ofRain:3",
                        "ofAnimatedWater:0",
                        "ofAnimatedLava:0",
                        "ofAnimatedFire:true",
                        "ofAnimatedPortal:true",
                        "ofAnimatedRedstone:true",
                        "ofAnimatedExplosion:true",
                        "ofAnimatedFlame:true",
                        "ofAnimatedSmoke:true",
                        "ofVoidParticles:true",
                        "ofWaterParticles:true",
                        "ofPortalParticles:true",
                        "ofPotionParticles:true",
                        "ofFireworkParticles:true",
                        "ofDrippingWaterLava:true",
                        "ofAnimatedTerrain:true",
                        "ofAnimatedTextures:true",
                        "ofRainSplash:true",
                        "ofLagometer:false",
                        "ofShowFps:false",
                        "ofAutoSaveTicks:4000",
                        "ofBetterGrass:3",
                        "ofConnectedTextures:1",
                        "ofWeather:true",
                        "ofSky:true",
                        "ofStars:true",
                        "ofSunMoon:true",
                        "ofVignette:1",
                        "ofChunkUpdates:1",
                        "ofChunkUpdatesDynamic:true",
                        "ofTime:0",
                        "ofClearWater:false",
                        "ofAaLevel:0",
                        "ofAfLevel:1",
                        "ofProfiler:false",
                        "ofBetterSnow:false",
                        "ofSwampColors:false",
                        "ofRandomEntities:true",
                        "ofSmoothBiomes:true",
                        "ofCustomFonts:true",
                        "ofCustomColors:true",
                        "ofCustomItems:true",
                        "ofCustomSky:true",
                        "ofShowCapes:true",
                        "ofNaturalTextures:true",
                        "ofEmissiveTextures:true",
                        "ofLazyChunkLoading:true",
                        "ofRenderRegions:true",
                        "ofSmartAnimations:true",
                        "ofDynamicFov:false",
                        "ofAlternateBlocks:true",
                        "ofDynamicLights:1",
                        "ofScreenshotSize:1",
                        "ofCustomEntityModels:true",
                        "ofCustomGuis:true",
                        "ofShowGlErrors:false",
                        "ofFullscreenMode:Default",
                        "ofFastMath:true",
                        "ofFastRender:true",
                        "ofTranslucentBlocks:1",
                        "key_of.key.zoom:46",
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
                    char splitchat = ':';
                    foreach (string readline in textinfile)
                    {
                        string[] split = readline.Split(splitchat);
                        foreach (string writeline in writelines)
                        {
                            string[] split2 = writeline.Split(splitchat);
                            if (split[0] == split2[0] && split[1] != split2[1])
                            {
                                writer.Add(writeline);
                            }
                            else if (split[0] == split2[0] && split[1] == split2[1])
                            {
                                writer.Add(readline);
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
