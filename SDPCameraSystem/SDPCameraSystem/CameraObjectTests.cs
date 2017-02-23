using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class CameraObjectTests
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

        static void CreateTestAcquisitionDeviceNotificationInterface()
        {
            TryToCreateAnAcquisitionDeviceNotificationInterface();
        }

        static void TryToCreateAnAcquisitionDeviceNotificationInterface()
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

        static void TestEnableChangesInFeatureValues()
        {
            TryToEnableChangesInFeatureValues();
        }

        static void TryToEnableChangesInFeatureValues()
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

        static void WaitForTriggerTest()
        {
            TryToWaitForATriggerInput();
        }

        static void TryToWaitForATriggerInput()
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
