using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class DataTransferTests
    {
        [TestMethod]
        public void CreateTestDataTransferWrapper()
        {
            TryToCreateADataTransferWrapper();
        }

        public void TryToCreateADataTransferWrapper()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestLocationWrapper = new NetworkLocation(TestConfigurationFile);
                EventHandler TestFeatureWrapper = new EventHandler(TestLocationWrapper);
                CameraObject TestDeviceWrapper = new CameraObject(TestConfigurationFile, TestLocationWrapper, TestFeatureWrapper);
                ImageBuffers TestBufferWrappers = new ImageBuffers(TestDeviceWrapper);
                ViewingWindow TestViewWrapper = new ViewingWindow(TestBufferWrappers);
                DataTransfer TestDataTransferWrapper = new DataTransfer(TestDeviceWrapper, TestBufferWrappers, TestViewWrapper);
                Console.WriteLine("Successfully created a data transfer!");
            }
            catch (Exception CreateDataTransferException)
            {
                Console.WriteLine("Failed to create a data transfer! {0}", CreateDataTransferException.Message);
            }
        }


    }
}
