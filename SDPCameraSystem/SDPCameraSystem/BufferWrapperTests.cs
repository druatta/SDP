using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class BufferWrapperTests
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! These are the BufferWrapper tests. ");
            //CreateTestBufferWrappers();
            TestSaveCurrentBufferToFile();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void CreateTestBufferWrappers()
        {
            TryToCreateBufferWrappers();
        }

        static void TryToCreateBufferWrappers()
        {
            try
            {
                AcquisitionDeviceWrapper TestDeviceWrapper = new AcquisitionDeviceWrapper();
                BufferWrappers TestBufferWrappers = new BufferWrappers(TestDeviceWrapper);
                Console.WriteLine("Successfully created the BufferWrappers()!");
            }
            catch (Exception CreateBufferWrapperException)
            {
                Console.WriteLine("Failed to create a BufferWrapper()! {0}",
                    CreateBufferWrapperException.Message);
            }
        }

        static void TestSaveCurrentBufferToFile()
        {
            TryToSaveCurrentBufferToFile();
        }

        static void TryToSaveCurrentBufferToFile()
        {
            try
            {
                CameraFeed TestCameraFeed = new CameraFeed();
                TestCameraFeed.BufferWrappers.SaveBufferToFile();
                Console.WriteLine("Successfully saved the current buffer to file!");
            }
            catch (Exception SaveCurrentBufferToFileException)
            {
                Console.WriteLine("Failed to save current buffer to file! {0}",
                    SaveCurrentBufferToFileException.Message);
            }
        }
    }
}
