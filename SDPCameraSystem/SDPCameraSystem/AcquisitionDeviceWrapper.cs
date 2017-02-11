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

        public AcquisitionDeviceWrapper(ConfigurationFile ConfigurationFile, LocationWrapper LocationWrapper)
        {
            CreateNewAcquisitionDevice(LocationWrapper, ConfigurationFile);
            CheckForSuccessfulAcquisitionDeviceCreation();
            CreateAcquisitionDeviceNotificationInterface();
        }

        public void CreateNewAcquisitionDevice(LocationWrapper LocationWrapper, ConfigurationFile ConfigurationFile)
        {
            Device = new SapAcqDevice(LocationWrapper.Location, ConfigurationFile.ConfigFileName);
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

        public void CreateAcquisitionDeviceCallback(object DataSender, SapAcqDeviceNotifyEventArgs EventArguments)
        {
            Device = DataSender as SapAcqDevice;
        }

        public void CreateAcquisitionDeviceNotificationInterface()
        {
            Device.AcqDeviceNotify += new SapAcqDeviceNotifyHandler(CreateAcquisitionDeviceCallback);
        }
    }
}
