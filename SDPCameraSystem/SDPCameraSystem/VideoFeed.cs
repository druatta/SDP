﻿using System;
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
            CamObject.Transfer.Freeze();
        }

        public void SavePicture()
        {
            // How do we save to a file??
        }
    }
}