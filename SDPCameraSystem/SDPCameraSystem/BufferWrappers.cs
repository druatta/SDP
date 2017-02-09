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
        public SapBuffer Buffer;
        private int BufferCount = 2;
        private string SaveDirectory = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\TestImages";
        private string SaveFileName = "TestSave";

        public BufferWrappers(AcquisitionDeviceWrapper DeviceWrapper)
        {
            CreateNewBuffers(DeviceWrapper);
        }

        public void CreateNewBuffers(AcquisitionDeviceWrapper DeviceWrapper)
        {
            Buffer = new SapBufferWithTrash(BufferCount, DeviceWrapper.Device, SapBuffer.MemoryType.ScatterGather);
        }

        public void SaveBufferToFile()
        {
            Buffer.Save(SaveDirectory, SaveFileName);
        }
    }
}
