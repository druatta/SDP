using System;
using DALSA.SaperaLT.SapClassBasic;
using System.IO;

namespace SDPCameraSystem
{
    public class ConfigurationFile
    {
        public int ResourceIndex = 0;

        public ConfigurationFile()
        {
            AssignConfigurationFileServerName();
            AssignConfigurationFilePath();
            FindACameraConfigurationFile();
            AssignCCFParametersToConfigurationFile();
        }

        public string ServerName;
        private int SDPServerNumber = 1;
        public void AssignConfigurationFileServerName()
        {
            ServerName = SapManager.GetServerName(SDPServerNumber);
        }

        private string ConfigFilePath;
        public void AssignConfigurationFilePath()
        {
            ConfigFilePath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
        }

        public void FindACameraConfigurationFile()
        {
            ConfigFileStringArray = Directory.GetFiles(ConfigFilePath, "*.ccf");
        }

        public string ConfigFileName;
        private string[] ConfigFileStringArray;
        private int FirstConfigFile = 0;
        public void AssignCCFParametersToConfigurationFile()
        {
            ConfigFileName = ConfigFileStringArray[FirstConfigFile];
        }

    }

}

