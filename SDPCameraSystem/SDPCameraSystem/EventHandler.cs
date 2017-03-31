using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    public class EventHandler
    {
        public SapFeature Feature;

        public EventHandler(NetworkLocation LocationWrapper)
        {
            CreateFeature(LocationWrapper);
            CheckForSuccessfulFeatureCreationUsingSaperaAPI();
        }

        public void CreateFeature(NetworkLocation LocationWrapper)
        {
            Feature = new SapFeature(LocationWrapper.Location);
        }

        public void CheckForSuccessfulFeatureCreationUsingSaperaAPI()
        {
            Feature.Create();
        }
    }
}
