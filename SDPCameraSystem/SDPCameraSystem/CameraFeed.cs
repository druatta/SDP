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
        public ConfigurationFile ConfigurationFile;
        public LocationWrapper LocationWrapper;
        public FeatureWrapper FeatureWrapper;
        public AcquisitionDeviceWrapper AcquisitionDeviceWrapper;
        public BufferWrappers BufferWrappers;
        public ViewWrapper ViewWrapper;
        public DataTransferWrapper DataTransferWrapper;
        
        public CameraFeed()
        {
            CreateCameraFeed(); 
        }

        public void CreateCameraFeed()
        {
            CreateCameraConfigurationFile();
            CreateCameraNetworkLocation();
            CreateCameraEventHandler();
            CreateCameraObject();
            CreateCameraImageBuffers();
            CreateCameraViewingWindow();
            CreateCameraDataTransfer();
        }

        public void CreateCameraConfigurationFile()
        {
            ConfigurationFile = new ConfigurationFile();
        }

        public void CreateCameraNetworkLocation()
        {
            LocationWrapper = new LocationWrapper(ConfigurationFile);
        }

        public void CreateCameraEventHandler()
        {
            FeatureWrapper = new FeatureWrapper(LocationWrapper);
        }

        public void CreateCameraObject()
        {
            AcquisitionDeviceWrapper = new AcquisitionDeviceWrapper(ConfigurationFile, LocationWrapper, FeatureWrapper);
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

        public void SaveImageOnTriggerInputForever()
        {
            while (true)
            {
                SaveImageOnTriggerInput();
                Console.WriteLine("Image saved!");
            }
        }

        public void SaveImageOnTriggerInput()
        {
            if (AcquisitionDeviceWrapper.CheckForChangeInTriggerInput(FeatureWrapper) == true) {
                BufferWrappers.SaveBufferToFile();
            }
        }

    }

}
