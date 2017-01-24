using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.Examples.NET.Utils;

namespace KateevaSDPCameraSystem
{
    class CameraTests
    {
        // All TDD in main
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World! These are the camera tests.");
            SapAcqDevice TestCamera = CameraObject.CreateCamera();



            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

    }
}
