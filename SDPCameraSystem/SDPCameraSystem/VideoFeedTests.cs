using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class VideoFeedTests
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world! These are the Video Feed Tests!");
            //VideoFeedTest();
            FreezeFrameTest();
            //SendSoftwareTriggerFromVisualStudioTest();
            //SendSoftwareTriggerFromPEGTest();
            //CheckForTriggerEventTest();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void VideoFeedTest()
        {
            try
            {
                VideoFeed TestVideoFeed = new VideoFeed();
                Console.WriteLine("TestCreateVideoFeed() passed!");
            }
            catch (Exception CreateVideoFeedException)
            {
                Console.WriteLine("TestCreateVideoFeed() failed! {0}", CreateVideoFeedException.Message);
            }
        }

        static void SendSoftwareTriggerFromVisualStudioTest()
        {
            try
            {
                VideoFeed TestVideoFeed = new VideoFeed();
                Console.WriteLine("Waiting 10 seconds before sending the software trigger");
                TestVideoFeed.PauseVideoTransferForSeconds(10);
                TestVideoFeed.SendSoftwareTriggerFromVisualStudio();
                Console.WriteLine("SendSoftwareTriggerFromVisualStudioTest() passed!");
            }
            catch (Exception SendSoftwareTriggerFromVisualStudioException)
            {
                Console.WriteLine("SendSoftwareTriggerFromVisualStudioTest() failed! {0}", SendSoftwareTriggerFromVisualStudioException.Message);
            }
        }

        static void SendSoftwareTriggerFromPEGTest()
        {
            try
            {
                VideoFeed TestVideoFeed = new VideoFeed();
                TestVideoFeed.SendSoftwareTriggerFromPEG();
                Console.WriteLine("SendSoftwareTriggerFromPEGTest passed!");
            } catch (Exception SendSoftwareTriggerFromPEGException)
            {
                Console.WriteLine("SendSoftwareTriggerFromPEGTest() failed!", SendSoftwareTriggerFromPEGException.Message);
            }
        }

        static void CheckForTriggerEventTest()
        {
            try
            {
                VideoFeed TestVideoFeed = new VideoFeed();
                TestVideoFeed.CheckForTriggerEvent();
                Console.WriteLine("TestCheckForTriggerEvent() passed!");
            }
            catch (Exception CheckForTriggerEventException)
            {
                Console.WriteLine("TestCheckForTriggerEvent() failed! {0}", CheckForTriggerEventException.Message);
            }
        }

        static void FreezeFrameTest()
        {
            try
            {
                VideoFeed TestVideoFeed = new VideoFeed();
                TestVideoFeed.FreezeFrame();
                Console.WriteLine("TestFreezeFrame() passed!");
            }
            catch (Exception FreezeFrameException)
            {
                Console.WriteLine("TestFreezeFrame() failed! {0}", FreezeFrameException.Message);
            }
        }

        static void SavePictureTest()
        {
            try
            {
                VideoFeed TestVideoFeed = new VideoFeed();
                TestVideoFeed.SavePicture();
            }
            catch (Exception SavePictureException)
            {
                Console.WriteLine("SavePicture() failed! {0}", SavePictureException.Message);
            }
        }


    }
}
