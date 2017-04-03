using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class ViewingWindowTests
    {
        [TestMethod]
        public void TryToCreateViewingWindowTest()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestNetworkLocation = new NetworkLocation();
                EventHandler TestEventHandler = new EventHandler();
                CameraObject TestCameraObject = new CameraObject(TestConfigurationFile, TestNetworkLocation, TestEventHandler);
                ImageBuffers TestImageBuffers = new ImageBuffers(TestCameraObject);
                ViewingWindow TestViewingWindow = new ViewingWindow(TestImageBuffers);
            }
            catch (Exception CreateViewWrapperException)
            {
                Assert.Fail(CreateViewWrapperException.Message);
            }
        }
    }
}
