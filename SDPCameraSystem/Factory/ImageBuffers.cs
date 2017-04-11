using DALSA.SaperaLT.SapClassBasic;
using System;
using System.IO;

namespace SDPCameraSystem
{
    public class ImageBuffers
    {
        private static string SaveDirectory = Environment.GetEnvironmentVariable("SAPERADIR") + "\\Images";
        private static string[] SaveFileStringArray = Directory.GetFiles(SaveDirectory, "*.bmp");
        private const int FirstSaveFile = 0;
        private static string SaveFileName = SaveFileStringArray[FirstSaveFile];
        private static string SaveFileType = "-format bmp";

        public ImageBuffers()
        {
            CreateNewBuffers();
            CheckForSuccessfulBufferCreation();
        }

        private const int BufferCount = 2;
        public static SapBuffer Buffers;
        public static void CreateNewBuffers()
        {
            Buffers = new SapBufferWithTrash(BufferCount, Node.Device, SapBuffer.MemoryType.ScatterGather);
        }

        public static void CheckForSuccessfulBufferCreation()
        {
            Buffers.Create();
        }

        static int i = 0;
        public static void SaveBufferToFile()
        {
            string Date = DateTime.Today.ToShortDateString();
            string Time = DateTime.Now.ToString("h:mm:ss tt");

            string ModifiedString = SaveFileName.Insert(SaveFileName.Length - 4, i + "");

            Console.WriteLine(ModifiedString);

            Buffers.Save(ModifiedString, SaveFileType);
            i++;

        }




    }
}
