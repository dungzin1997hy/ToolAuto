using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class LineService

    {
        Bitmap ForceStop = (Bitmap)Bitmap.FromFile("E://data//facebook//forcestop.png");
        Bitmap Response = (Bitmap)Bitmap.FromFile("E://data//facebook//response.png");

        public Line line = new Line();
        public Services services = new Services();

        public static Boolean isStop;
        public static Boolean checkStopInternet = false;
        public static Boolean isHasInternet = true;
        public static Boolean isLoginSuccess = false;
        public void checkInternet(String deviceID)
        {
            try
            {
                while (checkStopInternet == false)
                {
                    String a = KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell ping -c 2 google.com");
                    //   Console.WriteLine(a);
                    var screen = Services.ScreenShoot(deviceID);
                    var ForceStopPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ForceStop);
                    var responsepoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Response);
                    if (ForceStopPoint != null || responsepoint != null)
                    {
                        Console.WriteLine("Error: ForceStop App");
                        isStop = true;
                        line.Exit(deviceID);
                        Environment.Exit(0);
                    }

                    String status = MessageDAO.getStatus(deviceID);
                    Console.WriteLine("status : " + status);
                    if (status.Equals("stopped"))
                    {
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear jp.naver.line.android ");
                        line.Exit(deviceID);
                        Environment.Exit(0);
                    }

                    if (a.Contains("unknown host"))
                    {
                        Console.WriteLine("Error: Lost Connection");
                        line.Exit(deviceID);
                        isHasInternet = false;
                        Environment.Exit(0);
                    }
                    else isHasInternet = true;
                    Console.WriteLine(deviceID + ": " + isHasInternet);
                    Thread.Sleep(TimeSpan.FromSeconds(2));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Error: App Force Stop");
                Exit(deviceID);
                Environment.Exit(0);
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
        public void run3(String deviceID, String username, String password, String simID, String phoneNumber, String noxID)
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




            String result1 = line.chooseSkype(deviceID, noxID);
            if (result1.Equals("Open Line Success"))
            {
                process = 10;
                print("Open Line", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {

                print("Open Line", process, result1);
                line.Exit(deviceID);
                Environment.Exit(0);
            }


            result1 = line.login(deviceID, username, password, noxID);
             if (result1.Equals("Wrong Username"))
            {

                print("Login Whatsapp", process, result1);
                line.Exit(deviceID);
                Environment.Exit(0);
            }

            else if (result1.Equals("Need Code"))
            {
                process = 20;
                print("Auth Method", process, "");


                String result = line.inputCode(deviceID, simID);
                if (result.Equals("Dont have Auth code"))
                {
                    print("Auth Method", process, result);
                    line.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if (result.Equals("Wrong Auth Code"))
                {
                    print("Auth Method", process, result);
                    line.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if (result.Equals("Input Password"))
                {
                    process = 30;
                    print("Input code", process, "");
                    String result33 = line.inputPassword(deviceID, password);
                    if (result33.Equals("LoginSuccess"))
                    {
                        process = 50;
                        print("Login Viper Success", process, "");
                    }

                }
                else if (result.Equals("Login Success"))
                {
                    process = 50;
                    print("Login Viper Success", process, "");
                }

            }
            

            result1 = line.logout(deviceID);
            process = 75;
            print("Logout Line ", process, "");

            result1 = line.Exit(deviceID);
            print("Complete ", 100, "");
            Environment.Exit(0);
        }
        public void Exit(String deviceID)
        {
            line.Exit(deviceID);
            isStop = true;
            Console.WriteLine("Exit success");
        }
    }
}
