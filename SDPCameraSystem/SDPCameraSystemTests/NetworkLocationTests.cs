using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class NetworkLocationTests
    {
        [TestMethod]
        public void CreateTestLocationWrapper()
        {
            TryToCreateNewLocationWrapper();
        }

        public void TryToCreateNewLocationWrapper()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestLocationWrapper = new NetworkLocation(TestConfigurationFile);
                Console.WriteLine("New LocationWrapper() created!");
            }
            catch (Exception CreateNewLocationWrapperException)
            {
                Console.WriteLine("Failed to create new LocationWrapper()! {0}",
                    CreateNewLocationWrapperException.Message);
            }
        }
    }
}
