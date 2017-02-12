using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class AcquisitionDeviceWrapperTests
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the AcquisitionDevice tests. ");
        //    //CreateTestAcquisitionDeviceWrapper();
        //    //TestEnableChangesInFeatureValues();
        //    WaitForTriggerTest();
        //    //CreateTestAcquisitionDeviceNotificationInterface();


        //    Console.WriteLine("Press any key to terminate.");
        //    Console.ReadKey();
        //}

        static void CreateTestAcquisitionDeviceWrapper()
        {
            TryToCreateAnAcquisitionDeviceWrapper();
        }

        static void TryToCreateAnAcquisitionDeviceWrapper()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                LocationWrapper TestLocationWrapper = new LocationWrapper(TestConfigurationFile);
                FeatureWrapper TestFeatureWrapper = new FeatureWrapper(TestLocationWrapper);
                AcquisitionDeviceWrapper TestDeviceWrapper = new AcquisitionDeviceWrapper(TestConfigurationFile, TestLocationWrapper, TestFeatureWrapper);
                Console.WriteLine("Successfully created an AcquisitionDevice()!");
            }
            catch (Exception CreateAcquisitionDeviceWrapperException)
            {
                Console.WriteLine("Failed to create an AcquisitionDevice()! {0}",
                    CreateAcquisitionDeviceWrapperException.Message);
            }
        }

        static void CreateTestAcquisitionDeviceNotificationInterface()
        {
            TryToCreateAnAcquisitionDeviceNotificationInterface();
        }

        static void TryToCreateAnAcquisitionDeviceNotificationInterface()
        {
            try
            {
                CameraFeed TestCameraFeed = new CameraFeed();
                TestCameraFeed.AcquisitionDeviceWrapper.CreateAcquisitionDeviceNotificationInterface();
                Console.WriteLine("Successfully created an AcquisitionDevice callback!");
            }
            catch (Exception CreateAcquisitionDeviceCallbackException)
            {
                Console.WriteLine("Failed to create an AcquisitionDevice callback! {0}",
                    CreateAcquisitionDeviceCallbackException.Message);
            }
        }

        static void TestEnableChangesInFeatureValues()
        {
            TryToEnableChangesInFeatureValues();
        }

        static void TryToEnableChangesInFeatureValues()
        {
            try
            {
                CameraFeed TestCameraFeed = new CameraFeed();
                TestCameraFeed.AcquisitionDeviceWrapper.EnableChangesInFeatureValues();
                Console.WriteLine("Successfully enabled changes in Feature values!");
            }
            catch (Exception EnableChangesInFeatureValuesException)
            {
                Console.WriteLine("Failed to enable changes in feature values!",
                    EnableChangesInFeatureValuesException.Message);
            }
        }

        static void WaitForTriggerTest()
        {
            TryToWaitForATriggerInput();
        }

        static void TryToWaitForATriggerInput()
        {
            try
            {
                CameraFeed TestCameraFeed = new CameraFeed();
                while (true)
                {
                    TestCameraFeed.AcquisitionDeviceWrapper.CheckForChangeInTriggerInput(TestCameraFeed.FeatureWrapper);
                }
            }
            catch (Exception GetTriggerException)
            {
                Console.WriteLine("Failed to get a trigger input!", GetTriggerException.Message);
            }
        }
    }
}
