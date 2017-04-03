using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class NetworkLocation
    {
        public NetworkLocation(ConfigurationFile ConfigurationFile)
        {
            AddConfigurationFileParametersToNetworkLocation();
        }

        public static SapLocation Location;
        public static void AddConfigurationFileParametersToNetworkLocation()
        {
            Location = new SapLocation(ConfigurationFile.ServerName, ConfigurationFile.ResourceIndex);
        }


    }
}
