using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class ViewingWindowTests
    {
        [TestMethod]
        public void CreateTestViewWrapper()
        {
            TryToCreateNewTestViewWrapper();
        }

        public void TryToCreateNewTestViewWrapper()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestLocationWrapper = new NetworkLocation(TestConfigurationFile);
                EventHandler TestFeatureWrapper = new EventHandler(TestLocationWrapper);
                CameraObject TestDeviceWrapper = new CameraObject(TestConfigurationFile, TestLocationWrapper, TestFeatureWrapper);
                ImageBuffers TestBufferWrappers = new ImageBuffers(TestDeviceWrapper);
                ViewingWindow TestViewWrapper = new ViewingWindow(TestBufferWrappers);
                Console.WriteLine("Successfully created a new TestViewWrapper()!");
            }
            catch (Exception CreateViewWrapperException)
            {
                Console.WriteLine("Failed to create a new TestViewWrapper! {0}",
                    CreateViewWrapperException.Message);
            }
        }
    }
}
