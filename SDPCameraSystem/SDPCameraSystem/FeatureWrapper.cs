using DALSA.SaperaLT.SapClassBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class FeatureWrapper
    {
        public SapFeature Feature;

        public FeatureWrapper(LocationWrapper LocationWrapper)
        {
            CreateFeature(LocationWrapper);
            CheckForSuccessfulFeatureCreationUsingSaperaAPI();
        }

        public void CreateFeature(LocationWrapper LocationWrapper)
        {
            Feature = new SapFeature(LocationWrapper.Location);
        }

        public void CheckForSuccessfulFeatureCreationUsingSaperaAPI()
        {
            Feature.Create();
        }
    }
}
