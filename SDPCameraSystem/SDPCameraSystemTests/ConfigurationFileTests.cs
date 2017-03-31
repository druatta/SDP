using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class ConfigurationFileTests
    {
        [TestMethod]
        public void TryToCreateAcquisitionParametersTest()
        {
            try
            {
                ConfigurationFile TestParameters = new ConfigurationFile();
            }
            catch (Exception CreateAcquisitionParametersException)
            {
                Assert.Fail(CreateAcquisitionParametersException.Message);
            }
        }

    }
}
