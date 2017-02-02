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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! These are the CameraObject tests.");
            TestCreateCamera();
            TestCreateAcquisitionDevice();


            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void TestCreateCamera()
        {
            try
            {
                Camera TestCamera = new Camera();
            }
            catch (Exception CreateCameraException)
            {
                Console.WriteLine("TestCreateCamera() failed! {0}", CreateCameraException.Message);
            }
            finally
            {
                Console.WriteLine("TestCreateCamera() passed!");
            }
        }

        static void TestCreateAcquisitionDevice()
        {
            try
            {
                Camera TestCamera = new Camera();
                TestCamera.Device.Create();
            }
            catch (Exception CreateAcquisitionDeviceException)
            {
                Console.WriteLine("TestCreateAcquisitionDevice() failed! {0}", CreateAcquisitionDeviceException.Message);
            }
            finally
            {
                Console.WriteLine("TestCreateAcqusitionDevice() passed!");
            }
        }

        static void TestRefreshFrame()
        {
            try
            {
                Camera TestCamera = new Camera();
                TestCamera.RefreshFrame();
            }
            catch (Exception RefreshFrameException)
            {
                Console.WriteLine("TestRefreshFrame() failed! {0}", RefreshFrameException.Message);
            }
            finally
            {
                Console.WriteLine("TestRefreshFrame() passed!");
            }
        }



    }
}
