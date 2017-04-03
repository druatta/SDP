using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDPCameraSystem
{
    [TestClass]
    public class ImageBufferTests
    {
        [TestMethod]
        public void TryToCreateImageBufferTest()
        {

        }

        [TestMethod]
        public void TryToCreateBufferSaveParametersTest()
        {
            try
            {
                CameraComposition TestCamera = new CameraComposition();
                TestCamera.ImageBuffers.CreateBufferSaveParameters(); 
            }
            catch (Exception CreateBufferSaveParametersException)
            {
                Assert.Fail(CreateBufferSaveParametersException.Message);
            }
        }

        [TestMethod]
        public void TryToPrintBufferSaveParametersTest()
        {
            try
            {
                CameraComposition TestCamera = new CameraComposition();
                TestCamera.ImageBuffers.PrintBufferSaveParameters();
            }
            catch (Exception PrintBufferSaveParametersException)
            {
                Assert.Fail(PrintBufferSaveParametersException.Message);
            }
        }

        [TestMethod]
        public void TryToSaveCurrentBufferToFileTest()
        {
            try
            {
                CameraComposition TestCamera = new CameraComposition();
                TestCamera.ImageBuffers.SaveBufferToFile();
            }
            catch (Exception SaveCurrentBufferToFileException)
            {
                Assert.Fail(SaveCurrentBufferToFileException.Message);
            }
        }


    }
}
