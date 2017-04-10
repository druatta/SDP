using System;

namespace SDPCameraSystem
{
    public class CameraComposition
    {
        
        public Server UCSCServer = new Server();
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
            CreateEventHandler();
            CreateCameraObject();
            CreateImageBuffers();
            CreateViewingWindow();
            CreateDataTransfer();
        }



        public void CreateEventHandler()
        {
            EventHandler = new EventHandler();
        }

        public void CreateCameraObject()
        {
            CameraObject = new CameraObject(UCSCServer, EventHandler);
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
            if (CameraObject.CheckForChangeInTriggerInput(EventHandler) == true)
            {
                ImageBuffers.SaveBufferToFile();
            }
        }

    }

}
