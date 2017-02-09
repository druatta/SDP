﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class LocationWrapperTests
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the CameraLocationWrapper tests. ");
        //    CreateTestLocationWrapper();


        //    Console.WriteLine("Press any key to terminate.");
        //    Console.ReadKey();
        //}

        static void CreateTestLocationWrapper()
        {
            TryToCreateNewLocationWrapper();
        }

        static void TryToCreateNewLocationWrapper()
        {
            try
            {
                LocationWrapper TestLocationWrapper = new LocationWrapper();
                Console.WriteLine("New LocationWrapper() created!");
            }
            catch (Exception CreateNewLocationWrapperException)
            {
                Console.WriteLine("Failed to create new LocationWrapper()! {0}",
                    CreateNewLocationWrapperException.Message);
            }
        }
    }
}
