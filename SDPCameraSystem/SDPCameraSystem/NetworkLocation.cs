using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class NetworkLocation
    {
        public NetworkLocation()
        {
            AddConfigurationFileParametersToNetworkLocation();
        }

        public static SapLocation Location;
        public static void AddConfigurationFileParametersToNetworkLocation()
        {
            ConfigurationFile ConfigurationFile = new ConfigurationFile();
            Location = new SapLocation(ConfigurationFile.ServerName, ConfigurationFile.ResourceIndex);
        }


    }
}
