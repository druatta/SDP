using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class ViewWrapperTests
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the DataTransfer tests. ");
        //    CreateTestViewWrapper();

        //    Console.WriteLine("Press any key to terminate this test.");
        //    Console.ReadKey();
        //}

        static void CreateTestViewWrapper()
        {
            TryToCreateNewTestViewWrapper();
        }

        static void TryToCreateNewTestViewWrapper()
        {
            try
            {
                AcquisitionDeviceWrapper TestDeviceWrapper = new AcquisitionDeviceWrapper();
                BufferWrappers TestBufferWrappers = new BufferWrappers(TestDeviceWrapper);
                ViewWrapper TestViewWrapper = new ViewWrapper(TestBufferWrappers);
                Console.WriteLine("Successfully created a new TestViewWrapper()!");
            }
            catch (Exception CreateViewWrapperException)
            {
                Console.WriteLine("Failed to create a new TestViewWrapper! {0}",
                    CreateViewWrapperException.Message);
            }
        }
    }
}
