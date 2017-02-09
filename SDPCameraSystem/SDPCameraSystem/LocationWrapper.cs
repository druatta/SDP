using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class LocationWrapper
    {
        private ConfigurationParameters LocationParameters = new ConfigurationParameters();
        public SapLocation Location;

        public LocationWrapper()
        {
            Location = new SapLocation(LocationParameters.ServerName, LocationParameters.ResourceIndex);
        }
    }
}
