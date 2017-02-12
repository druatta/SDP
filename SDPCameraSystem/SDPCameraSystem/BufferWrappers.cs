﻿using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class BufferWrappers
    {
        public SapBuffer Buffers;
        private int BufferCount = 2;
        private string SaveDirectory;
        private string[] SaveFileStringArray;
        private string SaveFileName;
        private int FirstSaveFile = 0;
        private string SaveFileType;

        public BufferWrappers(AcquisitionDeviceWrapper DeviceWrapper)
        {
            CreateBufferSaveParameters();
            CreateNewBuffers(DeviceWrapper);
            CheckForSuccessfulBufferCreation();
        }

        public void CreateBufferSaveParameters()
        {
            SaveDirectory = Environment.GetEnvironmentVariable("SAPERADIR") + "\\Images";
            SaveFileStringArray = Directory.GetFiles(SaveDirectory, "*.bmp");
            SaveFileName = SaveFileStringArray[FirstSaveFile];
            SaveFileType = "-format bmp";
        }

        public void PrintBufferSaveParameters()
        {
            Console.WriteLine("Buffer Save Directory is: {0}", SaveDirectory);
            Console.WriteLine("Buffer Save Files are: {0}", SaveFileStringArray);
            Console.WriteLine("Buffer Save File Type is: {0}", SaveFileType);
            Console.WriteLine("Buffer Save File Name is: {0}", SaveFileName);
        }

        public void CreateNewBuffers(AcquisitionDeviceWrapper DeviceWrapper)
        {
            Buffers = new SapBufferWithTrash(BufferCount, DeviceWrapper.Device, SapBuffer.MemoryType.ScatterGather);
        }

        public void CheckForSuccessfulBufferCreation()
        {
            Buffers.Create();
        }

        public void SaveBufferToFile()
        {
            Buffers.Save(SaveFileName, SaveFileType);
        }



        
    }
}
