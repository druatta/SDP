using DALSA.SaperaLT.SapClassBasic;
using System;

namespace SDPCameraSystem
{
    public class CameraObject
    {
        public SapAcqDevice Device;
        public Boolean FrameTriggerStatus;
        public static Boolean PreviousTriggerStatus;
        public String FeatureValueChangeString = "Feature Value Changed";
        public String FrameTriggerString = "LineStatus";

        public CameraObject(ConfigurationFile ConfigurationFile, NetworkLocation LocationWrapper, EventHandler FeatureWrapper)
        {
            CreateNewAcquisitionDevice(LocationWrapper, ConfigurationFile);
            CheckForSuccessfulAcquisitionDeviceCreation();
            CreateAcquisitionDeviceNotificationInterface();
            EnableChangesInFeatureValues();
        }

        public void CreateNewAcquisitionDevice(NetworkLocation LocationWrapper, ConfigurationFile ConfigurationFile)
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
            else 
            {
                return false;
            }
        }

        public void WaitForTriggerInput(EventHandler FeatureWrapper)
        {
            while (Device.IsFeatureAvailable(FrameTriggerString))
            {
                CheckForChangeInTriggerInput(FeatureWrapper);
            }
        }

        public void GetTriggerParameters(EventHandler FeatureWrapper)
        {
            Device.GetFeatureInfo(FrameTriggerString, FeatureWrapper.Feature);
            Device.GetFeatureValue(FrameTriggerString, out FrameTriggerStatus);
        }

        public Boolean CheckForChangeInTriggerInput(EventHandler FeatureWrapper)
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
