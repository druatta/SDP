using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class AcquisitionParameterTests
    {
        // Unit Tests in Main()
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! These are the AcquisitonParameter tests.");
            CreateAcquisitionParametersTest();

            Console.WriteLine("Press any key to terminate.");
            Console.ReadKey();
        }

        static void CreateAcquisitionParametersTest()
        {
            TryToCreateAcquisitionParameters();
        }

        static void TryToCreateAcquisitionParameters()
        {
            try
            {
                AcquisitionParameters TestParameters = new AcquisitionParameters();
                Console.WriteLine("CreateAcquisitionParameters() passed!");
            }
            catch (Exception CreateAcquisitionParametersException)
            {
                Console.WriteLine("CreateAcquisitionParameters() failed! {0}", CreateAcquisitionParametersException.Message);
            }
        }




    }
}
