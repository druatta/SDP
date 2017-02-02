using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;

namespace SDPCameraSystem
{
    class AcquisitionParameters
    {
        protected string MyServerName;
        protected int MyResourceIndex;
        protected string MyConfigFileName;
        protected int SDPServerNumber = 1;

        public AcquisitionParameters()
        {
            MyServerName = SapManager.GetServerName(SDPServerNumber);
            MyResourceIndex = 0;
            MyConfigFileName = "";
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

