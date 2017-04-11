using DALSA.SaperaLT.SapClassBasic;
using System;
using System.IO;

namespace SDPCameraSystem
{
    public class Server
    {
        public static SapLocation Location;
        public const int ResourceIndex = 0;
        public Server()
        {
            Assign_CCF_File();
            AssignSDPServerName();
            Location = new SapLocation(ServerName, ResourceIndex);
        }

        public static string ServerName;
        public static void AssignSDPServerName()
        {
            int UCSC_ComputerServerNumber = 1;
            ServerName = SapManager.GetServerName(UCSC_ComputerServerNumber);
        }

        public static string Name;
        public static void Assign_CCF_File()
        {
            FindConfigurationFileDirectory();
            int FirstFile = 0;
            Name = CCF_FileArray[FirstFile];
        }

        public static string FilePath;
        public static string[] CCF_FileArray;
        public static void FindConfigurationFileDirectory()
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
