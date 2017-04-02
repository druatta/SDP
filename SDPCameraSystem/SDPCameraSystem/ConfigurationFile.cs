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
            AssignServerName();
            Assign_CCF_File();
        }

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

