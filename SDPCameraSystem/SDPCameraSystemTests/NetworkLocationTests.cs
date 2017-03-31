using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class NetworkLocationTests
    {
        [TestMethod]
        public void TryToCreateNewLocationWrapperTest()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation NetworkLocation = new NetworkLocation(TestConfigurationFile);
            }
            catch (Exception CreateNewLocationWrapperException)
            {
                Assert.Fail(CreateNewLocationWrapperException.Message);
            }
        }
    }
}
