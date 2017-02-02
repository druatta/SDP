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


            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }



        static void TestCreateCamera()
        {
            try
            {
                Camera TestCamera = new Camera();
            }
            catch (Exception e)
            {
                Console.WriteLine("TestCreateCamera() failed!");
            }
            finally
            {
                Console.WriteLine("TestCreateCamera() passed!");
            }

        }
    }
}
