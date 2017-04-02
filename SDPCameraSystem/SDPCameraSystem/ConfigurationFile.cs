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
            //AssignConfigurationFilePath();
            FindACameraConfigurationFile();
            AssignCCFParametersToConfigurationFile();
        }

        public static string ServerName;
        public static void AssignConfigurationFileServerName()
        {
            int SDPCameraServerNumber = 1;
            ServerName = SapManager.GetServerName(SDPCameraServerNumber);
        }

        static string ConfigurationFilePath;
        public static void AssignConfigurationFilePath()
        {
            ConfigurationFilePath = FindConfigurationFilePath();
        }

        public static string FindConfigurationFilePath()
        {
            string ConfigurationFilePath;
            ConfigurationFilePath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User";
            return ConfigurationFilePath;
        }

        static string[] ConfigFileStringArray;
        public static void FindACameraConfigurationFile()
        {
            string CameraConfigurationFileType = "*.ccf";
            AssignConfigurationFilePath();
            ConfigFileStringArray = Directory.GetFiles(ConfigurationFilePath, CameraConfigurationFileType);
        }





        public string ConfigFileName;
        int FirstConfigFile = 0;
        public void AssignCCFParametersToConfigurationFile()
        {
            ConfigFileName = ConfigFileStringArray[FirstConfigFile];
        }


    }

}

