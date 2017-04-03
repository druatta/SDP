using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class NetworkLocationTests
    {
        [TestMethod]
        public void CreateNewLocationWrapperTest()
        {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation NetworkLocation = new NetworkLocation(TestConfigurationFile);
        }
    }
}
