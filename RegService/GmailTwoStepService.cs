using System;
using System.Collections.Generic;
using System.Text;
using ToolTest.dao;
using System.Threading;

namespace ToolTest
{
    class GmailTwoStepService
    {
        GmailTwoStep gmail = new GmailTwoStep();
        Vpn vpn = new Vpn();

        public void checkInternet(String deviceID)
        {
            int dem = 120;
            while (true)
            {
                String status = MessageDAO.getStatus(deviceID);
                if (dem == 0)
                {
                    Console.WriteLine("Error : OverTime");
                    Environment.Exit(0);
                }
                if (status.Equals("true"))
                {
                    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear jp.naver.line.android ");
                    Environment.Exit(0);
                }
                dem--;
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
            vpn.configVpn(deviceID, noxID);

            Thread thread = new Thread(() =>
               checkInternet(deviceID)
           );
            thread.Start();
            Console.WriteLine("Action: Wait");
            Console.WriteLine("Progress: " + process);
            
            String result1 = gmail.chooseBigolive(deviceID, noxID,password);
            if (result1.Equals("Open Gmail Success"))
            {
                process = 10;
                print("Open Gmail", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {

                print("Open Line", process, result1);
                gmail.Exit(deviceID);
                Environment.Exit(0);
            }


            

            result1 = gmail.gmailstep(deviceID, firstname, lastname, username, password, phone, simId, day, month, year);
            if(result1.Equals("Reg Success"))
            {
                print("TwoStep", process, "");
            }
            else
            {
                print("TwoStep", process, result1);
                gmail.Exit(deviceID);
                Environment.Exit(0);
            }

            gmail.Exit(deviceID);
            Console.WriteLine("Success: Reg");
            Environment.Exit(0);
        }
    }
}
