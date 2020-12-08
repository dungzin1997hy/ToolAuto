using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ToolTest.dao;
using System.Drawing;
using KAutoHelper;


namespace ToolTest

{
    class FaceBookService
    {
        Bitmap Response = (Bitmap)Bitmap.FromFile("E://data//facebook//response.png");
        Bitmap ForceStop = (Bitmap)Bitmap.FromFile("E://data//facebook//forcestop.png");

        public FaceBook fb = new FaceBook();
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
                if (ForceStopPoint != null||responsepoint!= null)
                {
                    Console.WriteLine("Error: ForceStop App");
                    isStop = true;
                    fb.Exit(deviceID);
                    Environment.Exit(0);
                }
                String status = MessageDAO.getStatus(deviceID);
                Console.WriteLine("status : " + status);
                if (status.Equals("stopped"))
                {
                    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.facebook.katana ");
                    fb.Exit(deviceID);
                    Environment.Exit(0);
                }


                if (a.Contains("unknown host"))
                {
                    Console.WriteLine("Error: Lost Connection");
                    fb.Exit(deviceID);
                    isHasInternet = false;
                    Environment.Exit(0);
                }
                else isHasInternet = true;
                Console.WriteLine(deviceID + ": " + isHasInternet);
                Thread.Sleep(TimeSpan.FromSeconds(2));

            }
        }
        public void run2(String deviceID, String username, String password, String simID, String noxID)
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



            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: OpenFaceBook");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }



            fb.chooseFacebook(deviceID, noxID);
            process = 10;
            Console.WriteLine("Action: OpenFaceBook");
            Console.WriteLine("Progress: " + process);




            if (!isStop)
            {
                String result = fb.login(deviceID, username, password, noxID);
                if (result.Equals("Login Success"))
                {
                    process = 30;
                    isLoginSuccess = true;
                    Console.WriteLine("Action: LoginFacebook");
                    Console.WriteLine("Progress: " + process);
                }
                else
                if (result.Equals("Need Code"))
                {
                    process += 20;
                    Console.WriteLine("Action: LoginFacebook");
                    Console.WriteLine("Progress: " + process);

                }
                else
                {
                    isStop = true;
                    error = result;
                    Console.WriteLine("Action: LoginFacebook");
                    Console.WriteLine("Progress: " + process);
                    Console.WriteLine("Error: " + error);
                }
            }

            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: LoginFaceBook");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }

            ////////////
            if (!isStop && isLoginSuccess == false)
            {
                String result = fb.inputCode(deviceID, simID);
                if (result.Equals("Login Success"))
                {
                    process += 20;
                    Console.WriteLine("Action: LoginFacebook");
                    Console.WriteLine("Progress: " + process);

                }
                else
                {
                    isStop = true;
                    error = result;
                    Console.WriteLine("Action: LoginFacebook");
                    Console.WriteLine("Progress: " + process);
                    Console.WriteLine("Error:" + error);
                }
            }


            //////

            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: LoginFaceBook");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }


            if (!isStop)
            {
                String result = fb.logout(deviceID);
                if (result.Equals("Logout Success"))
                {
                    process = 80;
                    Console.WriteLine("Action: LogoutFacebook");
                    Console.WriteLine("Progress: " + process);

                }
                else
                {
                    error = "unknow";
                    isStop = true;
                    Console.WriteLine("Action: LogoutFacebook");
                    Console.WriteLine("Progress: " + process);
                    Console.WriteLine("Error: " + error);
                }

            }

            if (isHasInternet == false && isStop == false)
            {
                isStop = true;
                error = "Lost Connection";
                Console.WriteLine("Action: LogoutFacebook");
                Console.WriteLine("Progress: " + process);
                Console.WriteLine("Error: " + error);
            }
            if (isStop == false)
            {
                fb.Exit(deviceID);
                process = 100;
                Console.WriteLine("Action: Complete");
                Console.WriteLine("Progress: " + process);

            }
            else
            {
                fb.Exit(deviceID);
            }
            checkStopInternet = true;
        }
        public void Exit(String deviceID)
        {
            fb.Exit(deviceID);
            isStop = true;
            Console.WriteLine("Exit success");
        }
    }
}
