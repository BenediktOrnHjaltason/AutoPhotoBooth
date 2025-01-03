﻿using System.IO;
using Newtonsoft.Json;
using AutoPhotoBooth.CustomTypes;

namespace AutoPhotoBooth.Configuration
{
    public class ConfigurationHandler
    {

        public static readonly string PositiveResultSavePath = "C:/ProgramData/Spirit Lab/Photo Booth/Captures";
        public static readonly string TempImagePath = "C:/ProgramData/Spirit Lab/Photo Booth/Temp";
        public static readonly string ConfigPath = "C:/ProgramData/Spirit Lab/config.json";

        public static Config LoadConfig()
        {
            if (!Directory.Exists(Path.GetDirectoryName(ConfigPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));

            if (!Directory.Exists(PositiveResultSavePath))
                Directory.CreateDirectory(PositiveResultSavePath);

            if (!Directory.Exists(TempImagePath))
                Directory.CreateDirectory(TempImagePath);

            if(File.Exists(ConfigPath))
            {
                string jsonString = File.ReadAllText(ConfigPath);

                return JsonConvert.DeserializeObject<Config>(jsonString);
            }

            return new Config();
        }

        public static void SaveConfig(Config config)
        {
            string jsonString = JsonConvert.SerializeObject(config, Formatting.Indented);

            File.WriteAllText(ConfigPath, jsonString);
        }
    }
}
