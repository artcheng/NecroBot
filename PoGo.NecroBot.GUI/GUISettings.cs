using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PoGo.NecroBot.Logic.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoGo.NecroBot.GUI
{
    public class GUISettings
    {
        public class ProfileSettings
        {
            [JsonIgnore]
            public string _filePath;
            public bool IsLastProfile = false;
            public bool UseLiveMap = false;
            public double LastLat = 0.00;
            public double LastLng = 0.00;

            public static ProfileSettings Default => new ProfileSettings();

            public static ProfileSettings Load(string path)
            {
                ProfileSettings settings;
                var profilePath = Path.Combine(Directory.GetCurrentDirectory(), path);
                var guisettingFile = Path.Combine(profilePath, "guisettings.json");

                if (File.Exists(guisettingFile))
                {
                    try
                    {
                        //if the file exists, load the settings
                        var input = File.ReadAllText(guisettingFile);

                        var jsonSettings = new JsonSerializerSettings();
                        jsonSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
                        jsonSettings.ObjectCreationHandling = ObjectCreationHandling.Replace;
                        jsonSettings.DefaultValueHandling = DefaultValueHandling.Populate;

                        settings = JsonConvert.DeserializeObject<ProfileSettings>(input, jsonSettings);
                    }
                    catch (Newtonsoft.Json.JsonReaderException exception)
                    {
                        Logger.Write("JSON Exception: " + exception.Message, LogLevel.Error);
                        return null;
                    }
                }
                else
                {
                    settings = new ProfileSettings();
                }

                settings._filePath = profilePath;
 
                settings.Save(guisettingFile);

                return settings;
            }

            public void Save(string fullPath)
            {
                var output = JsonConvert.SerializeObject(this, Formatting.Indented,
                    new StringEnumConverter { CamelCaseText = true });

                var folder = Path.GetDirectoryName(fullPath);
                if (folder != null && !Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                File.WriteAllText(fullPath, output);
            }

            public void Save()
            {
                var output = JsonConvert.SerializeObject(this, Formatting.Indented,
                    new StringEnumConverter { CamelCaseText = true });

                var folder = Path.GetDirectoryName(_filePath);
                if (folder != null && !Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                File.WriteAllText(_filePath+"guisettings.json", output);
            }
        }

    }
}
