using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class LineRegService
    {
        public LineReg lineReg = new LineReg();
        public Vpn vpn = new Vpn();
        public void checkInternet(String deviceID)
        {
                String status = MessageDAO.getStatus(deviceID);
                Console.WriteLine("status : " + status);
                if (status.Equals("true"))
                {
                    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear jp.naver.line.android ");
                    Environment.Exit(0);
                }
            Thread.Sleep(TimeSpan.FromSeconds(5));
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
        public void run3(String deviceID,String firstname,String lastname, String username, String password, String phoneNumber, String simID, String noxID)
        {
            Thread thread = new Thread(() =>
               checkInternet(deviceID)
               );

            thread.Start();
            String status = "";
            String error = "none";
            bool isHasInternet = true;
            int process = 0;
           

            Console.WriteLine("Action: Wait");
            Console.WriteLine("Progress: " + process);

            vpn.configVpn(deviceID, noxID);


            String result1 = lineReg.chooseSkype(deviceID, noxID);
            if (result1.Equals("Open Line Success"))
            {
                process = 10;
                print("Open Line", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {

                print("Open Line", process, result1);
                lineReg.Exit(deviceID);
                Environment.Exit(0);
            }


            result1 = lineReg.login(deviceID, username, password, noxID, phoneNumber);
            if (result1.Equals("Need Code"))
            {
                process = 20;
                print("Auth Method", process, "");


                String result = lineReg.inputCode(deviceID, simID, firstname, lastname, password);
                if (result.Equals("Dont have Auth code"))
                {
                    print("Auth Method", process, result);
                    lineReg.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if (result.Equals("Wrong Auth Code"))
                {
                    print("Auth Method", process, result);
                    lineReg.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if(result.Equals("Already reg"))
                {
                    print("Auth Method", process, result);
                    lineReg.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if (result.Equals("Login Success"))
                {
                    process = 50;
                    print("Login Viper Success", process, "");
                }
                else if (result.Equals("Reg Success"))
                {
                    print("Login Viper Success", process, "");
                }

            }


            result1 = lineReg.logout(deviceID);
            process = 75;
            print("Logout Line ", process, "");

            result1 = lineReg.Exit(deviceID);
            Console.WriteLine("Success");
            Environment.Exit(0);
        }
       
    }
}
