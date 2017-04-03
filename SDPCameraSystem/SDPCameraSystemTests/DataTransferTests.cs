using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class DataTransferTests
    {
        [TestMethod]
         public void TryToCreateADataTransferTest()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestNetworkLocation = new NetworkLocation();
                EventHandler TestEventHandler = new EventHandler();
                CameraObject TestCameraObject = new CameraObject(TestConfigurationFile, TestNetworkLocation, TestEventHandler);
                ImageBuffers TestImageBuffers = new ImageBuffers(TestCameraObject);
                ViewingWindow TestViewingWindow = new ViewingWindow(TestImageBuffers);
                DataTransfer TestDataTransfer = new DataTransfer(TestCameraObject, TestImageBuffers, TestViewingWindow);
            }
            catch (Exception CreateDataTransferException)
            {
                Assert.Fail(CreateDataTransferException.Message);
            }
        }


    }
}
