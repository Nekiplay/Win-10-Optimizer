using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_10_Optimizer.Forms.Settings
{
    public class UserSettings
    {
        public bool AutoCleaner = true;
        public long AutoCleanerInterval = 1000 * 60 * 30;

        public static UserSettings Load()
        {
            try
            {

                if (!File.Exists("Settings.json"))
                {
                    UserSettings settings = new UserSettings();
                    //File.Create("Settings.json").Close();
                    Save(settings);
                    return settings;
                }
                else
                {
                    using (FileStream fstream = File.OpenRead("Settings.json"))
                    {
                        byte[] array = new byte[fstream.Length];
                        // асинхронное чтение файла
                        fstream.ReadAsync(array, 0, array.Length);

                        string textFromFile = System.Text.Encoding.UTF8.GetString(array);
                        string output = JsonConvert.SerializeObject(textFromFile);
                        UserSettings settings = JsonConvert.DeserializeObject<UserSettings>(output);
                        return settings;
                    }
                }
            }
            catch { return new UserSettings(); }
        }
        public static void Save(UserSettings settings)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter("Settings.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, settings);
            }
        }
    }
}
