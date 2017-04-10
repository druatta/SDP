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
        public void AssignServerNameTest()
        {
            Server.AssignServerName();
            AssertServerNameIsFound();
        }
        
        public void AssertServerNameIsFound()
        {
            AssertSapManagerDidNotThrowServerNotFoundError();
        }

        public void AssertSapManagerDidNotThrowServerNotFoundError()
        {
            Assert.AreNotEqual(SapManager.LastStatusCode, SapStatus.SERVER_NOT_FOUND, SapManager.LastStatusMessage);
        }

        [TestMethod]
        public void Find_CCF_FileTest()
        {
            Server.Find_CCF_File();
            Assert_CCF_FileExists();
        }

        public void Assert_CCF_FileExists()
        {
            int Zero = 0;
            string ConfigurationFilePathIsEmptyMessage = "\n\n'" + Server.FilePath + "' is empty!";
            Assert.AreNotEqual(Server.CCF_FileArray.Length, Zero, ConfigurationFilePathIsEmptyMessage);
        }

        [TestMethod]
        public void Assign_CCF_FilePathTest()
        {
            Server.Assign_CCF_FilePath();
            Assert_CCF_FilePathExists();
        }

        public void Assert_CCF_FilePathExists()
        {
            string CCF_FilePathDoesNotExistMessage = "\n\n'" + Server.FilePath + "' does not exist!";
            Assert.IsTrue(Directory.Exists(Server.FilePath), CCF_FilePathDoesNotExistMessage);
        }

        [TestMethod]
        public void TryToAssign_CCF_FileTest()
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
