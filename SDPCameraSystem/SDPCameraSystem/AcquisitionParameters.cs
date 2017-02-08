using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using System.IO;

namespace SDPCameraSystem
{
    class AcquisitionParameters
    {
        protected string MyServerName;
        protected int MyResourceIndex = 0;
        protected string MyConfigFileName;
        protected string ConfigFilePath;
        protected string[] ConfigFiles;
        protected int SDPServerNumber = 1;

        public AcquisitionParameters()
        {
            MyServerName = SapManager.GetServerName(SDPServerNumber);
            ConfigFilePath = Environment.GetEnvironmentVariable("SAPERADIR") + "\\CamFiles\\User\\";
            ConfigFiles = Directory.GetFiles(ConfigFilePath, "*.ccf");
            MyConfigFileName = ConfigFiles[0]; 
        }


        public string ConfigFileName
        {
            get { return MyConfigFileName; }
        }

        public string ServerName
        {
            get { return MyServerName; }
        }

        public int ResourceIndex
        {
            get { return MyResourceIndex; }
        }

    }
}

