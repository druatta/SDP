using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class DataTransferTests
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
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestLocationWrapper = new NetworkLocation(TestConfigurationFile);
                EventHandler TestFeatureWrapper = new EventHandler(TestLocationWrapper);
                CameraObject TestDeviceWrapper = new CameraObject(TestConfigurationFile, TestLocationWrapper, TestFeatureWrapper);
                ImageBuffers TestBufferWrappers = new ImageBuffers(TestDeviceWrapper);
                ViewingWindow TestViewWrapper = new ViewingWindow(TestBufferWrappers);
                DataTransfer TestDataTransferWrapper = new DataTransfer(TestDeviceWrapper, TestBufferWrappers, TestViewWrapper);
                Console.WriteLine("Successfully created a data transfer!");
            }
            catch (Exception CreateDataTransferException)
            {
                Console.WriteLine("Failed to create a data transfer! {0}", CreateDataTransferException.Message);
            }
        }


    }
}
