using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;


namespace SDPCameraSystem
{
    class Camera
    {
        public SapAcqDevice Device;
        public AcquisitionParameters AcquisitionParameters;
        public SapLocation Location;
        protected int BufferCount = 2;
        public SapBuffer Buffer;
        public SapTransfer Transfer;
        public SapView View;

        public Camera()
        {
            AcquisitionParameters = new AcquisitionParameters();
            Location = new SapLocation(AcquisitionParameters.ServerName, AcquisitionParameters.ResourceIndex);
            Device = new SapAcqDevice(Location, AcquisitionParameters.ConfigFileName);
            Buffer = new SapBufferWithTrash(BufferCount, Device, SapBuffer.MemoryType.ScatterGather);
            Transfer = new SapAcqDeviceToBuf(Device, Buffer);
            View = null;
        }





    }

}
