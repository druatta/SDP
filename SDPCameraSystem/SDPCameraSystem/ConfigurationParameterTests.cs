﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPCameraSystem
{
    class ConfigurationParameterTests
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World! These are the AcquisitonParameter tests.");
        //    CreateAcquisitionParametersTest();

        //    Console.WriteLine("Press any key to terminate.");
        //    Console.ReadKey();
        //}

        static void CreateAcquisitionParametersTest()
        {
            TryToCreateAcquisitionParameters();
        }

        static void TryToCreateAcquisitionParameters()
        {
            try
            {
                ConfigurationParameters TestParameters = new ConfigurationParameters();
                Console.WriteLine("CreateAcquisitionParameters() passed!");
            }
            catch (Exception CreateAcquisitionParametersException)
            {
                Console.WriteLine("CreateAcquisitionParameters() failed! {0}", 
                    CreateAcquisitionParametersException.Message);
            }
        }




    }
}