using System;
using DALSA.SaperaLT.SapClassBasic;
using System.IO;

namespace SDPCameraSystem
{
    public sealed class ConfigurationFile
    {
        public static readonly Lazy<ConfigurationFile> LazyConfigurationFile = new Lazy<ConfigurationFile>(() => new ConfigurationFile());


        public static ConfigurationFile Instance
        {
            get
            {
                return LazyConfigurationFile.Value;
            }
        }

        private ConfigurationFile()
        {
            AssignServerName();
            Assign_CCF_File();
        }


        public const int ResourceIndex = 0;
        public static string ServerName;
        public static void AssignServerName()
        {
            int SDPServerNumber = 1;
            ServerName = SapManager.GetServerName(SDPServerNumber);
        }

        public static string Name;
        public static void Assign_CCF_File()
        {
            Find_CCF_File();
            int FirstFile = 0;
            Name = CCF_FileArray[FirstFile];
        }

        public static string FilePath;
        public static string[] CCF_FileArray;
        public static void Find_CCF_File()
        {
            string CCF_FileType = "*.ccf";
            Assign_CCF_FilePath();
            CCF_FileArray = Directory.GetFiles(FilePath, CCF_FileType);
        }

        public static void Assign_CCF_FilePath()
        {
            FilePath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
        }




    }

}

