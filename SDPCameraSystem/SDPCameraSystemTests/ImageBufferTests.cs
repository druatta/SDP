using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class ImageBufferTests
    {
        [TestMethod]
        public void TryToCreateImageBufferTest()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestNetworkLocation = new NetworkLocation(TestConfigurationFile);
                EventHandler TestEventHandler = new EventHandler(TestNetworkLocation);
                CameraObject TestCameraObject = new CameraObject(TestConfigurationFile, TestNetworkLocation, TestEventHandler);
                ImageBuffers TestImageBuffers = new ImageBuffers(TestCameraObject);
            }
            catch (Exception CreateImageBufferException)
            {
                Assert.Fail(CreateImageBufferException.Message);
            }
        }

        [TestMethod]
        public void TryToCreateBufferSaveParametersTest()
        {
            try
            {
                CameraComposition TestCamera = new CameraComposition();
                TestCamera.ImageBuffers.CreateBufferSaveParameters(); 
            }
            catch (Exception CreateBufferSaveParametersException)
            {
                Assert.Fail(CreateBufferSaveParametersException.Message);
            }
        }

        [TestMethod]
        public void TryToPrintBufferSaveParametersTest()
        {
            try
            {
                CameraComposition TestCamera = new CameraComposition();
                TestCamera.ImageBuffers.PrintBufferSaveParameters();
            }
            catch (Exception PrintBufferSaveParametersException)
            {
                Assert.Fail(PrintBufferSaveParametersException.Message);
            }
        }

        [TestMethod]
        public void TryToSaveCurrentBufferToFileTest()
        {
            try
            {
                CameraComposition TestCamera = new CameraComposition();
                TestCamera.ImageBuffers.SaveBufferToFile();
            }
            catch (Exception SaveCurrentBufferToFileException)
            {
                Assert.Fail(SaveCurrentBufferToFileException.Message);
            }
        }


    }
}
