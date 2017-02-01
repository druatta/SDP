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

            Console.WriteLine("Hello, World! These are the camera tests.");
            TestFrameViewCreation();


            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void TestAcquisitionCreation()
        {
            const int MAX_CONFIG_FILES = 36;       // 10 numbers + 26 letters
            SapAcquisition Acq = null;
            SapBuffer Buffers = null;
            SapTransfer Xfer = null;

            Console.WriteLine("Sapera Console Grab Example (C# version)\n");

            MyAcquisitionParams acqParams = new MyAcquisitionParams();

            // Call GetOptions to determine which acquisition device to use and which config
            // file (CCF) should be loaded to configure it.

            // Get total number of boards in the system
            string[] configFileNames = new string[MAX_CONFIG_FILES];
            int serverCount = SapManager.GetServerCount();
            //string configFileIndexToPrint;

            if (serverCount == 0)
            {
                Console.WriteLine("No device found!\n");
            }

            Console.WriteLine("\nSelect the acquisition server (or 'q' to quit)");
            Console.WriteLine("..............................................");

            // Scan the boards to find those that support acquisition
            int serverIndex; // int serverCount = SapManager.GetServerCount();
            bool serverFound = false;
            bool cameraFound = false;
            for (serverIndex = 0; serverIndex < serverCount; serverIndex++)
            {
                if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.Acq) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    serverFound = true;
                }
                else if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    cameraFound = true;
                }
            }

            // At least one acquisition server must be available
            if (!serverFound && !cameraFound)
            {
                Console.WriteLine("No acquisition server found!\n");
            }

            ConsoleKeyInfo info = Console.ReadKey(true);
            char key = info.KeyChar;
            int serverNum = key - '0'; // char-to-int conversion     
            if ((serverNum >= 1) && (serverNum < serverCount))
            {
                acqParams.ServerName = SapManager.GetServerName(serverNum);
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

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
            int deviceNum = key - '0';
            if ((deviceNum >= 1) && (deviceNum <= allDeviceCount))
            {
                acqParams.ResourceIndex = deviceNum - 1;
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

            ////////////////////////////////////////////////////////////

            // List all files in the config directory
            string configPath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
            if (!Directory.Exists(configPath))
            {
                Console.WriteLine("Directory : {0} Does not exist", configPath);
            }
            string[] ccffiles = Directory.GetFiles(configPath, "*.ccf");
            int configFileCount = ccffiles.Length;
            if (configFileCount == 0)
            {
                if (cameraCount == 0)
                {
                    Console.WriteLine("No config file found.\nUse CamExpert to generate a config file before running this example.\n");
                }
                else
                {
                    Console.WriteLine("\nSelect the config file (or 'q' to quit.)");
                    Console.WriteLine("\n........................................\n");
                    Console.WriteLine("1: No config File.\n");
                    configFileCount = 1;
                }
            }
            else
            {

                Console.WriteLine("\nSelect the config file (or 'q' to quit)");
                Console.WriteLine(".......................................\n");
                configFileCount = 0;
                if (deviceCount == 0 && cameraCount != 0)
                {
                    configFileCount = 1;
                    Console.WriteLine("1: No config File.");
                }

                int configFileShow = 0;
                foreach (string ccfFileName in ccffiles)
                {
                    string fileName = ccfFileName.Replace(configPath, "");
                    if (configFileCount < 9)
                    {
                        configFileShow = configFileCount + 1;
                        Console.WriteLine(configFileShow.ToString() + ": " + fileName);
                    }
                    else
                    {
                        configFileShow = configFileCount - 9 + 'a';
                        Console.WriteLine(Convert.ToChar(configFileShow) + ": " + fileName);
                    }
                    configFileNames[configFileCount] = ccfFileName;
                    configFileCount++;
                }

            }

            info = Console.ReadKey(true);
            key = info.KeyChar;
            int configNum = 0;
            // Use numbers 0 to 9, then lowercase letters if there are more than 10 files
            if (key >= '1' && key <= '9')
                configNum = key - '0'; // char-to-int conversion
            else
                configNum = key - 'a' + 10; // char-to-int conversion

            if ((configNum >= 1) && (configNum <= configFileCount))
            {
                acqParams.ConfigFileName = configFileNames[configNum - 1];
            }
            else
            {
                Console.WriteLine("\nInvalid selection!\n");
            }

            Console.WriteLine("\n");

            SapLocation loc = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);

            if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.Acq) > 0)
            {
                Acq = new SapAcquisition(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, Acq, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqToBuf(Acq, Buffers);

                if (!Acq.Create())
                {
                    Console.WriteLine("Error during SapAcqDevice creation!\n");
                }
                else
                {
                    Console.WriteLine("SapAcqDevice created!");
                }
            }
        }

        static void TestAcquistionDeviceCreation()
        {
            SapAcquisition Acq = null;
            SapAcqDevice AcqDevice = null;
            SapBuffer Buffers = null;
            SapTransfer Xfer = null;
            SapView View = null;

            Console.WriteLine("Sapera Console Grab Example (C# version)\n");

            MyAcquisitionParams acqParams = new MyAcquisitionParams();

            // Call GetOptions to determine which acquisition device to use and which config
            // file (CCF) should be loaded to configure it.

            // Get total number of boards in the system
            string[] configFileNames = new string[MAX_CONFIG_FILES];
            int serverCount = SapManager.GetServerCount();
            //string configFileIndexToPrint;

            if (serverCount == 0)
            {
                Console.WriteLine("No device found!\n");
            }

            Console.WriteLine("\nSelect the acquisition server (or 'q' to quit)");
            Console.WriteLine("..............................................");

            // Scan the boards to find those that support acquisition
            int serverIndex; // int serverCount = SapManager.GetServerCount();
            bool serverFound = false;
            bool cameraFound = false;
            for (serverIndex = 0; serverIndex < serverCount; serverIndex++)
            {
                if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.Acq) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    serverFound = true;
                }
                else if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    cameraFound = true;
                }
            }

            // At least one acquisition server must be available
            if (!serverFound && !cameraFound)
            {
                Console.WriteLine("No acquisition server found!\n");
            }

            ConsoleKeyInfo info = Console.ReadKey(true);
            char key = info.KeyChar;
            int serverNum = key - '0'; // char-to-int conversion     
            if ((serverNum >= 1) && (serverNum < serverCount))
            {
                acqParams.ServerName = SapManager.GetServerName(serverNum);
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

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
            int deviceNum = key - '0';
            if ((deviceNum >= 1) && (deviceNum <= allDeviceCount))
            {
                acqParams.ResourceIndex = deviceNum - 1;
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

            ////////////////////////////////////////////////////////////

            // List all files in the config directory
            string configPath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
            if (!Directory.Exists(configPath))
            {
                Console.WriteLine("Directory : {0} Does not exist", configPath);
            }
            string[] ccffiles = Directory.GetFiles(configPath, "*.ccf");
            int configFileCount = ccffiles.Length;
            if (configFileCount == 0)
            {
                if (cameraCount == 0)
                {
                    Console.WriteLine("No config file found.\nUse CamExpert to generate a config file before running this example.\n");
                }
                else
                {
                    Console.WriteLine("\nSelect the config file (or 'q' to quit.)");
                    Console.WriteLine("\n........................................\n");
                    Console.WriteLine("1: No config File.\n");
                    configFileCount = 1;
                }
            }
            else
            {

                Console.WriteLine("\nSelect the config file (or 'q' to quit)");
                Console.WriteLine(".......................................\n");
                configFileCount = 0;
                if (deviceCount == 0 && cameraCount != 0)
                {
                    configFileCount = 1;
                    Console.WriteLine("1: No config File.");
                }

                int configFileShow = 0;
                foreach (string ccfFileName in ccffiles)
                {
                    string fileName = ccfFileName.Replace(configPath, "");
                    if (configFileCount < 9)
                    {
                        configFileShow = configFileCount + 1;
                        Console.WriteLine(configFileShow.ToString() + ": " + fileName);
                    }
                    else
                    {
                        configFileShow = configFileCount - 9 + 'a';
                        Console.WriteLine(Convert.ToChar(configFileShow) + ": " + fileName);
                    }
                    configFileNames[configFileCount] = ccfFileName;
                    configFileCount++;
                }

            }

            info = Console.ReadKey(true);
            key = info.KeyChar;
            int configNum = 0;
            // Use numbers 0 to 9, then lowercase letters if there are more than 10 files
            if (key >= '1' && key <= '9')
                configNum = key - '0'; // char-to-int conversion
            else
                configNum = key - 'a' + 10; // char-to-int conversion

            if ((configNum >= 1) && (configNum <= configFileCount))
            {
                acqParams.ConfigFileName = configFileNames[configNum - 1];
            }
            else
            {
                Console.WriteLine("\nInvalid selection!\n");
            }

            Console.WriteLine("\n");

            SapLocation loc = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);

            if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.Acq) > 0)
            {
                Acq = new SapAcquisition(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, Acq, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqToBuf(Acq, Buffers);

                // Create acquisition object
                if (!Acq.Create())
                {
                    Console.WriteLine("Error during SapAcquisition creation!\n");
                }
                Acq.EnableEvent(SapAcquisition.AcqEventType.StartOfFrame);

            }

            else if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.AcqDevice) > 0)
            {
                AcqDevice = new SapAcqDevice(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, AcqDevice, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqDeviceToBuf(AcqDevice, Buffers);

                // Create acquisition object
                if (!AcqDevice.Create())
                {
                    Console.WriteLine("Error during SapAcqDevice creation!\n");
                }
                else
                {
                    Console.WriteLine("SapAcqDevice created!");
                }
            }

        }

        static void TestBufferCreation()
        {
            SapAcquisition Acq = null;
            SapAcqDevice AcqDevice = null;
            SapBuffer Buffers = null;
            SapTransfer Xfer = null;
            SapView View = null;

            Console.WriteLine("Sapera Console Grab Example (C# version)\n");

            MyAcquisitionParams acqParams = new MyAcquisitionParams();

            // Call GetOptions to determine which acquisition device to use and which config
            // file (CCF) should be loaded to configure it.

            // Get total number of boards in the system
            string[] configFileNames = new string[MAX_CONFIG_FILES];
            int serverCount = SapManager.GetServerCount();
            //string configFileIndexToPrint;

            if (serverCount == 0)
            {
                Console.WriteLine("No device found!\n");
            }

            Console.WriteLine("\nSelect the acquisition server (or 'q' to quit)");
            Console.WriteLine("..............................................");

            // Scan the boards to find those that support acquisition
            int serverIndex; // int serverCount = SapManager.GetServerCount();
            bool serverFound = false;
            bool cameraFound = false;
            for (serverIndex = 0; serverIndex < serverCount; serverIndex++)
            {
                if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.Acq) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    serverFound = true;
                }
                else if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    cameraFound = true;
                }
            }

            // At least one acquisition server must be available
            if (!serverFound && !cameraFound)
            {
                Console.WriteLine("No acquisition server found!\n");
            }

            ConsoleKeyInfo info = Console.ReadKey(true);
            char key = info.KeyChar;
            int serverNum = key - '0'; // char-to-int conversion     
            if ((serverNum >= 1) && (serverNum < serverCount))
            {
                acqParams.ServerName = SapManager.GetServerName(serverNum);
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

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
            int deviceNum = key - '0';
            if ((deviceNum >= 1) && (deviceNum <= allDeviceCount))
            {
                acqParams.ResourceIndex = deviceNum - 1;
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

            ////////////////////////////////////////////////////////////

            // List all files in the config directory
            string configPath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
            if (!Directory.Exists(configPath))
            {
                Console.WriteLine("Directory : {0} Does not exist", configPath);
            }
            string[] ccffiles = Directory.GetFiles(configPath, "*.ccf");
            int configFileCount = ccffiles.Length;
            if (configFileCount == 0)
            {
                if (cameraCount == 0)
                {
                    Console.WriteLine("No config file found.\nUse CamExpert to generate a config file before running this example.\n");
                }
                else
                {
                    Console.WriteLine("\nSelect the config file (or 'q' to quit.)");
                    Console.WriteLine("\n........................................\n");
                    Console.WriteLine("1: No config File.\n");
                    configFileCount = 1;
                }
            }
            else
            {

                Console.WriteLine("\nSelect the config file (or 'q' to quit)");
                Console.WriteLine(".......................................\n");
                configFileCount = 0;
                if (deviceCount == 0 && cameraCount != 0)
                {
                    configFileCount = 1;
                    Console.WriteLine("1: No config File.");
                }

                int configFileShow = 0;
                foreach (string ccfFileName in ccffiles)
                {
                    string fileName = ccfFileName.Replace(configPath, "");
                    if (configFileCount < 9)
                    {
                        configFileShow = configFileCount + 1;
                        Console.WriteLine(configFileShow.ToString() + ": " + fileName);
                    }
                    else
                    {
                        configFileShow = configFileCount - 9 + 'a';
                        Console.WriteLine(Convert.ToChar(configFileShow) + ": " + fileName);
                    }
                    configFileNames[configFileCount] = ccfFileName;
                    configFileCount++;
                }

            }

            info = Console.ReadKey(true);
            key = info.KeyChar;
            int configNum = 0;
            // Use numbers 0 to 9, then lowercase letters if there are more than 10 files
            if (key >= '1' && key <= '9')
                configNum = key - '0'; // char-to-int conversion
            else
                configNum = key - 'a' + 10; // char-to-int conversion

            if ((configNum >= 1) && (configNum <= configFileCount))
            {
                acqParams.ConfigFileName = configFileNames[configNum - 1];
            }
            else
            {
                Console.WriteLine("\nInvalid selection!\n");
            }

            Console.WriteLine("\n");

            SapLocation loc = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);

            if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.Acq) > 0)
            {
                Acq = new SapAcquisition(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, Acq, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqToBuf(Acq, Buffers);

                // Create acquisition object
                if (!Acq.Create())
                {
                    Console.WriteLine("Error during SapAcquisition creation!\n");
                    return;
                }
                Acq.EnableEvent(SapAcquisition.AcqEventType.StartOfFrame);

            }

            else if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.AcqDevice) > 0)
            {
                AcqDevice = new SapAcqDevice(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, AcqDevice, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqDeviceToBuf(AcqDevice, Buffers);

                // Create acquisition object
                if (!AcqDevice.Create())
                {
                    Console.WriteLine("Error during SapAcqDevice creation!\n");
                    return;
                }
            }

            View = new SapView(Buffers);

            // End of frame event
            Xfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;


            Xfer.XferNotify += new SapXferNotifyHandler(xfer_XferNotify);
            Xfer.XferNotifyContext = View;

            // Create buffer object
            if (!Buffers.Create())
            {
                Console.WriteLine("Error during SapBuffer creation!\n");
                return;
            }
            else
            {
                Console.WriteLine("Buffer created!");
            }
        }

        static void TestTransferCreation()
        {
            SapAcquisition Acq = null;
            SapAcqDevice AcqDevice = null;
            SapBuffer Buffers = null;
            SapTransfer Xfer = null;
            SapView View = null;

            Console.WriteLine("Sapera Console Grab Example (C# version)\n");

            MyAcquisitionParams acqParams = new MyAcquisitionParams();

            // Call GetOptions to determine which acquisition device to use and which config
            // file (CCF) should be loaded to configure it.

            // Get total number of boards in the system
            string[] configFileNames = new string[MAX_CONFIG_FILES];
            int serverCount = SapManager.GetServerCount();
            //string configFileIndexToPrint;

            if (serverCount == 0)
            {
                Console.WriteLine("No device found!\n");
            }

            Console.WriteLine("\nSelect the acquisition server (or 'q' to quit)");
            Console.WriteLine("..............................................");

            // Scan the boards to find those that support acquisition
            int serverIndex; // int serverCount = SapManager.GetServerCount();
            bool serverFound = false;
            bool cameraFound = false;
            for (serverIndex = 0; serverIndex < serverCount; serverIndex++)
            {
                if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.Acq) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    serverFound = true;
                }
                else if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    cameraFound = true;
                }
            }

            // At least one acquisition server must be available
            if (!serverFound && !cameraFound)
            {
                Console.WriteLine("No acquisition server found!\n");
            }

            ConsoleKeyInfo info = Console.ReadKey(true);
            char key = info.KeyChar;
            int serverNum = key - '0'; // char-to-int conversion     
            if ((serverNum >= 1) && (serverNum < serverCount))
            {
                acqParams.ServerName = SapManager.GetServerName(serverNum);
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

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
            int deviceNum = key - '0';
            if ((deviceNum >= 1) && (deviceNum <= allDeviceCount))
            {
                acqParams.ResourceIndex = deviceNum - 1;
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

            ////////////////////////////////////////////////////////////

            // List all files in the config directory
            string configPath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
            if (!Directory.Exists(configPath))
            {
                Console.WriteLine("Directory : {0} Does not exist", configPath);
            }
            string[] ccffiles = Directory.GetFiles(configPath, "*.ccf");
            int configFileCount = ccffiles.Length;
            if (configFileCount == 0)
            {
                if (cameraCount == 0)
                {
                    Console.WriteLine("No config file found.\nUse CamExpert to generate a config file before running this example.\n");
                }
                else
                {
                    Console.WriteLine("\nSelect the config file (or 'q' to quit.)");
                    Console.WriteLine("\n........................................\n");
                    Console.WriteLine("1: No config File.\n");
                    configFileCount = 1;
                }
            }
            else
            {

                Console.WriteLine("\nSelect the config file (or 'q' to quit)");
                Console.WriteLine(".......................................\n");
                configFileCount = 0;
                if (deviceCount == 0 && cameraCount != 0)
                {
                    configFileCount = 1;
                    Console.WriteLine("1: No config File.");
                }

                int configFileShow = 0;
                foreach (string ccfFileName in ccffiles)
                {
                    string fileName = ccfFileName.Replace(configPath, "");
                    if (configFileCount < 9)
                    {
                        configFileShow = configFileCount + 1;
                        Console.WriteLine(configFileShow.ToString() + ": " + fileName);
                    }
                    else
                    {
                        configFileShow = configFileCount - 9 + 'a';
                        Console.WriteLine(Convert.ToChar(configFileShow) + ": " + fileName);
                    }
                    configFileNames[configFileCount] = ccfFileName;
                    configFileCount++;
                }

            }

            info = Console.ReadKey(true);
            key = info.KeyChar;
            int configNum = 0;
            // Use numbers 0 to 9, then lowercase letters if there are more than 10 files
            if (key >= '1' && key <= '9')
                configNum = key - '0'; // char-to-int conversion
            else
                configNum = key - 'a' + 10; // char-to-int conversion

            if ((configNum >= 1) && (configNum <= configFileCount))
            {
                acqParams.ConfigFileName = configFileNames[configNum - 1];
            }
            else
            {
                Console.WriteLine("\nInvalid selection!\n");
            }

            Console.WriteLine("\n");

            SapLocation loc = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);

            if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.Acq) > 0)
            {
                Acq = new SapAcquisition(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, Acq, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqToBuf(Acq, Buffers);

                // Create acquisition object
                if (!Acq.Create())
                {
                    Console.WriteLine("Error during SapAcquisition creation!\n");
                    return;
                }
                Acq.EnableEvent(SapAcquisition.AcqEventType.StartOfFrame);

            }

            else if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.AcqDevice) > 0)
            {
                AcqDevice = new SapAcqDevice(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, AcqDevice, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqDeviceToBuf(AcqDevice, Buffers);

                // Create acquisition object
                if (!AcqDevice.Create())
                {
                    Console.WriteLine("Error during SapAcqDevice creation!\n");
                    return;
                }
            }

            View = new SapView(Buffers);

            // End of frame event
            Xfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;


            Xfer.XferNotify += new SapXferNotifyHandler(xfer_XferNotify);
            Xfer.XferNotifyContext = View;

            if (!Buffers.Create())
            {
                Console.WriteLine("Error during SapBuffer creation!\n");
                return;
            }

            if (!Xfer.Create())
            {
                Console.WriteLine("Error during SapTransfer creation!\n");
                return;
            }
            else
            {
                Console.WriteLine("Transfer created!");
            }
        }

        static void TestFrameViewCreation()
        {
            SapAcquisition Acq = null;
            SapAcqDevice AcqDevice = null;
            SapBuffer Buffers = null;
            SapTransfer Xfer = null;
            SapView View = null;

            Console.WriteLine("Sapera Console Grab Example (C# version)\n");

            MyAcquisitionParams acqParams = new MyAcquisitionParams();

            // Call GetOptions to determine which acquisition device to use and which config
            // file (CCF) should be loaded to configure it.

            // Get total number of boards in the system
            string[] configFileNames = new string[MAX_CONFIG_FILES];
            int serverCount = SapManager.GetServerCount();
            //string configFileIndexToPrint;

            if (serverCount == 0)
            {
                Console.WriteLine("No device found!\n");
            }

            Console.WriteLine("\nSelect the acquisition server (or 'q' to quit)");
            Console.WriteLine("..............................................");

            // Scan the boards to find those that support acquisition
            int serverIndex; // int serverCount = SapManager.GetServerCount();
            bool serverFound = false;
            bool cameraFound = false;
            for (serverIndex = 0; serverIndex < serverCount; serverIndex++)
            {
                if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.Acq) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    serverFound = true;
                }
                else if (SapManager.GetResourceCount(serverIndex, SapManager.ResourceType.AcqDevice) != 0)
                {
                    string serverName = SapManager.GetServerName(serverIndex);
                    Console.WriteLine(serverIndex.ToString() + ": " + serverName);
                    cameraFound = true;
                }
            }

            // At least one acquisition server must be available
            if (!serverFound && !cameraFound)
            {
                Console.WriteLine("No acquisition server found!\n");
            }

            ConsoleKeyInfo info = Console.ReadKey(true);
            char key = info.KeyChar;
            int serverNum = key - '0'; // char-to-int conversion     
            if ((serverNum >= 1) && (serverNum < serverCount))
            {
                acqParams.ServerName = SapManager.GetServerName(serverNum);
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

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
            int deviceNum = key - '0';
            if ((deviceNum >= 1) && (deviceNum <= allDeviceCount))
            {
                acqParams.ResourceIndex = deviceNum - 1;
            }
            else
            {
                Console.WriteLine("Invalid selection!\n");
            }

            ////////////////////////////////////////////////////////////

            // List all files in the config directory
            string configPath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
            if (!Directory.Exists(configPath))
            {
                Console.WriteLine("Directory : {0} Does not exist", configPath);
            }
            string[] ccffiles = Directory.GetFiles(configPath, "*.ccf");
            int configFileCount = ccffiles.Length;
            if (configFileCount == 0)
            {
                if (cameraCount == 0)
                {
                    Console.WriteLine("No config file found.\nUse CamExpert to generate a config file before running this example.\n");
                }
                else
                {
                    Console.WriteLine("\nSelect the config file (or 'q' to quit.)");
                    Console.WriteLine("\n........................................\n");
                    Console.WriteLine("1: No config File.\n");
                    configFileCount = 1;
                }
            }
            else
            {

                Console.WriteLine("Config file is at index 1 (listed as 2)");
                Console.WriteLine(".......................................\n");
                configFileCount = 0;
                if (deviceCount == 0 && cameraCount != 0)
                {
                    configFileCount = 1;
                    Console.WriteLine("1: No config File.");
                }

                int configFileShow = 0;
                foreach (string ccfFileName in ccffiles)
                {
                    string fileName = ccfFileName.Replace(configPath, "");
                    if (configFileCount < 9)
                    {
                        configFileShow = configFileCount + 1;
                        Console.WriteLine(configFileShow.ToString() + ": " + fileName);
                    }
                    else
                    {
                        configFileShow = configFileCount - 9 + 'a';
                        Console.WriteLine(Convert.ToChar(configFileShow) + ": " + fileName);
                    }
                    configFileNames[configFileCount] = ccfFileName;
                    configFileCount++;
                }

            }

            int configNum = 1; 
            acqParams.ConfigFileName = configFileNames[configNum];

            SapLocation loc = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);

            if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.Acq) > 0)
            {
                Acq = new SapAcquisition(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, Acq, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqToBuf(Acq, Buffers);

                // Create acquisition object
                if (!Acq.Create())
                {
                    Console.WriteLine("Error during SapAcquisition creation!\n");
                    return;
                }
                Acq.EnableEvent(SapAcquisition.AcqEventType.StartOfFrame);

            }

            else if (SapManager.GetResourceCount(acqParams.ServerName, SapManager.ResourceType.AcqDevice) > 0)
            {
                AcqDevice = new SapAcqDevice(loc, acqParams.ConfigFileName);
                Buffers = new SapBufferWithTrash(2, AcqDevice, SapBuffer.MemoryType.ScatterGather);
                Xfer = new SapAcqDeviceToBuf(AcqDevice, Buffers);

                // Create acquisition object
                if (!AcqDevice.Create())
                {
                    Console.WriteLine("Error during SapAcqDevice creation!\n");
                    return;
                }
            }

            View = new SapView(Buffers);

            // End of frame event
            Xfer.Pairs[0].EventType = SapXferPair.XferEventType.EndOfFrame;
            Xfer.XferNotify += new SapXferNotifyHandler(xfer_XferNotify);
            Xfer.XferNotifyContext = View;

            // Create buffer object
            if (!Buffers.Create())
            {
                Console.WriteLine("Error during SapBuffer creation!\n");
                return;
            }

            // Create buffer object
            if (!Xfer.Create())
            {
                Console.WriteLine("Error during SapTransfer creation!\n");
                return;
            }

            // Create buffer object
            if (!View.Create())
            {
                Console.WriteLine("Error during SapView creation!\n");
                return;
            }

            Xfer.Grab();
            Console.WriteLine("\n\nGrab started, press a key to freeze");
            Console.ReadKey(true);
            Xfer.Freeze();
            Xfer.Wait(1000);
        }

        static float lastFrameRate = 0.0f;
        public static void xfer_XferNotify(object sender, SapXferNotifyEventArgs args)
        {

            // refresh view
            SapView View = args.Context as SapView;
            View.Show();

            // refresh frame rate
            SapTransfer transfer = sender as SapTransfer;
            if (transfer.UpdateFrameRateStatistics())
            {
                SapXferFrameRateInfo stats = transfer.FrameRateStatistics;
                float framerate = 0.0f;

                if (stats.IsLiveFrameRateAvailable)
                    framerate = stats.LiveFrameRate;

                // check if frame rate is stalled
                if (stats.IsLiveFrameRateStalled)
                {
                    Console.WriteLine("Live Frame rate is stalled.");
                }

                // update FPS only if the value changed by +/- 0.1
                else if ((framerate > 0.0f) && (Math.Abs(lastFrameRate - framerate) > 0.1f))
                {
                    Console.WriteLine("Grabbing at {0} frames/sec", framerate);
                    lastFrameRate = framerate;
                }
            }
        }

    }


}


