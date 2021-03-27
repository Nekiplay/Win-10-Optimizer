using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_10_Optimizer.Forms.Settings
{
    public class UserSettings
    {
        public string VkToken = "";
        public string VkGroupId = "";

        public static UserSettings Load()
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "\\Settings.json"))
                {
                    UserSettings settings = new UserSettings();
                    try
                    {
                        File.Create(Application.StartupPath + "\\Settings.json").Close();
                    } catch { }
                    Save(settings);
                    return settings;
                }
                else
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(Application.StartupPath + "\\Settings.json"))
                        {
                            string textFromFile = sr.ReadToEnd();
                            UserSettings settings = JsonConvert.DeserializeObject<UserSettings>(textFromFile);
                            return settings;
                        }
                    }
                    catch { UserSettings settings = new UserSettings(); Save(settings); return settings; }
                }
            }
            catch { return new UserSettings(); }
        }
        public static void Save(UserSettings settings)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Settings.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, settings);
            }
        }
    }
}
