using System;

namespace SDPCameraSystem
{
    class Executable
    {
        public static void Main(string[] args)
        {
           // CameraComposition SDPCamera = new CameraComposition();

            ConfigurationFile TestConfigurationFile = new ConfigurationFile();
            NetworkLocation NetworkLocation = new NetworkLocation(TestConfigurationFile);


            Console.WriteLine("Testing completed.");
            while (true)
            {

            }
        }
    }
}
