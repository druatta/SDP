using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class AcquisitionDeviceWrapperTests
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! These are the AcquisitionDevice tests. ");
            //CreateTestAcquisitionDeviceWrapper();
            WaitForTriggerTest();
            CreateTestAcquisitionDeviceNotificationInterface();


            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void CreateTestAcquisitionDeviceWrapper()
        {
            TryToCreateAnAcquisitionDeviceWrapper();
        }

        static void TryToCreateAnAcquisitionDeviceWrapper()
        {
            try
            {
                AcquisitionDeviceWrapper TestDeviceWrapper = new AcquisitionDeviceWrapper();
                Console.WriteLine("Successfully created an AcquisitionDevice()!");
            }
            catch (Exception CreateAcquisitionDeviceWrapperException)
            {
                Console.WriteLine("Failed to create an AcquisitionDevice()! {0}",
                    CreateAcquisitionDeviceWrapperException.Message);
            }
        }

        static void WaitForTriggerTest()
        {
            TryToWaitForATriggerInput();
        }

        static void TryToWaitForATriggerInput()
        {
            CameraFeed TestCameraFeed = new CameraFeed();
            try
            {
                TestCameraFeed.AcquisitionDeviceWrapper.WaitForTriggerInput();
                Console.WriteLine("Successfully waited for a trigger input!");
            }
            catch (Exception GetTriggerException)
            {
                Console.WriteLine("Failed to get a trigger input!", GetTriggerException.Message);
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
    }
}
