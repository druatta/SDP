using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class EventHandler
    {
        public SapFeature Feature;

        public EventHandler(NetworkLocation NetworkLocation)
        {
            CreateEventHandler(NetworkLocation);
            CheckForSuccessfulEventHandlerCreation();
        }

        public void CreateEventHandler(NetworkLocation NetworkLocation)
        {
            Feature = new SapFeature(NetworkLocation.Location);
        }

        public void CheckForSuccessfulEventHandlerCreation()
        {
            Feature.Create();
        }
    }
}
