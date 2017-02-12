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
        public Boolean FrameTriggerStatus;
        public static Boolean PreviousTriggerStatus;
        public String FeatureValueChangeString = "Feature Value Changed";
        public String FrameTriggerString = "LineStatus";

        public AcquisitionDeviceWrapper(ConfigurationFile ConfigurationFile, LocationWrapper LocationWrapper, FeatureWrapper FeatureWrapper)
        {
            CreateNewAcquisitionDevice(LocationWrapper, ConfigurationFile);
            CheckForSuccessfulAcquisitionDeviceCreation();
            CreateAcquisitionDeviceNotificationInterface();
            EnableChangesInFeatureValues();
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
                Device.EnableEvent(FeatureValueChangeString);
            }
        }

        public Boolean CheckIfChangesInFeatureValuesAreEnabled()
        {
            if (Device.IsEventEnabled(FeatureValueChangeString))
            {
                return true;
            }
            else // Changes in Feature Values are not enabled
            {
                return false;
            }
        }

        public void WaitForTriggerInput(FeatureWrapper FeatureWrapper)
        {
            while (Device.IsFeatureAvailable(FrameTriggerString))
            {
                CheckForChangeInTriggerInput(FeatureWrapper);
            }
        }

        public void GetTriggerParameters(FeatureWrapper FeatureWrapper)
        {
            Device.GetFeatureInfo(FrameTriggerString, FeatureWrapper.Feature);
            Device.GetFeatureValue(FrameTriggerString, out FrameTriggerStatus);
        }

        public Boolean CheckForChangeInTriggerInput(FeatureWrapper FeatureWrapper)
        {
            GetTriggerParameters(FeatureWrapper);
            if (PreviousTriggerStatus != FrameTriggerStatus)
            {
                UpdateTriggerStatus();
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public void UpdateTriggerStatus()
        {
            PreviousTriggerStatus = FrameTriggerStatus;
        }
    }
}
