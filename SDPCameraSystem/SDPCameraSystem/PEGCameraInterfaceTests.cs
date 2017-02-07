using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class PEGCameraInterfaceTests
    {

        //static void Main(string[] args)
        //{
        //    TestTurnTriggerModeOn();
            
            
        //    //CheckForTriggerEventTest();
        //}

        static void TestTurnTriggerModeOn()
        {
            try
            {
                TriggerCameraInterface TestVideoFeedInterface = new VideoFeed();
                TestVideoFeedInterface.TurnTriggerModeOn();
                Console.WriteLine("TestTurnTriggerModeOn() passed!");
            }
            catch (Exception TurnTriggerModeOnException)
            {
                Console.WriteLine("TestTurnTriggerModeOn() failed! {0}", TurnTriggerModeOnException.Message);
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
