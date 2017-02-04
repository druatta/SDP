using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class VideoFeed
    {
        Camera Camera = new Camera();

        public VideoFeed()
        {
            Camera.CreateCameraAcquisitionDevice();
            Camera.RefreshFrameRate();
            Camera.CreateBuffers();
            Camera.CreateTransfer();
            Camera.CreateView();
            Camera.GrabCameraFeed();
        }

        public void PauseVideoTransferForSeconds(int TimeoutinSeconds)
        {
            Camera.Transfer.Wait(TimeoutinSeconds);
        }

        public void FreezeFrame()
        {

            Camera.Transfer.Freeze();
            PauseVideoTransferForSeconds(1000);
        }

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
            if (Camera.Device.IsEventEnabled("EventFrameTrigger")) {

            }
        }

        public void FreezeFrameOnTriggerEvent()
        {


            int FreezeTimeInSeconds = 1000;
            Camera.Transfer.Freeze();
            Camera.Transfer.Wait(FreezeTimeInSeconds);

        }

        public void SavePicture()
        {
            // How do we save to a file??
        }


    }
}
