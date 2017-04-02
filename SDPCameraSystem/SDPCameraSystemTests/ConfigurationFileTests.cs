using DALSA.SaperaLT.SapClassBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SDPCameraSystem
{
    [TestClass]
    public class ConfigurationFileTests
    {
        [TestMethod]
        public void CreateConfigurationFileTest()
        {
            //ConfigurationFile TestConfigurationFile = new ConfigurationFile();
            Assert.Fail("Have not completed this test yet.");
        }

        [TestMethod]
        public void AssignConfigurationFileServerNameTest()
        {
            ConfigurationFile.AssignConfigurationFileServerName();
            AssertConfigurationFileServerNameIsFound();
        }

        public void AssertConfigurationFileServerNameIsFound()
        {
            Assert.AreNotEqual(SapManager.LastStatusCode, SapStatus.SERVER_NOT_FOUND, SapManager.LastStatusMessage);
        }

        [TestMethod]
        public void FindConfigurationFilePathTest()
        {
            ConfigurationFile.FindConfigurationFilePath();
            
        }

        public void AssertConfigurationFilePathExists()
        {
            Assert.IsNotNull(;
        }

        //[TestMethod]
        //public void AssignAConfigurationFilePathTest()
        //{
        //    ConfigurationFile.AssignConfigurationFilePath();
        //}

        [TestMethod]
        public void FindACameraConfigurationFileTest()
        {
            ConfigurationFile.FindACameraConfigurationFile();
            //Assert.Fail("Have not completed this test yet.");
        }

        [TestMethod]
        public void AssignCCFParametersToConfigurationFileTest()
        {
            //AssignCCFParametersToConfigurationFile();
            Assert.Fail("Have not completed this test yet.");
        }


    }
}
