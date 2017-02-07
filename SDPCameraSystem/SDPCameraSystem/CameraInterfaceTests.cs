﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using System.Diagnostics;
using System.IO;

namespace SDPCameraSystem
{
    class CameraInterfaceTests
    {
        /// <summary>
        /// Test driven development for the CameraObject below. 
        /// </summary>
        /// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the CameraObject tests. ");
        //    Console.WriteLine("These tests can only be run one at a time since we only have one " +
        //        "camera to test them with.");
        //    TestCreateCameraInterface();
        //    //TestCreateAcquisitionDevice();
        //    //TestRefreshFrameRate();
        //    //TestCreateBuffers();
        //    //TestCreateTransfer();
        //    //TestCreateView();
        //    //TestGrabView();


        //    Console.WriteLine("Press any key to terminate.");
        //    Console.ReadKey();


        static void TestCreateCameraInterface()
        {
            try
            {
                CameraInterface TestCameraInterface = new CameraInterface();
                Console.WriteLine("TestCreateCamera() passed!");
            }
            catch (Exception CreateCameraInterfaceException)
            {
                Console.WriteLine("TestCreateCamera() failed! {0}", CreateCameraInterfaceException.Message);
            }
        }

        static void TestCreateAcquisitionDevice()
        {
            try
            {
                CameraInterface TestCameraInterface = new CameraInterface();
                TestCameraInterface.CreateCameraAcquisitionDevice();
                Console.WriteLine("TestCreateAcqusitionDevice() passed!");
            }
            catch (Exception CreateAcquisitionDeviceException)
            {
                Console.WriteLine("TestCreateAcquisitionDevice() failed! {0}", CreateAcquisitionDeviceException.Message);
            }
        }

        static void TestRefreshFrameRate()
        {
            try
            {
                CameraInterface TestCamera = new CameraInterface();
                TestCamera.CreateCameraAcquisitionDevice();
                TestCamera.RefreshFrameRate();
                Console.WriteLine("TestRefreshFrame() passed!");
            }
            catch (Exception RefreshFrameException)
            {
                Console.WriteLine("TestRefreshFrame() failed! {0}", RefreshFrameException.Message);
            }
        }

        static void TestCreateBuffers()
        {
            try
            {
                CameraInterface TestCamera = new CameraInterface();
                TestCamera.CreateCameraAcquisitionDevice();
                TestCamera.RefreshFrameRate();
                TestCamera.CreateBuffers();
                Console.WriteLine("TestCreateBuffers() passed!");
            }
            catch (Exception CreateBufferException)
            {
                Console.WriteLine("TestCreateBuffer() failed! {0}", CreateBufferException.Message);
            }
        }

        static void TestCreateTransfer()
        {
            try
            {
                CameraInterface TestCamera = new CameraInterface();
                TestCamera.CreateCameraAcquisitionDevice();
                TestCamera.RefreshFrameRate();
                TestCamera.CreateBuffers();
                TestCamera.CreateTransfer();
                Console.WriteLine("TestCreateTransfer() passed!");
            }
            catch (Exception CreateTransferException)
            {
                Console.WriteLine("TestCreateTransfer() failed! {0}", CreateTransferException.Message);
            }
        }

        static void TestCreateView()
        {
            try
            {
                CameraInterface TestCamera = new CameraInterface();
                TestCamera.CreateCameraAcquisitionDevice();
                TestCamera.RefreshFrameRate();
                TestCamera.CreateBuffers();
                TestCamera.CreateTransfer();
                TestCamera.CreateView();
                Console.WriteLine("TestCreateView() passed!");
            }
            catch (Exception CreateViewException)
            {
                Console.WriteLine("TestCreateView() failed! {0}", CreateViewException.Message);
            }
        }

        static void TestGrabView()
        {
            try
            {
                CameraInterface TestCamera = new CameraInterface();
                TestCamera.CreateCameraAcquisitionDevice();
                TestCamera.RefreshFrameRate();
                TestCamera.CreateBuffers();
                TestCamera.CreateTransfer();
                TestCamera.CreateView();
                TestCamera.GrabCameraFeed();
                Console.WriteLine("TestGrabView() passed!");
            }
            catch
            {
                Console.WriteLine("TestGrabView() failed! {0}");
            }
        }
    }
}



