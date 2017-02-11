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
        private bool FeatureValue = true;
        public Object DataSender;

        public AcquisitionDeviceWrapper()
        {
            CreateNewAcquisitionDevice();
            CheckForSuccessfulAcquisitionDeviceCreation();
            CreateAcquisitionDeviceNotificationInterface();
        }

        public void CreateNewAcquisitionDevice()
        {
            Device = new SapAcqDevice(LocationWrapper.Location, DeviceParameters.ConfigFileName);
        }

        public void CheckForSuccessfulAcquisitionDeviceCreation()
        {
            Device.Create();
        }

        public void WaitForTriggerInput()
        {
            while (!Device.IsFeatureAvailable("FrameTrigger"))
            {
                Console.WriteLine("Trigger not available!");
            }
        }

        public void CreateAcquisitionDeviceCallback(object Sender, SapAcqDeviceNotifyEventArgs EventArguments)
        {
            Device = DataSender as SapAcqDevice;
        }

        public void CreateAcquisitionDeviceNotificationInterface()
        {
            Device.AcqDeviceNotify += new SapAcqDeviceNotifyHandler(CreateAcquisitionDeviceCallback);
        }
    }
}
