using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class NetworkLocationTests
    {
        [TestMethod]
        public void ConstructNetworkLocation()
        {
            ConfigurationFile TestConfigurationFile = new ConfigurationFile();
            NetworkLocation NetworkLocation = new NetworkLocation(TestConfigurationFile);
        }

        [TestMethod]
        public void AddConfigurationFileParametersToNetworkLocationTest()
        {
            NetworkLocation.AddConfigurationFileParametersToNetworkLocation();
        }

    }
}
