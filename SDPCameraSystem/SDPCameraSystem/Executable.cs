using System;

namespace SDPCameraSystem
{
    class Executable
    {
        public static void Main(string[] args)
        {
            //CameraComposition SDPCamera = new CameraComposition();

            ConfigurationFile.Assign_CCF_FilePath();
            Console.WriteLine(ConfigurationFile.FilePath);

            if (ConfigurationFile.FilePath == null)
            {
                Console.WriteLine("File path exists.");
            }
            else
            {
                Console.WriteLine("File path does not exist.");
            }

            while (true)
            {

            }
        }
    }
}
