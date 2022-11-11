using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Spirit_Studio.CustomTypes;

namespace Spirit_Studio
{
    public class ConfigurationHandler
    {
        public static Config LoadConfig(string filePath)
        {
            if(File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);

                return JsonConvert.DeserializeObject<Config>(jsonString);
            }
                

            return null;
        }

        public static void SaveConfig(Config config, string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(config);

            File.WriteAllText(filePath, jsonString);
        }
    }
}
