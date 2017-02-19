using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class EventHandler
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
