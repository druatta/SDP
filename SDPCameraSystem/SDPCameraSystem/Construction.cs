using System;

namespace SDPCameraSystem
{
    public class Construction
    {
        public Server Server;
        public Node CameraObject;
        public ImageBuffers ImageBuffers;
        public ViewingWindow ViewingWindow;
        public DataTransfer DataTransfer;

        public Construction()
        {
            CreateCamera();
        }

        public void CreateCamera()
        {
            CreateConfigurationFile();
            CreateCameraObject();
            CreateImageBuffers();
            CreateViewingWindow();
            CreateDataTransfer();
        }

        public void CreateConfigurationFile()
        {
            Server = new Server();
        }


        public void CreateCameraObject()
        {
            CameraObject = new Node(Server);
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
            if (CameraObject.CheckForChangeInTriggerInput() == true)
            {
                ImageBuffers.SaveBufferToFile();
            }
        }

    }

}
