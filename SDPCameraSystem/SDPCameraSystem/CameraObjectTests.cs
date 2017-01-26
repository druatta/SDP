using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using System.Diagnostics;

namespace SDPCameraSystem
{
    class CameraObjectTests
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World! These are the camera tests.");
            CreateTestCamera();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void CreateTestCamera()
        {
            CameraObject TestCam = new CameraObject();
            Trace.Assert(TestCam.Create(), "TestCreateCamera() failed!");
        }

    }
}
