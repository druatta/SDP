using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class VideoFeed
    {
        public CameraInterface Camera = new CameraInterface();

        public VideoFeed()
        {
            Camera.CreateCameraAcquisitionDevice();
            Camera.RefreshFrameRate();
            Camera.CreateBuffers();
            Camera.CreateTransfer();
            Camera.CreateView();
            Camera.GrabCameraFeed();
        }

        public void PauseVideoFeedForSeconds(int TimeoutinSeconds)
        {
            Camera.Transfer.Wait(TimeoutinSeconds);
        }

        public void FreezeVideoFeed()
        {
            Camera.Transfer.Freeze();
            PauseVideoFeedForSeconds(1000);
        }


        public void SavePicture()
        {
            // How do we save to a file??
        }


    }
}
