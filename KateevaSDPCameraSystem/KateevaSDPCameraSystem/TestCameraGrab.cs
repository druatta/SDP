using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.Examples.NET.Utils;


namespace KateevaSDPCameraSystem
{
    class TestCameraGrab
    {
        // All TDD in main
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            CreateTestCamera();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
            DestroyCamera(TestCamera);
        }

        static void CreateTestCamera()
        {
            MyAcquisitionParams TestParams = new MyAcquisitionParams();
            SapLocation TestLocation = new SapLocation(TestParams.ServerName, TestParams.ResourceIndex);
            SapAcqDevice TestCamera = new SapAcqDevice(TestLocation, TestParams.ConfigFileName);

        }

        static void DestroyCamera(SapAcqDevice TestCamera, SapFeature TestFeature)
        {
            TestCamera.Destroy();
            TestCamera.Dispose();
            TestFeature.Destroy();
            TestCamera.Dispose();
        }

    }
}
