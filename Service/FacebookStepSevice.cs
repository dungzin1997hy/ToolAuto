using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ToolTest
{

    class FacebookStepSevice
    {
        FacebookTwoStep facebookstep = new FacebookTwoStep();
        public void print(String action, int process, String error)
        {
            Console.WriteLine("Action: " + action);
            Console.WriteLine("Progress: " + process);
            Console.WriteLine(error);
            if (error.Equals("") == false)
            {
                Console.WriteLine("Error: " + error);
            }
        }
        public void run3(String deviceID, String firstname, String lastname, String username, String password, String phone, String simId, String noxID, String day, String month, String year)
        {
            String status = "";
            String error = "none";
            bool isHasInternet = true;
            int process = 0;

            Console.WriteLine("Action: Wait");
            Console.WriteLine("Progress: " + process);


            String result1 = facebookstep.chooseFacebook(deviceID, noxID);
            if (result1.Equals("Open Facebook Success"))
            {
                process = 10;
                print("Open Facebook", process, "");

            }
            else
            {
                print("Open Facebook", process, result1);
                facebookstep.Exit(deviceID);
                Environment.Exit(0);
            }


            result1 = facebookstep.facebookstep(deviceID, password, phone, simId);
            if (result1.Equals("Dont have Auth code"))
            {
                print("Auth Method", process, result1);
                facebookstep.Exit(deviceID);
                Environment.Exit(0);
            }

            else
            {
                print("Auth Method", process, result1);
                Environment.Exit(0);
            }



            facebookstep.Exit(deviceID);
            Console.WriteLine("Success: Reg");
            Environment.Exit(0);
        }
    }
}
