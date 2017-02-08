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
            CreateTestAcquisitionDevice();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void CreateTestAcquisitionDevice()
        {
            TryToCreateAnAcquisitionDevice();
        }

        static void TryToCreateAnAcquisitionDevice()
        {
            try
            {
                AcquisitionDeviceWrapper TestDevice = new AcquisitionDeviceWrapper();
                Console.WriteLine("Successfully created an AcquisitionDevice()!");
            }
            catch (Exception CreateAcquisitionDeviceException)
            {
                Console.WriteLine("Failed to create an AcquisitionDevice()! {0}",
                    CreateAcquisitionDeviceException.Message);
            }
        }
    }
}
