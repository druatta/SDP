using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class TriggerParameters
    {

        public TriggerParameters(VideoFeed VideoFeed)
        {
            VideoFeed.
        }

        public void SetTheTriggerSelectorToFrameTrigger(VideoFeed VideoFeed)
        {
            VideoFeed.Device.SetFeatureValue("TriggerSelector", "FrameTrigger");
        }

        public void TurnTriggerModeOn(VideoFeed VideoFeed)
        {
            VideoFeed.Device.SetFeatureValue("TriggerMode", "On");
        }

    }
}
