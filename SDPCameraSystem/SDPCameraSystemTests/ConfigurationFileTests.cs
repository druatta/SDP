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
        public void ConstructConfigurationFileTest()
        {
            Lazy<ConfigurationFile> LazyConfigurationFile = new Lazy<ConfigurationFile>();
            AssertServerNameIsFound();
            Assert_CCF_FileExists();
        }
 
        [TestMethod]
        public void AssignServerNameTest()
        {
            ConfigurationFile.AssignServerName();
            AssertServerNameIsFound();
        }
        
        public void AssertServerNameIsFound()
        {
            string CameraIsDisconnectedMessage = "\n\nCamera is disconnected!";
            Assert.AreNotEqual(SapManager.LastStatusCode, SapStatus.SERVER_NOT_FOUND, 
                SapManager.LastStatusMessage + CameraIsDisconnectedMessage);
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
            string ConfigurationFilePathIsEmptyMessage = "\n\n'" + ConfigurationFile.FilePath + "' is empty!";
            Assert.AreNotEqual(ConfigurationFile.CCF_FileArray.Length, Zero, ConfigurationFilePathIsEmptyMessage);
        }

        [TestMethod]
        public void Assign_CCF_FilePathTest()
        {
            ConfigurationFile.Assign_CCF_FilePath();
            Assert_CCF_FilePathExists();
        }

        public void Assert_CCF_FilePathExists()
        {
            string CCF_FilePathDoesNotExistMessage = "\n\n'" + ConfigurationFile.FilePath + "' does not exist!";
            Assert.IsTrue(Directory.Exists(ConfigurationFile.FilePath), CCF_FilePathDoesNotExistMessage);
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
                string CCF_FileNotFoundMessage = "\n\n" + "CCF file not found in '" + ConfigurationFile.FilePath + "'\n\n";
                Assert.IsNotNull(ConfigurationFile.Name, CCF_FileNotFoundMessage + CCF_Assignment_Exception.Message);
            }
            
        }


    }
}
