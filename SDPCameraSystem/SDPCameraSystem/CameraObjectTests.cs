using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.Examples.NET.Utils;
using System.Diagnostics;
using System.IO;

namespace SDPCameraSystem
{
    class CameraObjectTests
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World! These are the camera tests.");
            CheckCamValidityUsingSaperaLibraries()

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void TestCreateCamera()
        {
            CameraObject TestCam = new CameraObject();
        }

        static void CheckCamValidityUsingSaperaLibraries()
        {
            Trace.Assert(TestCreateCamUsingSaperaLibraries(), "Create cam using Sapera libraries failed!"); // Should compare to CreateCamera()
        }

        static Boolean TestCreateCamUsingSaperaLibraries()
        {
            // Sapera code from GrabConsole.cs main() below:
            SapAcquisition Acq = null;
            SapAcqDevice AcqDevice = null;
            SapBuffer Buffers = null;
            SapTransfer Xfer = null;
            SapView View = null;
            MyAcquisitionParams acqParams = new MyAcquisitionParams();

            // Sapera code from ExampleUtils.cs GetOptionsFromQuestions() below:
            acqParams.ServerName = SapManager.GetServerName(loc);
            string configPath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
            string[] ccffiles = Directory.GetFiles(configPath, "*.ccf");
            acqParams.ConfigFileName = ccffiles[0];

            // Sapera code from ExampleUtils.cs GetCorAcquisitionOptionsFromQuestions(MyAcquisitionParams acqParams) below:
            acqParams.ResourceIndex = 0; // Could be 1

            // Remaining code from GrabConsole.cs main() below:
            SapLocation loc = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);
            Acq = new SapAcquisition(loc, acqParams.ConfigFileName);
            Acq.EnableEvent(SapAcquisition.AcqEventType.StartOfFrame);
            AcqDevice = new SapAcqDevice(loc, acqParams.ConfigFileName);
            Buffers = new SapBufferWithTrash(1, Acq, SapBuffer.MemoryType.ScatterGather);

            return AcqDevice.Create();


        }

    }
}
