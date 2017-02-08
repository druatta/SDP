using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class DataTransferTests
    {
        //// Uncomment to run the DataTransferTests
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the DataTransfer tests. ");
        //    CreateDataTransferTest();

        //    Console.WriteLine("Press any key to terminate this test.");
        //    Console.ReadKey();
        //}

        static void CreateDataTransferTest()
        {
            TryToCreateADataTransfer();
        }

        static void TryToCreateADataTransfer()
        {
            try
            {
                DataTransfer TestDataTransfer = new DataTransfer();
            }
            catch (Exception CreateDataTransferException)
            {
                Console.WriteLine("Failed to create a data transfer! {0}", CreateDataTransferException.Message);
            }
        }


    }
}
