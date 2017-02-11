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

        //public FeatureWrapper FeatureWrapper;
        
        public CameraFeed()
        {
            CreateCameraFeed(); 
        }

        public void CreateCameraFeed()
        {
            CreateCameraObject();
            CreateCameraImageBuffers();
            CreateCameraViewingWindow();
            CreateCameraDataTransfer();
            //CreateCameraFeatureHandler();
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

        //public void CreateCameraFeatureHandler()
        //{
        //    FeatureWrapper = new FeatureWrapper();
        //}




    }

}
