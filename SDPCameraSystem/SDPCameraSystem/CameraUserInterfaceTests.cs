using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class CameraUserInterfaceTests
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, world! These are the tests for" +
        //        "the user input to the camera!");
        // TestFreezeFrame();
        // TestSavePicture();
        //}

        static void TestFreezeFrame()
        {
            try
            {
                CameraUserInterface TestUI = new CameraUserInterface();
                TestUI.FreezeFrame();
                Console.WriteLine("TestFreezeFrame() passed!");
            }
            catch (Exception FreezeFrameException)
            {
                Console.WriteLine("TestFreezeFrame() failed! {0}", FreezeFrameException.Message);
            }
        }

        static void TestSavePicture()
        {

        }
    }
}
