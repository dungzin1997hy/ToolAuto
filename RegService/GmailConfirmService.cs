using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class GmailConfirmService
    {
        Bitmap CREATEACCOUNT = (Bitmap)Bitmap.FromFile("C://data//gmailReg//createaccount.png");
        public GmailConfirm gmailConfirm = new GmailConfirm();
        Vpn vpn = new Vpn();
        public void checkInternet(String deviceID)
        {
            int dem = 120;
            while (true)
            {
                if(dem == 0)
                {
                    Console.WriteLine("Error : OverTime");
                    Environment.Exit(0);
                }
                String status = MessageDAO.getStatus(deviceID);
               
                if (status.Equals("true"))
                {
                    Environment.Exit(0);
                }
                dem--;
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
        }
        public void checkRestart(String deviceID)
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                if (Services.findImage(deviceID, CREATEACCOUNT) == true)
                {
                    Console.WriteLine("Error : openapp");
                    Environment.Exit(0);
                }
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
            vpn.configVpn(deviceID, noxID);
            Console.WriteLine("Action: Wait");
            Console.WriteLine("Progress: " + process);

            String result1 = gmailConfirm.chooseBigolive(deviceID, noxID,username,password);
            if (result1.Equals("Open Gmail Success"))
            {
                process = 10;
                print("Open Gmail", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {

                print("Open Line", process, result1);
                gmailConfirm.Exit(deviceID);
                Environment.Exit(0);
            }


            Thread thread1 = new Thread(() =>
               checkRestart(deviceID)
            );
            thread1.Start();

            result1 = gmailConfirm.BigoReg(deviceID, firstname, lastname, username, password, phone, simId, day, month, year);
            if (result1.Equals("Dont have Auth code"))
            {
                print("Auth Method", process, result1);
                gmailConfirm.Exit(deviceID);
                Environment.Exit(0);
            }
           
            else if (result1.Equals("Reg Success"))
            {
                print("Success : ", 100, "");
            }
            else if (result1.Equals("Already Have Account"))
            {
                print("Auth Method", process, result1);
                Environment.Exit(0);
            }
            else if (result1.Equals("Error Phone"))
            {
                print("Auth Method", process, result1);
                Environment.Exit(0);
            }

            gmailConfirm.Exit(deviceID);
            Console.WriteLine("Success: Reg");
            Environment.Exit(0);
        }
    }
}
