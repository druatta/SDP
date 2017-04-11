using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class Trigger
    {
        
        public string FeatureValueChangeString = "Feature Value Changed";
        public string FrameTriggerString = "LineStatus";
        public void EnableChangesInFeatureValues()
        {
            if (CheckIfChangesInFeatureValuesAreEnabled() == false)
            {
                Node.Device.EnableEvent(FeatureValueChangeString);
            }
        }

        public Boolean CheckIfChangesInFeatureValuesAreEnabled()
        {
            if (Node.Device.IsEventEnabled(FeatureValueChangeString))
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
            while (Node.Device.IsFeatureAvailable(FrameTriggerString))
            {
                CheckForChangeInTriggerInput();
            }
        }

        public bool FrameTriggerStatus;
        public static bool PreviousTriggerStatus;
        public void GetTriggerParameters()
        {
            Node.Device.GetFeatureInfo(FrameTriggerString, Node.Feature);
            Node.Device.GetFeatureValue(FrameTriggerString, out FrameTriggerStatus);
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

        public void UpdateTriggerStatus()
        {
            PreviousTriggerStatus = FrameTriggerStatus;
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
            if (CheckForChangeInTriggerInput() == true)
            {
                ImageBuffers.SaveBufferToFile();
            }
        }


    }
}
