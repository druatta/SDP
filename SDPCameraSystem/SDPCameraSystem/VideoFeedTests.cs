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
            //TestCreateVideoFeed();
            TestFreezeFrame();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void TestCreateVideoFeed()
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

        static void TestFreezeFrame()
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

        static void TestSavePicture()
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
