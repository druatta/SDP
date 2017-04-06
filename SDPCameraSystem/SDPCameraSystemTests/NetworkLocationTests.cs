using DALSA.SaperaLT.SapClassBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SDPCameraSystem
{
    [TestClass]
    public class NetworkLocationTests
    {
        [TestMethod]
        public void AddConfigurationFileParametersToNetworkLocationTest()
        {
            NetworkLocation.AddConfigurationFileParametersToNetworkLocation();
            Console.WriteLine(SapManager.LastStatusMessage);
            AssertSapManagerDidNotThrowNullServerError();
        }

        public void AssertSapManagerDidNotThrowNullServerError()
        {
            Assert.AreNotEqual(SapManager.LastStatusCode, SapStatus.ARG_NULL, SapManager.LastStatusMessage);
        }






    }
}
