using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class TriggerInput : VideoFeed
    {

        public void EnableSoftwareTrigger()
        {

        }

        public void SendSoftwareTriggerFromVisualStudio()
        {
            // Use SetFeatureValue!!!
            // public bool SetFeatureValue(int featureIndex, bool featureValue);
            Camera.Device.SetFeatureValue("EventFrameTrigger", true);
        }

        public void SendSoftwareTriggerFromPEG()
        {

        }

        public void CheckForTriggerEvent()
        {
            if (Camera.Device.IsEventEnabled("EventFrameTrigger"))
            {

            }
        }

        public void FreezeFrameOnTriggerEvent()
        {

        }
    }
}
