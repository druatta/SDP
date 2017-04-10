using DALSA.SaperaLT.SapClassBasic;
using System;

namespace SDPCameraSystem
{
    public class Node
    {
        public SapAcqDevice Device;
        public Boolean FrameTriggerStatus;
        public static Boolean PreviousTriggerStatus;
        public String FeatureValueChangeString = "Feature Value Changed";
        public String FrameTriggerString = "LineStatus";

        public Node(Server ConfigurationFile)
        {
            CreateNewAcquisitionDevice(ConfigurationFile);
            CheckForSuccessfulAcquisitionDeviceCreation();
            CreateCameraObjectNotificationInterface();
            EnableChangesInFeatureValues();
        }

        public void CreateNewAcquisitionDevice(Server ConfigurationFile)
        {
            Device = new SapAcqDevice(Server.Location, Server.Name);
        }

        public void CheckForSuccessfulAcquisitionDeviceCreation()
        {
            Device.Create();
        }

        public void CreateAcquisitionDeviceCallback(object DataSender, SapAcqDeviceNotifyEventArgs EventArguments)
        {
            Device = DataSender as SapAcqDevice;
        }

        public void CreateCameraObjectNotificationInterface()
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

        public void WaitForTriggerInput()
        {
            while (Device.IsFeatureAvailable(FrameTriggerString))
            {
                CheckForChangeInTriggerInput();
            }
        }

        public void GetTriggerParameters()
        {
            Device.GetFeatureInfo(FrameTriggerString, Node.Feature);
            Device.GetFeatureValue(FrameTriggerString, out FrameTriggerStatus);
        }

        public bool CheckForChangeInTriggerInput()
        {
            GetTriggerParameters();
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

        public static SapFeature Feature;
        public void CreateEventHandler()
        {
            Feature = new SapFeature(Server.Location);
        }

        public void CheckForSuccessfulEventHandlerCreation()
        {
            Feature.Create();
        }

        public void UpdateTriggerStatus()
        {
            PreviousTriggerStatus = FrameTriggerStatus;
        }
    }
}
