using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ToolTest.dao;
using System.Drawing;
namespace ToolTest
{
    class GmailRegService
    {
        Bitmap CREATEACCOUNT = (Bitmap) Bitmap.FromFile("C://data//gmailReg//createaccount.png");
        public GmailReg lineReg = new GmailReg();
        public Vpn vpn = new Vpn();
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
        public void run3(String deviceID, String firstname, String lastname, String username, String password, String phone, String simId, String noxID,String day,String month,String year)
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


            String result1 = lineReg.chooseBigolive(deviceID, noxID);
            if (result1.Equals("Open Gmail Success"))
            {
                process = 10;
                print("Open Gmail", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {

                print("Open Line", process, result1);
                lineReg.Exit(deviceID);
                Environment.Exit(0);
            }

           
            result1 = lineReg.BigoReg(deviceID, firstname, lastname, username, password, phone, simId, day, month, year);
            if (result1.Equals("Dont have Auth code"))
            {
                print("Auth Method", process, result1);
                lineReg.Exit(deviceID);
                Environment.Exit(0);
            }

            else if (result1.Equals("Reg Success"))
            {
                print("Success : ", 100, "");
                lineReg.Exit(deviceID);
              
            }
            else if(result1.Equals("Already Have Account"))
            {
                print("Auth Method", process, result1);
                lineReg.Exit(deviceID);
            }


            lineReg.Exit(deviceID);
            Console.WriteLine("Success: Reg");
            Environment.Exit(0);
        }
    }
}
