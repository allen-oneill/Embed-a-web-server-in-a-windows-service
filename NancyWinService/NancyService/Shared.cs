using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace NancyService
{

    public class ConfigInfo
    {
        public String TempFolder { get; set; }
        public String Username { get; set; }
        public String DateFormat { get; set; }
    }

    public class ConfigManager
    {
        public ConfigInfo config;
        string _XMLFile = AppDomain.CurrentDomain.BaseDirectory + "PracticeConfig.xml";

        public void LoadConfig()
        {
            if (config == null)
            {
                config = new ConfigInfo();
            }

            if (!File.Exists(_XMLFile))
            {
                config.DateFormat = "dd/mmm/yyyy";
                SaveConfig();
            }

            XmlSerializer deserializer = new XmlSerializer(typeof(ConfigInfo));
            TextReader reader = new StreamReader(_XMLFile);
            object obj = deserializer.Deserialize(reader);
            config = (ConfigInfo)obj;
            reader.Close();
        }

        public void SaveConfig()
        {
            if (config != null)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ConfigInfo));
                using (TextWriter writer = new StreamWriter(_XMLFile))
                {
                    serializer.Serialize(writer, config);
                }
            }
        }

    }

}
