using DALSA.SaperaLT.SapClassBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace SDPCameraSystem
{
    [TestClass]
    public class ServerTests
    {
        [TestMethod]
        public void ServerExistsTest()
        {
            Server.AssignSDPServerName();
            Assert.AreNotEqual(SapManager.LastStatusCode, SapStatus.SERVER_NOT_FOUND, SapManager.LastStatusMessage);
        }

        [TestMethod]
        public void ConfigurationFileDirectoryIsNotEmptyTest()
        {
            Server.FindConfigurationFileDirectory();
            int Zero = 0;
            Assert.AreNotEqual(Server.CCF_FileArray.Length, Zero);
        }

        [TestMethod]
        public void AssignConfigurationFilePathTest()
        {
            Server.Assign_CCF_FilePath();
            Assert_CCF_FilePathExists();
        }

        public void Assert_CCF_FilePathExists()
        {
            Assert.IsTrue(Directory.Exists(Server.FilePath));
        }

        [TestMethod]
        public void TryToAssign_CCF_FileToServerTest()
        {
            try
            {
                Server.Assign_CCF_File();
            }
            catch (IndexOutOfRangeException CCF_Assignment_Exception)
            {
                string CCF_FileNotFoundMessage = "\n\n" + "CCF file not found in '" + Server.FilePath + "'\n\n";
                Assert.IsNotNull(Server.Name, CCF_FileNotFoundMessage + CCF_Assignment_Exception.Message);
            }

        }










    }
}
