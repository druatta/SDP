using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class ViewingWindow
    {
        public SapView View;

        public ViewingWindow(ImageBuffers BufferWrappers)
        {
            CreateNewView(BufferWrappers);
            CheckForSuccessfulViewCreation();
        }

        public void CreateNewView(ImageBuffers BufferWrappers)
        {
            View = new SapView(BufferWrappers.Buffers);
        }

        public void CheckForSuccessfulViewCreation()
        {
            View.Create();
        }
    }
}
