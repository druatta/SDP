using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SDPCameraSystem
{
    [TestClass]
    public class CameraCompositionTests
    {
        [TestMethod]
        public void TryToCreateCameraConfigurationFile()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateConfigurationFile();
            }
            catch (Exception CreateCameraConfigurationFileException)
            {
               Assert.Fail(CreateCameraConfigurationFileException.Message);
            }
        }

        [TestMethod]
        public void TryToCreateCameraNetworkLocationTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateNetworkLocation();
            }
            catch (Exception CreateCameraNetworkLocationException)
            {
                Assert.Fail(CreateCameraNetworkLocationException.Message);
            }
        }

        [TestMethod]
        public void TryToCreateNewTestCameraObjectTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateCameraObject();
            } 
            catch (Exception CreateCameraObjectException)
            {
                Assert.Fail(CreateCameraObjectException.Message);
            }
            
        }

        [TestMethod]
        public void TryToCreateNewCameraImageBuffersTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateCameraObject();
                TestCameraFeed.CreateImageBuffers();
            }
            catch (Exception CreateCameraImageBufferException)
            {
                Assert.Fail(CreateCameraImageBufferException.Message);
            }
        }

        [TestMethod]
        public void TryToCreateNewCameraViewingWindowTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateCameraObject();
                TestCameraFeed.CreateImageBuffers();
                TestCameraFeed.CreateViewingWindow();
            }
            catch (Exception CreateCameraViewingWindowException)
            {
                Assert.Fail(CreateCameraViewingWindowException.Message);
            }
        }

        [TestMethod]
        public void TryToCreateNewCameraDataTransferTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateCameraObject();
                TestCameraFeed.CreateImageBuffers();
                TestCameraFeed.CreateViewingWindow();
                TestCameraFeed.CreateDataTransfer();
            }
            catch (Exception CreateCameraDataTransferException)
            {
                Assert.Fail(CreateCameraDataTransferException.Message);
            }
        }

        [TestMethod]
        public void TryToCreateNewCameraFeedTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
            }
            catch (Exception CreateNewCameraFeedException)
            {
                Assert.Fail(CreateNewCameraFeedException.Message);
            }
        }

        [TestMethod, Timeout(1000)]
        public void TryToCreateCameraFeedThatSavesImagesOnExternalTriggerTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.SaveImageOnTriggerInputForever();
            }
            catch (Exception CreateCameraFeedWithExternalTriggerException)
            {
                Assert.Fail(CreateCameraFeedWithExternalTriggerException.Message);
            }
        }
    }
}



