using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SDPCameraSystem
{
    [TestClass]
    public class CameraCompositionTests
    {
        [TestMethod]
        public void ComposeCameraTest()
        {
            Server TestServer = new Server();
        }

        [TestMethod, Timeout(1000)]
        public void TryToCreateCameraFeedThatSavesImagesOnExternalTriggerTest()
        {
            Assert.Fail("Test is incomplete.");
        }
    }
}



