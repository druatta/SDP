using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class TestSaveImage
    {
        static void TestFreezeFrame()
        {
            try
            {
                Camera TestCamera = new Camera();
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
