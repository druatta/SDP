using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class CameraObjectTests
    {
        [TestMethod]
        public void CreateTestAcquisitionDeviceWrapper()
        {
            TryToCreateAnAcquisitionDeviceWrapper();
        }

        public void TryToCreateAnAcquisitionDeviceWrapper()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestLocationWrapper = new NetworkLocation(TestConfigurationFile);
                EventHandler TestFeatureWrapper = new EventHandler(TestLocationWrapper);
                CameraObject TestDeviceWrapper = new CameraObject(TestConfigurationFile, TestLocationWrapper, TestFeatureWrapper);
                Console.WriteLine("Successfully created an AcquisitionDevice()!");
            }
            catch (Exception CreateAcquisitionDeviceWrapperException)
            {
                Console.WriteLine("Failed to create an AcquisitionDevice()! {0}",
                    CreateAcquisitionDeviceWrapperException.Message);
            }
        }

        [TestMethod]
        public void CreateTestAcquisitionDeviceNotificationInterface()
        {
            TryToCreateAnAcquisitionDeviceNotificationInterface();
        }

        public void TryToCreateAnAcquisitionDeviceNotificationInterface()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CameraObject.CreateAcquisitionDeviceNotificationInterface();
                Console.WriteLine("Successfully created an AcquisitionDevice callback!");
            }
            catch (Exception CreateAcquisitionDeviceCallbackException)
            {
                Console.WriteLine("Failed to create an AcquisitionDevice callback! {0}",
                    CreateAcquisitionDeviceCallbackException.Message);
            }
        }

        [TestMethod]
        public void TestEnableChangesInFeatureValues()
        {
            TryToEnableChangesInFeatureValues();
        }

        public void TryToEnableChangesInFeatureValues()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CameraObject.EnableChangesInFeatureValues();
                Console.WriteLine("Successfully enabled changes in Feature values!");
            }
            catch (Exception EnableChangesInFeatureValuesException)
            {
                Console.WriteLine("Failed to enable changes in feature values!",
                    EnableChangesInFeatureValuesException.Message);
            }
        }

        [TestMethod, Timeout(1000)]
        public void WaitForTriggerTest()
        {
            TryToWaitForATriggerInput();
        }

        public void TryToWaitForATriggerInput()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                while (true)
                {
                    TestCameraFeed.CameraObject.CheckForChangeInTriggerInput(TestCameraFeed.EventHandler);
                }
            }
            catch (Exception GetTriggerException)
            {
                Console.WriteLine("Failed to get a trigger input!", GetTriggerException.Message);
            }
        }
    }
}
