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
        public SapLocation Location;

        public LocationWrapper(ConfigurationFile ConfigurationFile)
        {
            Location = new SapLocation(ConfigurationFile.ServerName, ConfigurationFile.ResourceIndex);
        }
    }
}
