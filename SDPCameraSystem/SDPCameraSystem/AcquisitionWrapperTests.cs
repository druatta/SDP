using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class AcquisitionWrapperTests
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the AcquisitionWrapper tests. ");
        //    CreateTestAcquisitionWrapper();


        //    Console.WriteLine("Press any key to terminate.");
        //    Console.ReadKey();
        //}

        static void CreateTestAcquisitionWrapper()
        {
            TryToCreateAcquisitionWrapper();
        }

        static void TryToCreateAcquisitionWrapper()
        {
            try
            {
                AcquisitionWrapper TestAcquisitionWrapper = new AcquisitionWrapper();
                Console.WriteLine("Successfully created an AcquisitionWrapper!");
            }
            catch (Exception CreateAcquisitionWrapperException)
            {
                Console.WriteLine("Failed to create an Acquisition Wrapper! {0}",
                    CreateAcquisitionWrapperException.Message);
            }
        }

    }
}
