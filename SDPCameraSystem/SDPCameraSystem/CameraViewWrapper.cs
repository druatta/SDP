using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class CameraViewWrapper
    {
        public SapView View;

        public CameraViewWrapper(BufferWrappers BufferWrappers)
        {
            View = new SapView(BufferWrappers.Buffer);
        }
    }
}
