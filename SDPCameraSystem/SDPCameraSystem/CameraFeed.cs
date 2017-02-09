using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;


namespace SDPCameraSystem
{
    class CameraFeed
    {
        public AcquisitionDeviceWrapper AcquisitionDeviceWrapper;
        public BufferWrappers BufferWrappers;
        public ViewWrapper ViewWrapper;
        public DataTransferWrapper DataTransferWrapper;

        //public SapFeature Feature;
        //public SapAcqDeviceNotifyHandler Handler;
        
        public CameraFeed()
        {
            //CreateCameraFeed(); // Test all four CameraFeed.Create() functions separately, then uncomment
                                    // This to make creating a CameraFeed a single call
        }

        public void CreateCameraFeed()
        {
            CreateCameraObject();
            CreateCameraImageBuffers();
            CreateCameraViewingWindow();
            CreateCameraDataTransfer();
        }

        public void CreateCameraObject()
        {
            AcquisitionDeviceWrapper = new AcquisitionDeviceWrapper();
        }

        public void CreateCameraImageBuffers()
        {
            BufferWrappers = new BufferWrappers(AcquisitionDeviceWrapper);
        }

        public void CreateCameraViewingWindow()
        {
            ViewWrapper = new ViewWrapper(BufferWrappers);
        }

        public void CreateCameraDataTransfer()
        {
            DataTransferWrapper = new DataTransferWrapper(AcquisitionDeviceWrapper, BufferWrappers, ViewWrapper);
        }




    }

}
