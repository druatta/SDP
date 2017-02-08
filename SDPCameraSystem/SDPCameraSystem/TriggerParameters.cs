using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class TriggerParameters
    {

        public TriggerParameters(AcquisitionDeviceWrapper Device)
        {
            SetTheTriggerSelectorToFrameTrigger(Device);
        }

        public void SetTheTriggerSelectorToFrameTrigger(AcquisitionDeviceWrapper Device)
        {
            //Device.SetFeatureValue("TriggerSelector", "FrameTrigger");
        }

        public void TurnTriggerModeOn(VideoFeed VideoFeed)
        {
            VideoFeed.Device.SetFeatureValue("TriggerMode", "On");
        }

    }
}
