using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class EventHandlerTests
    {

        [TestMethod]
        public void CreateTestFeature()
        {
            TryToCreateTestFeature();
        }

        public void TryToCreateTestFeature()
        {
            try
            {
                CameraComposition TestCameraFeed = new CameraComposition();

                Console.WriteLine("Successfully created a TestFeature!");
            }
            catch (Exception CreateFeatureException)
            {
                Console.WriteLine("Failed to create a Feature! {0}",
                    CreateFeatureException.Message);
            }
        }

    }
}
