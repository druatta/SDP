using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class TriggerParameterTests
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world! These are the camera trigger tests!");
      
            //SetTriggerSelectorToFrameTriggerTest(TestFeed);
            //TurnTriggerModeOnTest(TestFeed);

            Console.WriteLine("Press any key to terminate this test.");
            Console.ReadKey();
        }

        static void SetTriggerSelectorToFrameTriggerTest(VideoFeed TestVideoFeed)
        {
            TryToSetTheTriggerSelectorToFrameTrigger(TestVideoFeed);
        }

        static void TryToSetTheTriggerSelectorToFrameTrigger(VideoFeed TestVideoFeed)
        {
            try
            {
                //SetTheTriggerSelectorToFrameTrigger(TestVideoFeed);
                Console.WriteLine("Successfully set the TriggerSelector to Frame Trigger!");
            }
            catch (Exception SetTriggerSelectorToFrameTriggerException)
            {
                Console.WriteLine("Failed to set the TriggerSelector to FrameTrigger! {0}", 
                    SetTriggerSelectorToFrameTriggerException.Message);
            }
        }

        //static void TurnTriggerModeOnTest(VideoFeed TestVideoFeed)
        //{
        //    TryToTurnTriggerModeOn(TestVideoFeed);
        //}

        //static void TryToTurnTriggerModeOn(VideoFeed TestVideoFeed)
        //{
        //    try
        //    {
        //        TurnTriggerModeOn(TestVideoFeed);
        //        Console.WriteLine("TestTurnTriggerModeOn() passed!");
        //    }
        //    catch (Exception TurnTriggerModeOnException)
        //    {
        //        Console.WriteLine("Failed to turn the Trigger Mode On! {0}", 
        //            TurnTriggerModeOnException.Message);
        //    }
        //}

       


    }
}
