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
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                LocationWrapper TestLocationWrapper = new LocationWrapper(TestConfigurationFile);
                FeatureWrapper TestFeatureWrapper = new FeatureWrapper(TestLocationWrapper);
                AcquisitionDeviceWrapper TestDeviceWrapper = new AcquisitionDeviceWrapper(TestConfigurationFile, TestLocationWrapper, TestFeatureWrapper);
                BufferWrappers TestBufferWrappers = new BufferWrappers(TestDeviceWrapper);
                ViewWrapper TestViewWrapper = new ViewWrapper(TestBufferWrappers);
                DataTransferWrapper TestDataTransferWrapper = new DataTransferWrapper(TestDeviceWrapper, TestBufferWrappers, TestViewWrapper);
                Console.WriteLine("Successfully created a data transfer!");
            }
            catch (Exception CreateDataTransferException)
            {
                Console.WriteLine("Failed to create a data transfer! {0}", CreateDataTransferException.Message);
            }
        }


    }
}
