using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    interface TriggerCameraInterface
    {
        void TurnTriggerModeOn();
    }

    class PEGCameraInterface : VideoFeed
    {

        public void TurnTriggerModeOn()
        {
            //VideoFeed.Camera.Device.SetFeatureValue("TriggerMode", true);
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
