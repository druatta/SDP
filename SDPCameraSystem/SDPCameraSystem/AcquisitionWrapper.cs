using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class AcquisitionWrapper
    {
        public SapAcquisition Acquisition; 

        public AcquisitionWrapper()
        {
            CreateAcquisition();
            UseSaperaCreateToCheckForSuccessfulAcquisitionCreation();
        }

        public void CreateAcquisition()
        {
            Acquisition = new SapAcquisition();
        }

        public void UseSaperaCreateToCheckForSuccessfulAcquisitionCreation()
        {
            Acquisition.Create();
        }

    }
}
