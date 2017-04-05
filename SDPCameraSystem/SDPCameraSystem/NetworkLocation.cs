using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class NetworkLocation
    {
        public NetworkLocation()
        {
            CreateConfigurationFile();
            AddConfigurationFileParametersToNetworkLocation();
        }

        public static SapLocation Location;
        public static void AddConfigurationFileParametersToNetworkLocation()
        {
            CreateConfigurationFile();
            Location = new SapLocation(ConfigurationFile.ServerName, ConfigurationFile.ResourceIndex);
        }

        public static void CreateConfigurationFile()
        {
            ConfigurationFile ConfigurationFile = new ConfigurationFile();
        }


    }
}
