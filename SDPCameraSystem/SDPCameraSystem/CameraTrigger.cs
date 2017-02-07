using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class CameraTrigger
    {

        public void TurnTriggerModeOn(CameraInterface Cam)
        {
            Cam.Device.SetFeatureValue("TriggerMode", true);
        }



        public void CheckForTriggerEvent()
        {
            //if (Device.IsEventEnabled("EventFrameTrigger"))
            //{

            //}
        }

        public void FreezeFrameOnTriggerEvent()
        {

        }
    }
}
