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
            NetworkLocation.AddConfigurationFileParametersToNetworkLocation();
            
        }

        [TestMethod]
        public void CreateConfigurationFileTest()
        {
            NetworkLocation.CreateConfigurationFile();
        }



    }
}
