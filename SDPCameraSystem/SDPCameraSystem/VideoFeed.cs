using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class VideoFeed
    {
        Camera CamObject = new Camera();

        public VideoFeed()
        {
            CamObject.CreateCameraAcquisitionDevice();
            CamObject.RefreshFrameRate();
            CamObject.CreateBuffers();
            CamObject.CreateTransfer();
            CamObject.CreateView();
            CamObject.GrabCameraFeed();
        }

        public void FreezeFrame()
        {
            int FreezeTimeInSeconds = 1000;
            CamObject.Transfer.Freeze();
            CamObject.Transfer.Wait(FreezeTimeInSeconds);
        }

        public void SavePicture()
        {
            // How do we save to a file??
        }
    }
}
