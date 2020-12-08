using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ToolTest.dao;
using System.Threading;

namespace ToolTest
{
    class GmailServices
    {
        Bitmap ForceStop = (Bitmap)Bitmap.FromFile("E://data//facebook//forcestop.png");
        Bitmap Response = (Bitmap)Bitmap.FromFile("E://data//facebook//response.png");


        public Gmail gmail = new Gmail();
        public Services services = new Services();
        public MessageDAO messageDAO = new MessageDAO();

        public static Boolean isStop;
        public static Boolean checkStopInternet = false;
        public static Boolean isHasInternet = true;
        public static Boolean isLoginSuccess = false;
        public void checkInternet(String deviceID)
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
                    gmail.Exit(deviceID);
                    isStop = true;
                    Environment.Exit(0);
                }
                String status = MessageDAO.getStatus(deviceID);
                Console.WriteLine("status : " + status);
                if (status.Equals("stopped"))
                {
                    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear org.mozilla.firefox ");
                    gmail.Exit(deviceID);
                    Environment.Exit(0);
                }


                if (a.Contains("unknown host"))
                {
                    Console.WriteLine("Error: Lost Connection");
                    gmail.Exit(deviceID);
                    isHasInternet = false;
                    Environment.Exit(0);
                }
                else isHasInternet = true;
                Console.WriteLine(deviceID + ": " + isHasInternet);
                Thread.Sleep(TimeSpan.FromSeconds(2));

            }
        }


        public void print(String action,int process, String error)
        {
            Console.WriteLine("Action: " + action);
            Console.WriteLine("Progress: " + process);
            Console.WriteLine(error);
            if (error.Equals("")== false)
            {
                Console.WriteLine("Error: " + error);
            }
        }
        public void runGmail(String deviceID, String name, String password, String simID, String noxID)
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




            String result1 = gmail.chooseFireFox(deviceID, noxID);
            if (result1.Equals("Open FireFox Success"))
            {
                process = 10;
                print("Open FireFox", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {
               
                print("Open FireFox", process, result1);
                gmail.Exit(deviceID);
                Environment.Exit(0);
            }



            result1 = gmail.chooseGmail(deviceID);
            if (result1.Equals("Open Gmail Success"))
            {
                process = 20;
                print("Open gmail", process, "");

            }


            result1 = gmail.login(deviceID, name, password, noxID);
            if(result1.Equals("Login Success"))
            {
                process = 50;
                print("Login Gmail Success", process, "");
               
            }
            else if(result1.Equals("Wrong username"))
            {

                print("Login Gmail", process, result1);
              
                gmail.Exit(deviceID);
                Environment.Exit(0);
            }
            else if(result1.Equals("Wrong password"))
            {
                print("Login Gmail", process, result1);
               
                gmail.Exit(deviceID);
                Environment.Exit(0);
            }
            else if(result1.Equals("Too Much Try"))
            {
                print("Login Gmail", process, result1);
                gmail.Exit(deviceID);
                Environment.Exit(0);
            }


            else if(result1.Equals("Choose Auth Method"))
            {
                process = 40;
                print("Auth Method", process, "");
               

                String result = gmail.inputCode(deviceID, simID);
                if(result.Equals("Dont have Auth code"))
                {
                    print("Auth Method", process, result);
                    gmail.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if(result.Equals("Wrong Auth Code"))
                {
                    print("Auth Method", process, result);
                    gmail.Exit(deviceID);
                    Environment.Exit(0);
                }
                else if(result.Equals("Login Success"))
                {
                    process = 50;
                    print("Login Gmail Success", process, "");

                }

            }

            result1 = gmail.logout(deviceID);
            process = 75;
            print("Logout Gmail ", process, "");

            result1 = gmail.Exit(deviceID);
            print("Complete ", 100, "");
            Environment.Exit(0);

        }
    }
}
