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
            GetTriggerTest();


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

        static void GetTriggerTest()
        {
            TryToGetATriggerInput();
        }

        static void TryToGetATriggerInput()
        {
            CameraFeed TestCameraFeed = new CameraFeed();
            try
            {
                while (TestCameraFeed.AcquisitionDeviceWrapper.CheckForTriggerSignal(TestCameraFeed) == false)
                {
                    ; // Do nothing
                }
                Console.WriteLine("Successfully got a trigger input!");
            }
            catch (Exception GetTriggerException)
            {
                Console.WriteLine("Failed to get a trigger input!", GetTriggerException.Message);
            }
        }
    }
}
