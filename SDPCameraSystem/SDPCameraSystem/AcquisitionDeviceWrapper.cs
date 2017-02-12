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
        public bool FrameTriggerEvent;

        public AcquisitionDeviceWrapper(ConfigurationFile ConfigurationFile, LocationWrapper LocationWrapper, FeatureWrapper FeatureWrapper)
        {
            CreateNewAcquisitionDevice(LocationWrapper, ConfigurationFile);
            CheckForSuccessfulAcquisitionDeviceCreation();
            CreateAcquisitionDeviceNotificationInterface();
            //EnableChangesInFeatureValues();
        }

        public void CreateNewAcquisitionDevice(LocationWrapper LocationWrapper, ConfigurationFile ConfigurationFile)
        {
            Device = new SapAcqDevice(LocationWrapper.Location, ConfigurationFile.ConfigFileName);
        }

        public void CheckForSuccessfulAcquisitionDeviceCreation()
        {
            Device.Create();
        }

        public void CreateAcquisitionDeviceCallback(object DataSender, SapAcqDeviceNotifyEventArgs EventArguments)
        {
            Device = DataSender as SapAcqDevice;
        }

        public void CreateAcquisitionDeviceNotificationInterface()
        {
            Device.AcqDeviceNotify += new SapAcqDeviceNotifyHandler(CreateAcquisitionDeviceCallback);
        }

        public void EnableChangesInFeatureValues()
        {
            if (CheckIfChangesInFeatureValuesAreEnabled() == false)
            {
                Device.EnableEvent("Feature Value Changed");
            }
        }

        public Boolean CheckIfChangesInFeatureValuesAreEnabled()
        {
            if (Device.IsEventEnabled("Feature Value Changed")) {
                return true;
            }
            else // Changes in Feature Values are not enabled
            {
                return false;
            }
        }

        public void WaitForTriggerInput(FeatureWrapper FeatureWrapper)
        {
            while (true)
            {
                if (Device.IsFeatureAvailable("EventLine1Event"))
                {
                    Console.WriteLine("EventFrameTrigger is available!");
                    Device.GetFeatureInfo("EventLine1Event", FeatureWrapper.Feature);
                    Device.GetFeatureValue("EventLine1Event", out FrameTriggerEvent);
                    Console.WriteLine("Line 1 Event is: " + Convert.ToString(FrameTriggerEvent));
                }

            }

        }
    }
}
