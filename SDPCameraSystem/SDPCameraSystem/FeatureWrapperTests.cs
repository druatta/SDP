﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class FeatureWrapperTests
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the AcquisitionWrapper tests. ");
                // CreateTestFeature();


        //    Console.WriteLine("Press any key to terminate.");
        //    Console.ReadKey();
        //}

        static void CreateTestFeature()
        {
            TryToCreateTestFeature();
        }

        static void TryToCreateTestFeature()
        {
            try
            {
                TBD
                Console.WriteLine("Successfully created a TestFeature!");
            }
            catch (Exception CreateFeatureException)
            {
                Console.WriteLine("Failed to create a Feature! {0}",
                    CreateFeatureException.Message);
            }
        }

    }
}
