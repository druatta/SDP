using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.Examples.NET.Utils;


namespace SDPCameraSystem
{
     class CameraObject
    {
        protected SapAcquisition m_Acq = null;
        protected SapAcqDevice m_AcqDevice = null;
        protected SapBuffer m_Buffers = null;
        protected SapView m_View = null;
        protected MyAcquisitionParams m_AcqParams = null;
        
        public CameraObject()
        {
            m_Acq = new SapAcquisition();
            m_AcqDevice = new SapAcqDevice();
        }

    }
    
}
