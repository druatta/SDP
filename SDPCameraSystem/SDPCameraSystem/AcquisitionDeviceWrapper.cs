using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class AcquisitionDeviceWrapper
    {
        public SapAcqDevice Device;
        ConfigurationParameters DeviceParameters = new ConfigurationParameters();
        LocationWrapper LocationWrapper = new LocationWrapper();
        private string EventFeatureString = "GigEVisionEvent";
        private bool FeatureValue = true;
        

        public AcquisitionDeviceWrapper()
        {
            CreateNewAcquisitionDevice();
            CheckForSuccessfulAcquisitionDeviceCreation();
        }

        public void CreateNewAcquisitionDevice()
        {
            Device = new SapAcqDevice(LocationWrapper.Location, DeviceParameters.ConfigFileName);
        }

        public void CheckForSuccessfulAcquisitionDeviceCreation()
        {
            Device.Create();
        }

        public Boolean CheckForTriggerSignal(CameraFeed CameraFeed)
        {
            if (CameraFeed.AcquisitionDeviceWrapper.Device.GetFeatureValue("FrameTrigger", out FeatureValue))
            {
                return true;
            } else
            {
                return false;
            }
            
        }
    }
}
