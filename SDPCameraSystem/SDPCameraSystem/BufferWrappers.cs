using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class BufferWrappers
    {
        public SapBuffer Buffers;
        private int BufferCount = 2;
        private string SaveDirectory = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\TestImages";
        private string SaveFileName = "TestSave";

        public BufferWrappers(AcquisitionDeviceWrapper DeviceWrapper)
        {
            CreateNewBuffers(DeviceWrapper);
            CheckForSuccessfulBufferCreation();
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
            Buffers.Save(SaveDirectory, SaveFileName);
        }
    }
}
