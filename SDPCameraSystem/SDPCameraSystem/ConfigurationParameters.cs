using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using System.IO;

namespace SDPCameraSystem
{
    class ConfigurationParameters
    {
        public string ServerName;
        public int ResourceIndex = 0;
        public string ConfigFileName;

        protected string ConfigFilePath;
        protected string[] ConfigFileStringArray;
        protected int SDPServerNumber = 1;
        protected int FirstConfigFile = 0;

        public ConfigurationParameters()
        {
            ServerName = SapManager.GetServerName(SDPServerNumber);
            ConfigFilePath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
            ConfigFileStringArray = Directory.GetFiles(ConfigFilePath, "*.ccf");
            ConfigFileName = ConfigFileStringArray[FirstConfigFile]; 
        }


    }
}

