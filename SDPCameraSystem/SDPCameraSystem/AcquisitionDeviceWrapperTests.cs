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
        //    CreateTestAcquisitionDeviceWrapper();

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
                AcquisitionDeviceWrapper TestDeviceWrapper = new AcquisitionDeviceWrapper();
                Console.WriteLine("Successfully created an AcquisitionDevice()!");
            }
            catch (Exception CreateAcquisitionDeviceWrapperException)
            {
                Console.WriteLine("Failed to create an AcquisitionDevice()! {0}",
                    CreateAcquisitionDeviceWrapperException.Message);
            }
        }
    }
}
