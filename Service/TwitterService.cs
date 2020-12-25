using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class TwitterService

    {
        Bitmap ForceStop = (Bitmap)Bitmap.FromFile("C://data//facebook//forcestop.png");
        Bitmap Response = (Bitmap)Bitmap.FromFile("C://data//facebook//response.png");

        public Twitter twitter = new Twitter();
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
                        twitter.Exit(deviceID);
                        Environment.Exit(0);
                    }

                    String status = MessageDAO.getStatus(deviceID);
                    Console.WriteLine("status : " + status);
                    if (status.Equals("stopped"))
                    {
                        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.skype.raider ");
                        twitter.Exit(deviceID);
                        Environment.Exit(0);
                    }

                    if (a.Contains("unknown host"))
                    {
                        Console.WriteLine("Error: Lost Connection");
                        twitter.Exit(deviceID);
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




            String result1 = twitter.chooseTwitter(deviceID, noxID);
            if (result1.Equals("Open Twitter Success"))
            {
                process = 10;
                print("Open Twitter", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {

                print("Open Twitter", process, result1);
                twitter.Exit(deviceID);
                Environment.Exit(0);
            }


            result1 = twitter.login(deviceID, username, password, noxID);
            if (result1.Equals("Login Success"))
            {
                process = 50;
                print("Login Whatsapp Success", process, "");

            }
            else if (result1.Equals("Wrong Username"))
            {

                print("Login Whatsapp", process, result1);

                twitter.Exit(deviceID);
                Environment.Exit(0);
            }


            else if (result1.Equals("Need Code"))
            {
                process = 30;
                print("Auth Method", process, "");


                String result = twitter.inputCode(deviceID, simID);
                if (result.Equals("Dont have Auth code"))
                {
                    print("Auth Method", process, result);
                    twitter.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if (result.Equals("Wrong Auth Code"))
                {
                    print("Auth Method", process, result);
                    twitter.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if (result.Equals("Login Success"))
                {
                    process = 50;
                    print("Login Twitter Success", process, "");

                }

            }

            result1 = twitter.logout(deviceID);
            process = 75;
            print("Logout Whatsapp ", process, "");

            result1 = twitter.Exit(deviceID);
            print("Complete ", 100, "");
            Environment.Exit(0);
        }
        public void Exit(String deviceID)
        {
            twitter.Exit(deviceID);
            isStop = true;
            Console.WriteLine("Exit success");
        }
    }
}
