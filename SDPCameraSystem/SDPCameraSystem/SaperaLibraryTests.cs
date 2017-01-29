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

            Console.WriteLine("Sapera Console Grab Example (C# version)\n");

            MyAcquisitionParams acqParams = new MyAcquisitionParams();

            // Call GetOptions to determine which acquisition device to use and which config
            // file (CCF) should be loaded to configure it.
            if (!GetOptions(args, acqParams))
            {
                // Do nothing
            }

            SapLocation loc = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);

            if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.Acq) > 0)
            {
                Acq = new SapAcquisition(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, Acq, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqToBuf(Acq, Buffers);
                Acq.EnableEvent(SapAcquisition.AcqEventType.StartOfFrame);
            }

            else if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.AcqDevice) > 0)
            {
                AcqDevice = new SapAcqDevice(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, AcqDevice, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqDeviceToBuf(AcqDevice, Buffers);
            }

        }


        static bool GetOptions(string[] args, MyAcquisitionParams acqParams)
        {

            // Get total number of boards in the system
            string[] configFileNames = new string[MAX_CONFIG_FILES];
            int serverCount = SapManager.GetServerCount();

            Console.WriteLine("\nSelect the acquisition server (or 'q' to quit)");
            Console.WriteLine("Type 1: ");

            // Scan the boards to find those that support acquisition
            int serverNum = ScanBoardsToFindThoseThatSupportAcquistion();
            Console.WriteLine("Server Number is: {0}", serverNum);

            acqParams.ServerName = SapManager.GetServerName(serverNum);


            // Scan all the acquisition devices on that server and show menu to user
            int deviceCount = SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.Acq);
            int cameraCount = SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.AcqDevice);
            int allDeviceCount = deviceCount + cameraCount;

            Console.WriteLine("\nSelect the acquisition device (or 'q' to quit)");
            Console.WriteLine("..............................................\n");

            for (int deviceIndex = 0; deviceIndex < deviceCount; deviceIndex++)
            {
                string deviceName = SapManager.GetResourceName(acqParams.ServerName, SapManager.ResourceType.Acq, deviceIndex);
                Console.WriteLine(((int)(deviceIndex + 1)).ToString() + ": " + deviceName);
            }

            if (deviceCount == 0)
            {
                for (int cameraIndex = 0; cameraIndex < cameraCount; cameraIndex++)
                {
                    string cameraName = SapManager.GetResourceName(acqParams.ServerName, SapManager.ResourceType.AcqDevice, cameraIndex);
                    Console.WriteLine(((int)(cameraIndex + 1)).ToString() + ": " + cameraName);
                }
            }

            info = Console.ReadKey(true);
            key = info.KeyChar;
            if (key == 'q')
                return false;
            int deviceNum = key - '0';
            acqParams.ResourceIndex = deviceNum - 1;



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

            Console.WriteLine("\nPress any key to terminate\n");
            Console.ReadKey(true);

            return true; // Should be ExampleUtils.GetOptionsFromQuestions(acqParams); 
        }

        int ScanBoardsToFindThoseThatSupportAcquistion()
        {
            int serverCount = SapManager.GetServerCount();
            int serverIndex; // int serverCount = SapManager.GetServerCount();
            for (serverIndex = 0; serverIndex < serverCount; serverIndex++)
            {
                if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.Acq) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);

                }
                else if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);

                }
            }
            
        }



    }


}


