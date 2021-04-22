using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using ToolTest.dao;

namespace ToolTest
{
    class GmailLoginService

    {
      
        public Google_login googlelogin = new Google_login();
        public Vpn vpn = new Vpn();
        public void checkInternet(String deviceID)
        {
            while (true)
            {
                String status = MessageDAO.getStatus(deviceID);

                if (status.Equals("true"))
                {
                    
                    Environment.Exit(0);
                }
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }


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
            Thread thread = new Thread(() =>
                checkInternet(deviceID)
            );
            thread.Start();

            Console.WriteLine("Action: Wait");
            Console.WriteLine("Progress: " + process);

            vpn.configVpn(deviceID, noxID);


            String result1 = googlelogin.chooseBigolive(deviceID, noxID);
            if (result1.Equals("Open Gmail Success"))
            {
                process = 10;
                print("Open Gmail", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {

                print("Open Line", process, result1);
                googlelogin.Exit(deviceID);
                Environment.Exit(0);
            }


            result1 = googlelogin.BigoReg(deviceID, firstname, lastname, username, password, phone, simId, day, month, year);
            if(result1.Equals("Reg Success"))
            {
                print("Success : ", 100, "");
            }
            else
            {
                print("AuthMethod", process, result1);
                Environment.Exit(0);
            }

            googlelogin.Exit(deviceID);
            Console.WriteLine("Success: Reg");
            Environment.Exit(0);
        }
    }
}
