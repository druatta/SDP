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

        public FeatureWrapper()
        {
            CreateFeature();
            CheckForSuccessfulFeatureCreationUsingSaperaAPI();
        }

        public void CreateFeature()
        {
            Feature = new SapFeature();
        }

        public void CheckForSuccessfulFeatureCreationUsingSaperaAPI()
        {
            Feature.Create();
        }
    }
}
