using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DALSA.SaperaLT.SapClassBasic;
using System.IO;

namespace SDPCameraSystem
{
    class SaperaLibraryTests
    {
        /// <summary>
        /// Uncomment this Main() to run the Sapera library tests
        /// </summary>
        //static void Main(string[] args)
        //{


        //    TestViewCreation();

        //    Console.WriteLine("Press any key to terminate.");
        //    Console.ReadKey();
        //}


        static void TestViewCreation()
        {
            SapAcqDevice AcqDevice = null;
            SapBuffer Buffers = null;
            SapTransfer Xfer = null;
            SapView View = null;

            AcquisitionParameters acqParams = new AcquisitionParameters();

            SapLocation loc = new SapLocation(acqParams.ServerName, acqParams.ResourceIndex);

            AcqDevice = new SapAcqDevice(loc, acqParams.ConfigFileName);
            Buffers = new SapBufferWithTrash(2, AcqDevice, SapBuffer.MemoryType.ScatterGather);
            Xfer = new SapAcqDeviceToBuf(AcqDevice, Buffers);

            AcqDevice.Create();
        
            View = new SapView(Buffers);

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


