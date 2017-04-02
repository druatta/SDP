using DALSA.SaperaLT.SapClassBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace SDPCameraSystem
{
    [TestClass]
    public class ConfigurationFileTests
    {
        [TestMethod]
        public void ClassConstructionTest()
        {
            ConfigurationFile TestConstruction = new ConfigurationFile();
            AssignServerNameTest();
            TryToAssign_CCF_FileTest();
        }

        [TestMethod]
        public void AssignServerNameTest()
        {
            ConfigurationFile.AssignServerName();
            AssertServerNameIsFound();
        }

        public void AssertServerNameIsFound()
        {
            Assert.AreNotEqual(SapManager.LastStatusCode, SapStatus.SERVER_NOT_FOUND, 
                SapManager.LastStatusMessage + "\n\n" +
                "Camera is disconnected!" );
        }

        [TestMethod]
        public void Find_CCF_FileTest()
        {
            ConfigurationFile.Find_CCF_File();
            Assert_CCF_FileExists();
        }

        public void Assert_CCF_FileExists()
        {
            int Zero = 0;
            Assert.AreNotEqual(ConfigurationFile.CCF_FileArray.Length, Zero, "\n\n'" +
                ConfigurationFile.FilePath + "' is empty!");
        }

        [TestMethod]
        public void Assign_CCF_FilePathTest()
        {
            ConfigurationFile.Assign_CCF_FilePath();
            Assert_CCF_FilePathExists();
        }

        public void Assert_CCF_FilePathExists()
        {
            Assert.IsTrue(Directory.Exists(ConfigurationFile.FilePath), "\n\n'" +
                ConfigurationFile.FilePath + "' does not exist!");
        }

        [TestMethod]
        public void TryToAssign_CCF_FileTest()
        {
            try
            {
                ConfigurationFile.Assign_CCF_File();
            }
                catch (IndexOutOfRangeException CCF_Assignment_Exception)
            {
                Assert.IsNotNull(ConfigurationFile.Name, "\n\n" +
                    "CCF file not found in '" + ConfigurationFile.FilePath + "'\n\n" +
                    CCF_Assignment_Exception.Message);
            }
            
        }


    }
}
