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
        protected MyAcquisitionParams Params = null;
        protected SapLocation Location = null;
        SapAcqDevice Device = null;
        int DefaultBuffer = 2;
        SapBuffer Buffers = null;
        SapAcquisition Acquisition = null;
        SapTransfer Transfer = null;

        public Boolean Create()
        {
            try
            {
                Location = new SapLocation(Params.ServerName, Params.ResourceIndex);
                Params = new MyAcquisitionParams();
                Device = new SapAcqDevice(Location, Params.ConfigFileName);
                Buffers = new SapBufferWithTrash(DefaultBuffer, Device, SapBuffer.MemoryType.ScatterGather);
                Acquisition = new SapAcquisition(Location, Params.ConfigFileName);
                Transfer = new SapAcqToBuf(Acquisition, Buffers);
                
            }
            catch (SapException CreateException)
            {
                throw new Exception("CreateCamera failed!", CreateException);
            }
            finally
            {
                Console.WriteLine("Camera Created!");
            }
            return true;
        }

        public void FindSaperaServer()
        {

        }

    }

}
