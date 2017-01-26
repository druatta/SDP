using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.Examples.NET.Utils;
using System.Diagnostics;

namespace KateevaSDPCameraSystem
{
    class CameraTests
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World! These are the camera tests.");
            CreateTestCamera();
            DestroyTestCamera();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void CreateTestCamera()
        {
            Camera TestCam = new Camera();
            Trace.Assert(TestCam.Create(), "TestCreateCamera() failed!");
        }

    }
}
