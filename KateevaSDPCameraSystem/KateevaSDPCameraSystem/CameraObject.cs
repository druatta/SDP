using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using DALSA.SaperaLT.Examples.NET.Utils;

namespace KateevaSDPCameraSystem
{
    class CameraObject
    {
        public static SapAcqDevice CreateCamera()
        {
            try
            {
                MyAcquisitionParams CamParams = new MyAcquisitionParams();
                SapLocation CamLocation = new SapLocation(CamParams.ServerName, CamParams.ResourceIndex);
                SapAcqDevice Camera = new SapAcqDevice(CamLocation, CamParams.ConfigFileName);
                return Camera;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to create Camera: \t {0}", e);
                return null;
            }
        }

        public static void DestroyCamera()
        {
            try
            {

            }
            catch (Exception e)
            {

            }
            finally
            {
                Console.WriteLine("Camera destroyed.");
            }
        }
    }
}
