using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using System.Diagnostics;
using System.IO;

namespace SDPCameraSystem
{
    class CameraCompositionTests
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! These are the CameraFeed tests. ");
            Console.WriteLine("These tests can only be run one at a time because " +
                "we only have one physical camera to test them on.");
            Console.WriteLine("Add functionality to the CreateCameraFeed() function" +
                " as you change tests!");
            //CreateTestCameraConfigurationFile();
            //CreateTestCameraNetworkLocation();
            //CreateTestCameraObject();
            //CreateTestCameraImageBuffers();
            //CreateTestCameraViewingWindow();
            //CreateTestCameraDataTransfer();
            //CreateTestCameraFeed();
            CreateTestCameraFeedThatSavesImagesOnExternalTrigger();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void CreateTestCameraConfigurationFile()
        {
            TryToCreateCameraConfigurationFile();
        }

        static void TryToCreateCameraConfigurationFile()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateConfigurationFile();
                Console.WriteLine("Successfully created a camera configuration file!");
            }
            catch (Exception CreateCameraConfigurationFileException)
            {
                Console.WriteLine("Failed to create a Camera configuration file! {0}",
                    CreateCameraConfigurationFileException.Message);
            }
        }

        static void CreateTestCameraNetworkLocation()
        {
            TryToCreateCameraNetworkLocation();
        }

        static void TryToCreateCameraNetworkLocation()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateNetworkLocation();
                Console.WriteLine("Successfully created Camera network location!");
            }
            catch (Exception CreateCameraNetworkLocationException)
            {
                Console.WriteLine("Failed to create camera network location! {0}",
                    CreateCameraNetworkLocationException.Message);
            }
        }


        static void CreateTestCameraObject()
        {
            TryToCreateNewTestCameraObject();
        }

        static void TryToCreateNewTestCameraObject()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateObject();
                Console.WriteLine("Successfully created a CameraObject()!");
            } 
            catch (Exception CreateCameraObjectException)
            {
                Console.WriteLine("Failed to create a CameraObject()!",
                    CreateCameraObjectException.Message);
            }
            
        }

        static void CreateTestCameraImageBuffers()
        {
            TryToCreateNewCameraImageBuffers();
        }

        static void TryToCreateNewCameraImageBuffers()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateObject();
                TestCameraFeed.CreateImageBuffers();
                Console.WriteLine("Successfully created the CameraImageBuffers()!");
            }
            catch (Exception CreateCameraImageBufferException)
            {
                Console.WriteLine("Failed to create CameraImageBuffers!",
                    CreateCameraImageBufferException.Message);
            }
        }

        static void CreateTestCameraViewingWindow()
        {
            TryToCreateNewCameraViewingWindow();
        }

        static void TryToCreateNewCameraViewingWindow()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateObject();
                TestCameraFeed.CreateImageBuffers();
                TestCameraFeed.CreateViewingWindow();
                Console.WriteLine("Successfully created a new camera viewing window!");
            }
            catch (Exception CreateCameraViewingWindowException)
            {
                Console.WriteLine("Failed to create a new camera viewing window! {0}",
                    CreateCameraViewingWindowException.Message);
            }
        }

        static void CreateTestCameraDataTransfer()
        {
            TryToCreateNewCameraDataTransfer();
        }

        static void TryToCreateNewCameraDataTransfer()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CreateObject();
                TestCameraFeed.CreateImageBuffers();
                TestCameraFeed.CreateViewingWindow();
                TestCameraFeed.CreateDataTransfer();
                Console.WriteLine("Successfully created a CameraDataTransfer!");
            }
            catch (Exception CreateCameraDataTransferException)
            {
                Console.WriteLine("Failed to create a new camera data transfer!",
                    CreateCameraDataTransferException.Message);
            }
        }
        

        static void CreateTestCameraFeed()
        {
            TryToCreateNewCameraFeed();
        }

        static void TryToCreateNewCameraFeed()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                Console.WriteLine("Successfully created a CameraFeed()!");
            }
            catch (Exception CreateNewCameraFeedException)
            {
                Console.WriteLine("Failed to create a new Camera Feed! {0}",
                    CreateNewCameraFeedException.Message);
            }
        }

        static void CreateTestCameraFeedThatSavesImagesOnExternalTrigger()
        {
            TryToCreateCameraFeedThatSavesImagesOnExternalTrigger();
        }

        static void TryToCreateCameraFeedThatSavesImagesOnExternalTrigger()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.SaveImageOnTriggerInputForever();
            }
            catch (Exception CreateCameraFeedWithExternalTriggerException)
            {
                Console.WriteLine("Failed to Create Camera Feed that saves images on External Trigger! {0}",
                    CreateCameraFeedWithExternalTriggerException.Message);
            }
        }
    }
}



