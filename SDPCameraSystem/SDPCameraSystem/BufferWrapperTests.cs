using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class BufferWrapperTests
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the BufferWrapper tests. ");
        //    CreateTestBufferWrappers();

        //    Console.WriteLine("Press any key to terminate.");
        //    Console.ReadKey();
        //}

        static void CreateTestBufferWrappers()
        {
            TryToCreateBufferWrappers();
        }

        static void TryToCreateBufferWrappers()
        {
            try
            {
                AcquisitionDeviceWrapper TestDeviceWrapper = new AcquisitionDeviceWrapper();
                BufferWrappers TestWrappers = new BufferWrappers(TestDeviceWrapper);
                Console.WriteLine("Successfully created the BufferWrappers()!");
            }
            catch (Exception CreateBufferWrapperException)
            {
                Console.WriteLine("Failed to create a BufferWrapper()! {0}",
                    CreateBufferWrapperException.Message);
            }
        }
    }
}
