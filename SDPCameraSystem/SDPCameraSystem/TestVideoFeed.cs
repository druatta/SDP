﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class TestVideoFeed
    {
        static void Main(string[] args)
        {
            TestCreateVideoFeed();
        }

        static void TestCreateVideoFeed()
        {
            try
            {
                VideoFeed TestVideoFeed = new VideoFeed();
            }
            catch (Exception CreateVideoFeedException)
            {
                Console.WriteLine("TestCreateVideoFeed() failed! {0}", CreateVideoFeedException.Message);
            }
        }

        static void TestFreezeFrame()
        {

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
