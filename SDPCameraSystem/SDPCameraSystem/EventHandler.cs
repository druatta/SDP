using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class EventHandler
    {
        public SapFeature Feature;

        public EventHandler()
        {
            NetworkLocation NetworkLocation = new NetworkLocation();
            CreateEventHandler();
            CheckForSuccessfulEventHandlerCreation();
        }

        public void CreateEventHandler()
        {
            Feature = new SapFeature(NetworkLocation.Location);
        }

        public void CheckForSuccessfulEventHandlerCreation()
        {
            Feature.Create();
        }
    }
}
