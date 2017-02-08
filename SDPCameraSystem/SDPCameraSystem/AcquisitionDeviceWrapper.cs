using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class AcquisitionDeviceWrapper
    {
        public SapAcqDevice Device = null;
        ConfigurationParameters DeviceParameters = new ConfigurationParameters();
        CameraLocationWrapper LocationWrapper = new CameraLocationWrapper();

        public AcquisitionDeviceWrapper()
        {
            Device = new SapAcqDevice(LocationWrapper.Location, DeviceParameters.ConfigFileName);
        }
    }
}
