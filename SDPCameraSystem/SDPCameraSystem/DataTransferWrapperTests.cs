using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class DataTransferWrapperTests
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the DataTransfer tests. ");
        //    CreateTestDataTransferWrapper();

        //    Console.WriteLine("Press any key to terminate this test.");
        //    Console.ReadKey();
        //}

        static void CreateTestDataTransferWrapper()
        {
            TryToCreateADataTransferWrapper();
        }

        static void TryToCreateADataTransferWrapper()
        {
            try
            {
                AcquisitionDeviceWrapper TestDeviceWrapper = new AcquisitionDeviceWrapper();
                BufferWrappers TestBufferWrappers = new BufferWrappers(TestDeviceWrapper);
                CameraViewWrapper TestViewWrapper = new CameraViewWrapper(TestBufferWrappers);
                DataTransferWrapper TestDataTransferWrapper = new DataTransferWrapper(TestDeviceWrapper, TestBufferWrappers, TestViewWrapper);
            }
            catch (Exception CreateDataTransferException)
            {
                Console.WriteLine("Failed to create a data transfer! {0}", CreateDataTransferException.Message);
            }
        }


    }
}
