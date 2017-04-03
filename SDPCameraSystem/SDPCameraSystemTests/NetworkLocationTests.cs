using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class NetworkLocationTests
    {
        [TestMethod]
        public void ConstructNetworkLocationTest()
        {
            NetworkLocation NetworkLocation = new NetworkLocation();
        }

        [TestMethod]
        public void AddConfigurationFileParametersToNetworkLocationTest()
        {
            NetworkLocation.AddConfigurationFileParametersToNetworkLocation();
        }

    }
}
