using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SDPCameraSystem
{
    [TestClass]
    public class CameraCompositionTests
    {
        [TestMethod]
        public void CreateTestCameraConfigurationFile()
        {
            TryToCreateCameraConfigurationFile();
        }

        public void TryToCreateCameraConfigurationFile()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateConfigurationFile();
                Console.WriteLine("Successfully created a camera configuration file!");
            }
            catch (Exception CreateCameraConfigurationFileException)
            {
                Console.WriteLine("Failed to create a Camera configuration file! {0}",
                    CreateCameraConfigurationFileException.Message);
            }
        }

        [TestMethod]
        public void CreateTestCameraNetworkLocation()
        {
            TryToCreateCameraNetworkLocation();
        }

        public void TryToCreateCameraNetworkLocation()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateNetworkLocation();
                Console.WriteLine("Successfully created Camera network location!");
            }
            catch (Exception CreateCameraNetworkLocationException)
            {
                Console.WriteLine("Failed to create camera network location! {0}",
                    CreateCameraNetworkLocationException.Message);
            }
        }

        [TestMethod]
        public void CreateTestCameraObject()
        {
            TryToCreateNewTestCameraObject();
        }
        
        public void TryToCreateNewTestCameraObject()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateCameraObject();
                Console.WriteLine("Successfully created a CameraObject()!");
            } 
            catch (Exception CreateCameraObjectException)
            {
                Console.WriteLine("Failed to create a CameraObject()!",
                    CreateCameraObjectException.Message);
            }
            
        }

        [TestMethod]
        public void CreateTestCameraImageBuffers()
        {
            TryToCreateNewCameraImageBuffers();
        }

        public void TryToCreateNewCameraImageBuffers()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateCameraObject();
                TestCameraFeed.CreateImageBuffers();
                Console.WriteLine("Successfully created the CameraImageBuffers()!");
            }
            catch (Exception CreateCameraImageBufferException)
            {
                Console.WriteLine("Failed to create CameraImageBuffers!",
                    CreateCameraImageBufferException.Message);
            }
        }

        [TestMethod]
        public void CreateTestCameraViewingWindow()
        {
            TryToCreateNewCameraViewingWindow();
        }

        public void TryToCreateNewCameraViewingWindow()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateCameraObject();
                TestCameraFeed.CreateImageBuffers();
                TestCameraFeed.CreateViewingWindow();
                Console.WriteLine("Successfully created a new camera viewing window!");
            }
            catch (Exception CreateCameraViewingWindowException)
            {
                Console.WriteLine("Failed to create a new camera viewing window! {0}",
                    CreateCameraViewingWindowException.Message);
            }
        }

        [TestMethod]
        public void CreateTestCameraDataTransfer()
        {
            TryToCreateNewCameraDataTransfer();
        }

        public void TryToCreateNewCameraDataTransfer()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateCameraObject();
                TestCameraFeed.CreateImageBuffers();
                TestCameraFeed.CreateViewingWindow();
                TestCameraFeed.CreateDataTransfer();
                Console.WriteLine("Successfully created a CameraDataTransfer!");
            }
            catch (Exception CreateCameraDataTransferException)
            {
                Console.WriteLine("Failed to create a new camera data transfer!",
                    CreateCameraDataTransferException.Message);
            }
        }

        [TestMethod]
        public void CreateTestCameraFeed()
        {
            TryToCreateNewCameraFeed();
        }

        public void TryToCreateNewCameraFeed()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                Console.WriteLine("Successfully created a CameraFeed()!");
            }
            catch (Exception CreateNewCameraFeedException)
            {
                Console.WriteLine("Failed to create a new Camera Feed! {0}",
                    CreateNewCameraFeedException.Message);
            }
        }

        [TestMethod]
        public void CreateTestCameraFeedThatSavesImagesOnExternalTrigger()
        {
            TryToCreateCameraFeedThatSavesImagesOnExternalTrigger();
        }

        
        public void TryToCreateCameraFeedThatSavesImagesOnExternalTrigger()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.SaveImageOnTriggerInputForever();
            }
            catch (Exception CreateCameraFeedWithExternalTriggerException)
            {
                Console.WriteLine("Failed to Create Camera Feed that saves images on External Trigger! {0}",
                    CreateCameraFeedWithExternalTriggerException.Message);
            }
        }
    }
}



