using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ToolTest.dao;
using System.Threading;

namespace ToolTest
{
    class SkypeService
    {
        Bitmap ForceStop = (Bitmap)Bitmap.FromFile("E://data//facebook//forcestop.png");

        public Skype skype = new Skype();
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
                    if (ForceStopPoint != null)
                    {
                        Console.WriteLine("Error: ForceStop App");
                        isStop = true;
                        Environment.Exit(0);
                    }

                    String status = MessageDAO.getStatus(deviceID);
                    Console.WriteLine("status : " + status);
                    if (status.Equals("stopped"))
                    {
                        Environment.Exit(0);
                    }

                    if (a.Contains("unknown host"))
                    {
                        Console.WriteLine("Error: Lost Connection");

                        isHasInternet = false;
                        Environment.Exit(0);
                    }
                    else isHasInternet = true;
                    Console.WriteLine(deviceID + ": " + isHasInternet);
                    Thread.Sleep(TimeSpan.FromSeconds(2));

                }
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Error: App Force Stop");
                Exit(deviceID);
                Environment.Exit(0);
            }
        }
        public void run3(String deviceID, String username, String password,  String noxID)
        {
            isStop = false;
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

            status = MessageDAO.getStatus(deviceID);
            if (status.Equals("stopped"))
                isStop = true;

            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: OpenSkype");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }

            status = MessageDAO.getStatus(deviceID);
            if (status.Equals("stopped"))
                isStop = true;

            skype.chooseSkype(deviceID, noxID);
            process += 20;
            Console.WriteLine("Action: OpenSkype");
            Console.WriteLine("Progress: " + process);


            status = MessageDAO.getStatus(deviceID);
            if (status.Equals("stopped"))
                isStop = true;

            if (!isStop)
            {
                String result = skype.login(deviceID, username, password, noxID);
                if (result.Equals("Login Success"))
                {
                    process = 30;
                    isLoginSuccess = true;
                    Console.WriteLine("Action: LoginSkype");
                    Console.WriteLine("Progress: " + process);
                }
                else
                if (result.Equals("Need Code"))
                {
                    process += 20;
                    Console.WriteLine("Action: LoginSkype");
                    Console.WriteLine("Progress: " + process);

                }
                else
                {
                    isStop = true;
                    error = result;
                    Console.WriteLine("Action: LoginSkype");
                    Console.WriteLine("Progress: " + process);
                    Console.WriteLine("Error: " + error);
                }
            }
            status = MessageDAO.getStatus(deviceID);
            if (status.Equals("stopped"))
                isStop = true;
            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: LoginFaceBook");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }

            ////////////
           


            //////
            status = MessageDAO.getStatus(deviceID);
            if (status.Equals("stopped"))
                isStop = true;
            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: LoginSkype");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }


            if (!isStop)
            {
                String result = skype.logout(deviceID);
                if (result.Equals("Logout Success"))
                {
                    process = 80;
                    Console.WriteLine("Action: LogoutSkype");
                    Console.WriteLine("Progress: " + process);

                }
                else
                {
                    error = "unknow";
                    isStop = true;
                    Console.WriteLine("Action: LogoutSkype");
                    Console.WriteLine("Progress: " + process);
                    Console.WriteLine("Error: " + error);
                }

            }
            status = MessageDAO.getStatus(deviceID);
            if (status.Equals("stopped"))
                isStop = true;
            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: LogoutSkype");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }
            if (isStop == false)
            {
                skype.Exit(deviceID);
                process = 100;
                Console.WriteLine("Action: Complete");
                Console.WriteLine("Progress: " + process);

            }
            else
            {
                skype.Exit(deviceID);
            }
            checkStopInternet = true;
        }
        public void Exit(String deviceID)
        {
            skype.Exit(deviceID);
            isStop = true;
            Console.WriteLine("Exit success");
        }
    }
}

