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
        public SapFeature Feature;
        public SapAcqDeviceNotifyHandler Handler;

        public Camera()
        {
            AcquisitionParameters = new AcquisitionParameters();
            Location = new SapLocation(AcquisitionParameters.ServerName, AcquisitionParameters.ResourceIndex);
            Device = new SapAcqDevice(Location, AcquisitionParameters.ConfigFileName);
            Buffer = new SapBufferWithTrash(BufferCount, Device, SapBuffer.MemoryType.ScatterGather);
            Transfer = new SapAcqDeviceToBuf(Device, Buffer);
            View = new SapView(Buffer);
            CreateCamera();
        }

        public void CreateCamera()
        {
            CreateCameraAcquisitionDevice();
            RefreshFrameRate();
            CreateBuffers();
            CreateTransfer();
            CreateView();
            GrabCameraFeed();
        }

        public void CreateCameraAcquisitionDevice()
        {
            Device.Create();
        }

        public void xfer_XferNotify(object sender, SapXferNotifyEventArgs args)
        {
            // refresh view
            SapView View = args.Context as SapView;
            View.Show();

            // refresh frame rate
            SapTransfer transfer = sender as SapTransfer;
        }

        public void RefreshFrameRate()
        {
            Transfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
            Transfer.XferNotify += new SapXferNotifyHandler(xfer_XferNotify);
            Transfer.XferNotifyContext = View;
        }

        public void CreateBuffers()
        {
            Buffer.Create();
        }

        public void CreateTransfer()
        {
            Transfer.Create();
        }

        public void CreateView()
        {
            View.Create();
        }

        public void GrabCameraFeed()
        {
            Transfer.Grab();
        }




    }

}
