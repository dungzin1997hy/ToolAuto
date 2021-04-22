using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ToolTest.dao;
namespace ToolTest
{
    class ViberRegService
    {
        public Vpn vpn = new Vpn();
        public ViberReg viber = new ViberReg();
        public void checkInternet(String deviceID)
        {
            while (true)
            {
                try
                {
                    String status = MessageDAO.getStatus(deviceID);
             
                    if (status.Equals("true"))
                    {
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear jp.naver.line.android ");
                        Console.Write("Stop = true");
                        Environment.Exit(0);
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }
                catch (Exception e)
                {
                    Console.WriteLine("doc status");
                    Console.WriteLine(e.Message);
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
        public void run3(String deviceID, String firstname, String lastname, String username, String password, String phoneNumber, String simID, String noxID)
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


            String result1 = viber.chooseViper(deviceID, noxID);
            if (result1.Equals("Open Viper Success"))
            {
                process = 10;
                print("Open Viper", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {

                print("Open Viper", process, result1);
                viber.Exit(deviceID);
                Environment.Exit(0);
            }


            result1 = viber.login(deviceID, phoneNumber, noxID);
            if (result1.Equals("Need Code"))
            {
                process = 20;
                print("Auth Method", process, "");


                String result = viber.inputCode(deviceID, simID, firstname, lastname);
                if (result.Equals("Dont have Auth code"))
                {
                    print("Auth Method", process, result);
                    viber.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if (result.Equals("Wrong Auth Code"))
                {
                    print("Auth Method", process, result);
                    viber.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if (result.Equals("Already reg"))
                {
                    print("Auth Method", process, result);
                    viber.Exit(deviceID);
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


            result1 = viber.logout(deviceID);
            process = 75;
            print("Logout Line ", process, "");

            result1 = viber.Exit(deviceID);
            Console.WriteLine("Success");
            Environment.Exit(0);
        }
    }
}
