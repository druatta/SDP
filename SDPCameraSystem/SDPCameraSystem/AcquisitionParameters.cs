using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class AcquisitionParameters
    {
        public AcquisitionParameters()
        {
            MyServerName = "";
            MyResourceIndex = 0;
            MyConfigFileName = "";
        }

        public string ConfigFileName
        {
            get { return MyConfigFileName; }
            set { MyConfigFileName = value; }
        }

        public string ServerName
        {
            get { return MyServerName; }
            set { MyServerName = value; }
        }

        public int ResourceIndex
        {
            get { return MyResourceIndex; }
            set { MyResourceIndex = value; }
        }

        protected string MyServerName;
        protected int MyResourceIndex;
        protected string MyConfigFileName;
    }
}

