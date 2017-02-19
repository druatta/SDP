using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class NetworkLocation
    {
        public SapLocation Location;

        public NetworkLocation(ConfigurationFile ConfigurationFile)
        {
            Location = new SapLocation(ConfigurationFile.ServerName, ConfigurationFile.ResourceIndex);
        }
    }
}
