﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    class CameraComposition
    {
        public ConfigurationFile ConfigurationFile;
        public NetworkLocation NetworkLocation;
        public EventHandler EventHandler;
        public CameraObject CameraObject;
        public ImageBuffers ImageBuffers;
        public ViewingWindow ViewingWindow;
        public DataTransfer DataTransfer;
        
        public CameraComposition()
        {
            CreateCamera(); 
        }

        public void CreateCamera()
        {
            CreateConfigurationFile();
            CreateNetworkLocation();
            CreateEventHandler();
            CreateCameraObject();
            CreateImageBuffers();
            CreateViewingWindow();
            CreateDataTransfer();
        }

        public void CreateConfigurationFile()
        {
            ConfigurationFile = new ConfigurationFile();
        }

        public void CreateNetworkLocation()
        {
            NetworkLocation = new NetworkLocation(ConfigurationFile);
        }

        public void CreateEventHandler()
        {
            EventHandler = new EventHandler(NetworkLocation);
        }

        public void CreateCameraObject()
        {
            CameraObject = new CameraObject(ConfigurationFile, NetworkLocation, EventHandler);
        }

        public void CreateImageBuffers()
        {
            ImageBuffers = new ImageBuffers(CameraObject);
        }

        public void CreateViewingWindow()
        {
            ViewingWindow = new ViewingWindow(ImageBuffers);
        }

        public void CreateDataTransfer()
        {
            DataTransfer = new DataTransfer(CameraObject, ImageBuffers, ViewingWindow);
        }

        public void SaveImageOnTriggerInputForever()
        {
            while (true)
            {
                SaveImageOnTriggerInput();
                Console.WriteLine("Image saved!");
            }
        }

        public void SaveImageOnTriggerInput()
        {
            if (CameraObject.CheckForChangeInTriggerInput(EventHandler) == true) {
                ImageBuffers.SaveBufferToFile();
            }
        }

    }

}
