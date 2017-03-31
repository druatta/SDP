using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class ConfigurationFileTests
    {
        [TestMethod]
        public void CreateAcquisitionParametersTest()
        {
            TryToCreateAcquisitionParameters();
        }

        public void TryToCreateAcquisitionParameters()
        {
            try
            {
                ConfigurationFile TestParameters = new ConfigurationFile();
                Console.WriteLine("CreateAcquisitionParameters() passed!");
            }
            catch (Exception CreateAcquisitionParametersException)
            {
                Console.WriteLine("CreateAcquisitionParameters() failed! {0}", 
                    CreateAcquisitionParametersException.Message);
            }
        }

    }
}
