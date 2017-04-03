using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class CameraObjectTests
    {
        [TestMethod]
        public void TryToCreateAnAcquisitionCameraObjectTest()
        {

        }

        [TestMethod]
        public void TryToCreateCameraObjectNotificationInterfaceTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CameraObject.CreateCameraObjectNotificationInterface();
            }
            catch (Exception CreateCameraObjectCallbackException)
            {
                Assert.Fail(CreateCameraObjectCallbackException.Message);
            }
        }

        [TestMethod]
        public void TryToEnableChangesInFeatureValuesTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                TestCameraFeed.CameraObject.EnableChangesInFeatureValues();
            }
            catch (Exception EnableChangesInFeatureValuesException)
            {
                Assert.Fail(EnableChangesInFeatureValuesException.Message);
            }
        }

        const int OneThousandMilliseconds = 1;
        [TestMethod, Timeout(OneThousandMilliseconds)]
        public void TryToWaitForATriggerInputTest()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();
                while (true)
                {
                    TestCameraFeed.CameraObject.CheckForChangeInTriggerInput(TestCameraFeed.EventHandler);
                }
            }
            catch (Exception GetTriggerException)
            {
                Assert.Fail(GetTriggerException.Message);
            }
        }
    }
}
