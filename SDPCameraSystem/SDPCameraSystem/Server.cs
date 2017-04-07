using DALSA.SaperaLT.SapClassBasic;
using System;
using System.IO;

namespace SDPCameraSystem
{
    public class Server
    {
        public Server()
        {
            AssignServerNameAndResourceIndexToSapLocation();
        }

        public static SapLocation Location;
        public static void AssignServerNameAndResourceIndexToSapLocation()
        {
            Location = new SapLocation(ServerName, ResourceIndex);
        }


        public const int ResourceIndex = 0;
        public static string ServerName;
        public static void GetUCSCComputerServerName()
        {
            int UCSCComputerServerNumber = 1;
            ServerName = SapManager.GetServerName(UCSCComputerServerNumber);
        }

        public static string Name;
        public static void Assign_CCF_File()
        {
            Find_CCF_FileDirectory();
            int FirstFile = 0;
            Name = CCF_FileArray[FirstFile];
        }

        public static string FilePath;
        public static string[] CCF_FileArray;
        public static void Find_CCF_FileDirectory()
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
