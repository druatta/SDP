﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class BufferWrapperTests
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! These are the BufferWrapper tests. ");
            //CreateTestBufferWrappers();
            TestCreateBufferSaveParameters();
            //PrintBufferSaveParameters();
            //TestSaveCurrentBufferToFile();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void CreateTestBufferWrappers()
        {
            TryToCreateBufferWrappers();
        }

        static void TryToCreateBufferWrappers()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                LocationWrapper TestLocationWrapper = new LocationWrapper(TestConfigurationFile);
                FeatureWrapper TestFeatureWrapper = new FeatureWrapper(TestLocationWrapper);
                AcquisitionDeviceWrapper TestDeviceWrapper = new AcquisitionDeviceWrapper(TestConfigurationFile, TestLocationWrapper, TestFeatureWrapper);
                BufferWrappers TestBufferWrappers = new BufferWrappers(TestDeviceWrapper);
                Console.WriteLine("Successfully created the BufferWrappers()!");
            }
            catch (Exception CreateBufferWrapperException)
            {
                Console.WriteLine("Failed to create a BufferWrapper()! {0}",
                    CreateBufferWrapperException.Message);
            }
        }

        static void TestCreateBufferSaveParameters()
        {
            TryToCreateBufferSaveParameters();
        }

        static void TryToCreateBufferSaveParameters()
        {
            try
            {
                CameraFeed TestFeed = new CameraFeed();
                TestFeed.BufferWrappers.CreateBufferSaveParameters(); // Is currently in the Buffer Wrapper constructor!
                Console.WriteLine("Successfully created the Buffer Save Parameters!");
            }
            catch (Exception CreateBufferSaveParametersException)
            {
                Console.WriteLine("Failed to create Buffer Save Parameters! {0}",
                    CreateBufferSaveParametersException.Message);
            }
        }

        static void PrintBufferSaveParameters()
        {
            TryToPrintBufferSaveParameters();
        }

        static void TryToPrintBufferSaveParameters()
        {
            try
            {
                CameraFeed TestCameraFeed = new CameraFeed();
                TestCameraFeed.BufferWrappers.PrintBufferSaveParameters();
            }
            catch (Exception PrintBufferSaveParametersException)
            {
                Console.WriteLine("Failed to print out the Buffer Save Parameters! {0}",
                    PrintBufferSaveParametersException.Message);
            }
        }

        static void TestSaveCurrentBufferToFile()
        {
            TryToSaveCurrentBufferToFile();
        }

        static void TryToSaveCurrentBufferToFile()
        {
            try
            {
                CameraFeed TestCameraFeed = new CameraFeed();
                TestCameraFeed.BufferWrappers.SaveBufferToFile();
                Console.WriteLine("Successfully saved the current buffer to file!");
            }
            catch (Exception SaveCurrentBufferToFileException)
            {
                Console.WriteLine("Failed to save current buffer to file! {0}",
                    SaveCurrentBufferToFileException.Message);
            }
        }


    }
}
