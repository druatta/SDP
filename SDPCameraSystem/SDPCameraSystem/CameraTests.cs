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
    class CameraTests
    {
        /// <summary>
        /// Test driven development for the CameraObject below. All unit tests are within main(). 
        /// Run only one test at a time to ensure that multiple camera feeds
        /// are not created at the same time.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! These are the CameraObject tests.");
            TestCreateCamera();
            // TestCreateAcquisitionDevice();
            // TestRefreshFrameRate();
            // TestCreateBuffers();
            // TestCreateTransfer();
            // TestCreateView();
            // TestGrabView();


            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void TestCreateCamera()
        {
            try
            {
                Camera TestCamera = new Camera();
                Console.WriteLine("TestCreateCamera() passed!");
            }
            catch (Exception CreateCameraException)
            {
                Console.WriteLine("TestCreateCamera() failed! {0}", CreateCameraException.Message);
            }
        }

        static void TestCreateAcquisitionDevice()
        {
            try
            {
                Camera TestCamera = new Camera();
                TestCamera.Device.Create();
                Console.WriteLine("TestCreateAcqusitionDevice() passed!");
            }
            catch (Exception CreateAcquisitionDeviceException)
            {
                Console.WriteLine("TestCreateAcquisitionDevice() failed! {0}", CreateAcquisitionDeviceException.Message);
            }
        }

        static void TestRefreshFrameRate()
        {
            try
            {
                Camera TestCamera = new Camera();
                TestCamera.RefreshFrameRate();
                Console.WriteLine("TestRefreshFrame() passed!");
            }
            catch (Exception RefreshFrameException)
            {
                Console.WriteLine("TestRefreshFrame() failed! {0}", RefreshFrameException.Message);
            }
        }

        static void TestCreateBuffers()
        {
            try
            {
                Camera TestCamera = new Camera();
                TestCamera.CreateBuffers();
                Console.WriteLine("TestCreateBuffers() passed!");
            }
            catch (Exception CreateBufferException)
            {
                Console.WriteLine("TestCreateBuffer() failed! {0}", CreateBufferException.Message);
            }
        }

        static void TestCreateTransfer()
        {
            try
            {
                Camera TestCamera = new Camera();
                TestCamera.CreateTransfer();
                Console.WriteLine("TestCreateTransfer() passed!");
            }
            catch (Exception CreateTransferException)
            {
                Console.WriteLine("TestCreateTransfer() failed! {0}", CreateTransferException.Message);
            }
        }

        static void TestCreateView()
        {
            try
            {
                Camera TestCamera = new Camera();
                TestCamera.CreateView();
                Console.WriteLine("TestCreateView() passed!");
            }
            catch (Exception CreateViewException)
            {
                Console.WriteLine("TestCreateView() failed! {0}", CreateViewException.Message);
            }
        }

        static void TestGrabView()
        {
            try
            {
                Camera TestCamera = new Camera();
                TestCamera.Transfer.Grab();
                Console.WriteLine("TestGrabView() passed!");
            }
            catch
            {
                Console.WriteLine("TestGrabView() failed! {0}");
            }
        }

        static void TestCreateCameraFeed()
        {
            
        }


    }
}
