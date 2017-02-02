using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.Examples.NET.Utils;


namespace SDPCameraSystem
{
    class CameraObject
    {
        private MyAcquisitionParams Params = null;
        public SapLocation Location = null;
        public SapAcqDevice Device = null;
        public int DefaultBuffer = 2;
        public SapBuffer Buffers = null;
        public SapAcquisition Acquisition = null;
        SapTransfer Transfer = null;

        public CameraObject()
        {
            Location = new SapLocation(Params.ServerName, Params.ResourceIndex);
            Params = new MyAcquisitionParams();
            Device = new SapAcqDevice(Location, Params.ConfigFileName);
            Buffers = new SapBufferWithTrash(DefaultBuffer, Device, SapBuffer.MemoryType.ScatterGather);
            Acquisition = new SapAcquisition(Location, Params.ConfigFileName);
            Transfer = new SapAcqToBuf(Acquisition, Buffers);
        }



    }

}
