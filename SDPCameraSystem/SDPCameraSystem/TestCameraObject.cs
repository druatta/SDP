using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALSA.SaperaLT.SapClassBasic;
using System.Diagnostics;

namespace SDPCameraSystem
{
    class TestCameraObject
    {
        /* All test driven development is done in main(). Every unit test returns a boolean and has
         * the word Test in front of it. It is then tested using Trace.Assert() and will output an 
         * error message if the assertion (and therefore the unit test) fails, giving us immediate info
         * on which unit test failed.
         */ 
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Camera object's unit tests!");
            Trace.Assert(TestCreateCamera(), "Failed to create camera!"); 


            while(true);
        }

        static Boolean TestCreateCamera()
        {
            try
            {
                CameraObject Cam = new CameraObject();
                return true;
            }
            catch (SapLibraryException exception)
            {
                throw exception;
            }
        } 
       
        
       
    }
}
