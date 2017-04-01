using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SDPCameraSystem
{
    [TestClass]
    public class ConfigurationFileTests : ConfigurationFile
    {
        [TestMethod]
        public void CreateConfigurationFileTest()
        {
            ConfigurationFile TestConfigurationFile = new ConfigurationFile();
        }

        [TestMethod]
        public void AssignConfigurationFileServerNameTest()
        {
            try
            {
                AssignConfigurationFileServerName();
            } catch (Exception AssignConfigurationFileServerNameException)
            {
                throw new Exception("Configuration file server name not found! " +
                    AssignConfigurationFileServerNameException.Message);
            }
        }

        [TestMethod]
        public void AssignConfigurationFilePathTest()
        {
            AssignConfigurationFilePath();
        }

        [TestMethod]
        public void AssignCCFParametersToConfigurationFileTest()
        {
            AssignCCFParametersToConfigurationFile();
        }

        [TestMethod]
        public void FindACameraConfigurationFileTest()
        {
            FindACameraConfigurationFile();
        }

    }
}
