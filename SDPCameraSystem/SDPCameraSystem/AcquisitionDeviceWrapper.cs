﻿using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class AcquisitionDeviceWrapper
    {
        public SapAcqDevice Device;
        ConfigurationParameters DeviceParameters = new ConfigurationParameters();
        CameraLocationWrapper LocationWrapper = new CameraLocationWrapper();

        public AcquisitionDeviceWrapper()
        {
            CreateNewAcquisitionDevice();
        }

        public void CreateNewAcquisitionDevice()
        {
            Device = new SapAcqDevice(LocationWrapper.Location, DeviceParameters.ConfigFileName);
        }
    }
}
