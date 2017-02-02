using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;


namespace SDPCameraSystem
{
    class Camera
    {
        public Camera()
        {
            SapAcqDevice Device = null;
            SapBuffer Buffers = null;
            SapTransfer Transfer = null;
            SapView View = null;
            AcquisitionParameters Params = new AcquisitionParameters();
        }



    }

}
