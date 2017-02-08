using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class TriggerParameterTests
    {

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, world! These are the camera trigger tests!");

        //    TestTurnTriggerModeOn();
        //    //CheckForTriggerEventTest();
        //}

        static void TestTurnTriggerModeOn()
        {
            try
            {
                VideoFeed TestCam = new VideoFeed();
                
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
