using DALSA.SaperaLT.SapClassBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace SDPCameraSystem
{
    [TestClass]
    public class NetworkLocationTests
    {
        [TestMethod]
        [ExpectedException(typeof(AccessViolationException))]
        public void AddConfigurationFileParametersToNetworkLocationTest()
        {
            NetworkLocation.AddConfigurationFileParametersToNetworkLocation();
        }








    }
}
