using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using ToolTest;
using ToolTest.dao;
using System.Drawing;

namespace ToolTest
{
    
    class ZaloService
    {
        Bitmap ForceStop = (Bitmap)Bitmap.FromFile("E://data//facebook//forcestop.png");

        Bitmap Response = (Bitmap)Bitmap.FromFile("E://data//facebook//response.png");
        public Zalo zalo = new Zalo();
        public Services services = new Services();
        public static Boolean isStop;
        public static Boolean checkStopInternet = false;
        public static Boolean isHasInternet = true;

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
                    isStop = true;
                    zalo.Exit(deviceID);
                    Environment.Exit(0);
                }
                String status = MessageDAO.getStatus(deviceID);
                Console.WriteLine("status : " + status);
                if (status.Equals("stopped"))
                {
                    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.zing.zalo ");
                    zalo.Exit(deviceID);
                    Environment.Exit(0);
                }


                if (a.Contains("unknown host"))
                {
                    Console.WriteLine("Error: Lost Connection");
                    zalo.Exit(deviceID);
                    isHasInternet = false;
                    Environment.Exit(0);
                }
                else isHasInternet = true;
                Console.WriteLine(deviceID + ": " + isHasInternet);
                Thread.Sleep(TimeSpan.FromSeconds(2));

            }
        }
        public void run1(String deviceID,String username, String password,String noxID)
        {
            bool isStop = false;
            String error = "none";
            bool isHasInternet = true;
            int process = 0;

            Thread thread = new Thread(() =>
                checkInternet(deviceID)

                );
            
            thread.Start();


            Console.WriteLine("Action: Wait");
            Console.WriteLine("Progress: " + process);
        
            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: OpenZalo");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }

            String result1 = zalo.chooseZalo(deviceID,noxID);
            if (result1.Equals("Open Zalo Success"))
            {
                process = 10;
                Console.WriteLine("Action: OpenZalo");
                Console.WriteLine("Progress: " + process);
                
            }
            else if(result1.Equals("Open App Error"))
            {
                isStop = true;
                Console.WriteLine("Action: OpenZalo");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + result1);
            }
            if (!isStop)
            {
                String result = zalo.login(deviceID, username, password,noxID);
                if (result.Equals("Login Success"))
                {
                    process += 25;
                    Console.WriteLine("Action: LoginZalo");
                    Console.WriteLine("Progress: " + process);
                    
                }
                else
                {
                    isStop = true;
                    error = result;
                    Console.WriteLine("Action: LoginZalo");
                    Console.WriteLine("Progress: " + process);
                    Console.WriteLine("Error:"+error);
                }
            }

            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: LoginZalo");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }
            if (!isStop)
            {
                String result = zalo.logout(deviceID);
                if (result.Equals("Logout Success"))
                {
                    process =90;
                    Console.WriteLine("Action: LogoutZalo");
                    Console.WriteLine("Progress: " + process);
                  
                }
                else
                {
                    error = "unknow";
                    isStop = true;
                    Console.WriteLine("Action: LogoutZalo");
                    Console.WriteLine("Progress: " + process);
                    Console.WriteLine("Error: "+error);
                }

            }
            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: LogoutZalo");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }
            if (isStop == false)
            {
                zalo.Exit(deviceID);
                process =100;
                Console.WriteLine("Action: Complete");
                Console.WriteLine("Progress: " + process);
               
            }
            else
            {
                zalo.Exit(deviceID);
            }
            checkStopInternet = true;
        }
    }
}
