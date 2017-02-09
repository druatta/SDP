using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class ViewWrapper
    {
        public SapView View;

        public ViewWrapper(BufferWrappers BufferWrappers)
        {
            CreateNewView(BufferWrappers);
            CheckForSuccessfulViewCreation();
        }

        public void CreateNewView(BufferWrappers BufferWrappers)
        {
            View = new SapView(BufferWrappers.Buffer);
        }

        public void CheckForSuccessfulViewCreation()
        {
            View.Create();
        }
    }
}
