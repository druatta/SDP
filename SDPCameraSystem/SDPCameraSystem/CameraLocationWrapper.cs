using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class CameraLocationWrapper
    {
        protected ConfigurationParameters LocationParameters = new ConfigurationParameters();
        public SapLocation Location = null;

        public CameraLocationWrapper()
        {
            Location = new SapLocation(LocationParameters.ServerName, LocationParameters.ResourceIndex);
        }
    }
}
