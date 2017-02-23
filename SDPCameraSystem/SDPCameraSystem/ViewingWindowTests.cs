using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class ViewingWindowTests
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
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestLocationWrapper = new NetworkLocation(TestConfigurationFile);
                EventHandler TestFeatureWrapper = new EventHandler(TestLocationWrapper);
                CameraObject TestDeviceWrapper = new CameraObject(TestConfigurationFile, TestLocationWrapper, TestFeatureWrapper);
                ImageBuffers TestBufferWrappers = new ImageBuffers(TestDeviceWrapper);
                ViewingWindow TestViewWrapper = new ViewingWindow(TestBufferWrappers);
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
