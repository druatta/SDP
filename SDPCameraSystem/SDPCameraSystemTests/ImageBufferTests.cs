using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class ImageBufferTests
    {
        [TestMethod]
        public void CreateTestBufferWrappers()
        {
            TryToCreateBufferWrappers();
        }

        public void TryToCreateBufferWrappers()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestLocationWrapper = new NetworkLocation(TestConfigurationFile);
                EventHandler TestFeatureWrapper = new EventHandler(TestLocationWrapper);
                CameraObject TestDeviceWrapper = new CameraObject(TestConfigurationFile, TestLocationWrapper, TestFeatureWrapper);
                ImageBuffers TestBufferWrappers = new ImageBuffers(TestDeviceWrapper);
                Console.WriteLine("Successfully created the BufferWrappers()!");
            }
            catch (Exception CreateBufferWrapperException)
            {
                Console.WriteLine("Failed to create a BufferWrapper()! {0}",
                    CreateBufferWrapperException.Message);
            }
        }

        [TestMethod]
        public void TestCreateBufferSaveParameters()
        {
            TryToCreateBufferSaveParameters();
        }

        public void TryToCreateBufferSaveParameters()
        {
            try
            {
                CameraComposition TestFeed = new CameraComposition();
                TestFeed.ImageBuffers.CreateBufferSaveParameters(); // Is currently in the Buffer Wrapper constructor!
                Console.WriteLine("Successfully created the Buffer Save Parameters!");
            }
            catch (Exception CreateBufferSaveParametersException)
            {
                Console.WriteLine("Failed to create Buffer Save Parameters! {0}",
                    CreateBufferSaveParametersException.Message);
            }
        }

        [TestMethod]
        public void PrintBufferSaveParameters()
        {
            TryToPrintBufferSaveParameters();
        }

        public void TryToPrintBufferSaveParameters()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.ImageBuffers.PrintBufferSaveParameters();
            }
            catch (Exception PrintBufferSaveParametersException)
            {
                Console.WriteLine("Failed to print out the Buffer Save Parameters! {0}",
                    PrintBufferSaveParametersException.Message);
            }
        }

        [TestMethod]
        public void TestSaveCurrentBufferToFile()
        {
            TryToSaveCurrentBufferToFile();
        }

        public void TryToSaveCurrentBufferToFile()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.ImageBuffers.SaveBufferToFile();
                Console.WriteLine("Successfully saved the current buffer to file!");
            }
            catch (Exception SaveCurrentBufferToFileException)
            {
                Console.WriteLine("Failed to save current buffer to file! {0}",
                    SaveCurrentBufferToFileException.Message);
            }
        }


    }
}
