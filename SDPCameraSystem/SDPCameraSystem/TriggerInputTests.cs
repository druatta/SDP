using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class TriggerInputTests : TriggerInput
    {

        static void Main(string[] args)
        {
            SendSoftwareTriggerFromVisualStudioTest();
            //SendSoftwareTriggerFromPEGTest();
            //CheckForTriggerEventTest();
        }

        static void SendSoftwareTriggerFromVisualStudioTest()
        {
            try
            {
                VideoFeed TestVideoFeed = new VideoFeed();
                Console.WriteLine("Waiting 10 seconds before sending the software trigger");
                TestVideoFeed.PauseVideoFeedForSeconds(10);
                // TestVideoFeed.SendSoftwareTriggerFromVisualStudio();
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
                //TestVideoFeed.SendSoftwareTriggerFromPEG();
                Console.WriteLine("SendSoftwareTriggerFromPEGTest passed!");
            }
            catch (Exception SendSoftwareTriggerFromPEGException)
            {
                Console.WriteLine("SendSoftwareTriggerFromPEGTest() failed!", SendSoftwareTriggerFromPEGException.Message);
            }
        }

        static void CheckForTriggerEventTest()
        {
            try
            {
                VideoFeed TestVideoFeed = new VideoFeed();
               // TestVideoFeed.CheckForTriggerEvent();
                Console.WriteLine("TestCheckForTriggerEvent() passed!");
            }
            catch (Exception CheckForTriggerEventException)
            {
                Console.WriteLine("TestCheckForTriggerEvent() failed! {0}", CheckForTriggerEventException.Message);
            }
        }
    }
}
