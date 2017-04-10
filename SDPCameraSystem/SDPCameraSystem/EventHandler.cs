using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class EventHandler
    {
        public SapFeature Feature;

        public EventHandler()
        {
            CreateEventHandler();
            CheckForSuccessfulEventHandlerCreation();
        }

        public void CreateEventHandler()
        {
            Server CameraServer = new Server();
            Feature = new SapFeature(Server.Location);
        }

        public void CheckForSuccessfulEventHandlerCreation()
        {
            Feature.Create();
        }
    }
}
