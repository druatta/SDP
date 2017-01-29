using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.Examples.NET.Utils;
using System.IO;

namespace SDPCameraSystem
{
    class SaperaLibraryTests
    {
        const int GAMMA_FACTOR = 10000;
        const int MAX_CONFIG_FILES = 36;       // 10 numbers + 26 letters

        static void Main(string[] args)
        {
            SapAcquisition Acq = null;
            SapAcqDevice AcqDevice = null;
            SapBuffer Buffers = null;
            SapTransfer Xfer = null;
            SapView View = null;

            Console.WriteLine("Sapera Console Grab Example (C# version)\n");

            MyAcquisitionParams acqParams = new MyAcquisitionParams();

            // Get total number of boards in the system
            string[] configFileNames = new string[MAX_CONFIG_FILES];
            int serverCount = SapManager.GetServerCount();

            Console.WriteLine("\nAcquisition server should be 0");

            // Scan the boards to find those that support acquisition
            int serverNum = 0;
            Console.WriteLine("Server Number is: {0}", serverNum);
            acqParams.ServerName = SapManager.GetServerName(serverNum);

            Console.WriteLine("Acquisition device is 0.");

            acqParams.ResourceIndex = 0;



            ////////////////////////////////////////////////////////////

            // List all files in the config directory
            string configPath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";

            string[] ccffiles = Directory.GetFiles(configPath, "*.ccf");
            int configFileCount = ccffiles.Length;
            if (configFileCount == 0)
            {

                Console.WriteLine("\nSelect the config file (or 'q' to quit.)");
                configFileCount = 1;
            }
            else
            {

                Console.WriteLine("\nSelect the config file (or 'q' to quit)");


                foreach (string ccfFileName in ccffiles)
                {
                    string fileName = ccfFileName.Replace(configPath, "");

                    configFileNames[configFileCount] = ccfFileName;
                }

            }


            Console.WriteLine("ConfigNum is 0");
            acqParams.ConfigFileName = configFileNames[0];

  

            SapLocation loc = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);

            if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.Acq) > 0)
            {
                Acq = new SapAcquisition(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, Acq, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqToBuf(Acq, Buffers);
                Acq.EnableEvent(SapAcquisition.AcqEventType.StartOfFrame);
            }

            if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.AcqDevice) > 0)
            {
                AcqDevice = new SapAcqDevice(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, AcqDevice, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqDeviceToBuf(AcqDevice, Buffers);
            }



            View = new SapView(Buffers);

            // Create buffer object
            if (!Buffers.Create())
            {
                Console.WriteLine("Error during SapBuffer creation!\n");
            }

            // Create buffer object
            if (!Xfer.Create())
            {
                Console.WriteLine("Error during SapTransfer creation!\n");
            }

            // Create buffer object
            if (!View.Create())
            {
                Console.WriteLine("Error during SapView creation!\n");
            }


            Console.WriteLine("\nPress any key to terminate\n");
            Console.ReadKey(true);

        }



    }


}


