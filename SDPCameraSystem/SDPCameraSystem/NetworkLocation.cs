using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class NetworkLocation
    {
        public SapLocation Location;

        public NetworkLocation(ConfigurationFile ConfigurationFile)
        {
            Location = new SapLocation(ConfigurationFile.ServerName, ConfigurationFile.ResourceIndex);
        }
    }
}
