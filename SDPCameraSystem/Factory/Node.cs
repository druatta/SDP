using DALSA.SaperaLT.SapClassBasic;
using System;

namespace SDPCameraSystem
{
    public class Node
    {
        public static SapFeature Feature;
        public static void CreateEventHandler()
        {
            Server CameraServer = new Server();
            Feature = new SapFeature(Server.Location);
        }

        public static void CheckForSuccessfulEventHandlerCreation()
        {
            Feature.Create();
        }

        public Node(Server CameraServer)
        {
            CreateNewAcquisitionDevice();
            CheckForSuccessfulAcquisitionDeviceCreation();
            CreateCameraObjectNotificationInterface();
        }

        public static SapAcqDevice Device;
        public static void CreateNewAcquisitionDevice()
        {
            Device = new SapAcqDevice(Server.Location, Server.Name);
        }

        public static void CheckForSuccessfulAcquisitionDeviceCreation()
        {
            Device.Create();
        }

        public static void CreateAcquisitionDeviceCallback(object DataSender, SapAcqDeviceNotifyEventArgs EventArguments)
        {
            Device = DataSender as SapAcqDevice;
        }

        public static void CreateCameraObjectNotificationInterface()
        {
            Device.AcqDeviceNotify += new SapAcqDeviceNotifyHandler(CreateAcquisitionDeviceCallback);
        }


    }
}
