using System;
using System.IO;
using Module2HW5.Models;
using Module2HW5.Services.Abstractions;
using Newtonsoft.Json;

namespace Module2HW5.Services
{
    public class ConfigService : IConfigService
    {
        public Config ReadConfig()
        {
            try
            {
                var configFile = File.ReadAllText("config.json");
                return JsonConvert.DeserializeObject<Config>(configFile);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
