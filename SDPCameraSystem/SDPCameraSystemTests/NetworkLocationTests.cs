using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SDPCameraSystem
{
    [TestClass]
    public class NetworkLocationTests
    {
        [TestMethod]
        public void AddConfigurationFileParametersToNetworkLocationTest()
        {
            Assert.IsNotNull(ConfigurationFile.ServerName);
            Assert.IsNotNull(ConfigurationFile.ResourceIndex);
            NetworkLocation.AddConfigurationFileParametersToNetworkLocation();
            
        }




    }
}
