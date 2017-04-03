using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class EventHandlerTests
    {

        [TestMethod]
         public void TryToCreateEventHandlerTest()
        {
            try
            {
                ConfigurationFile TestConfigurationFile = new ConfigurationFile();
                NetworkLocation TestNetworkLocation = new NetworkLocation();
                EventHandler TestEventHandler = new EventHandler();
            }
            catch (Exception CreateEventHandlerException)
            {
                Assert.Fail(CreateEventHandlerException.Message);
            }
        }

    }
}
