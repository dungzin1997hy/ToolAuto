using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ToolTest.dao;
using System.Drawing;
namespace ToolTest
{
    class FaceBookRegService
    {
        Bitmap ACCOUNTLOCK = (Bitmap)Bitmap.FromFile("C://data//facebookreg//accountlock.png");
        Bitmap COULDNOT = (Bitmap)Bitmap.FromFile("C://data//facebookreg//couldnt.png");
        public FacebookRes facebook = new FacebookRes();
        public Vpn vpn = new Vpn();
        public void checkInternet(String deviceID)
        {
            while (true)
            {
                if(Services.findImage(deviceID,ACCOUNTLOCK) == true)
                {
                    Console.WriteLine("Error : Account lock");
                    Environment.Exit(0);
                }
                if (Services.findImage(deviceID, COULDNOT) == true)
                {
                    Console.WriteLine("Error : Cant creat account");
                    Environment.Exit(0);
                }
                String status = MessageDAO.getStatus(deviceID);
               
                if (status.Equals("true"))
                {
                    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.facebook.katana ");
                    Environment.Exit(0);
                }
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

            Console.WriteLine("Action: Wait");
            Console.WriteLine("Progress: " + process);

            vpn.configVpn(deviceID, noxID);


            String result1 = facebook.chooseFacebook(deviceID,noxID);
            if (result1.Equals("Open FaceBook Success"))
            {
                process = 10;
                print("Open Facebook", process, "");

            }
            else if (result1.Equals("Open App Error"))
            {

                print("Open Line", process, result1);
                facebook.Exit(deviceID);
                Environment.Exit(0);
            }


            result1 = facebook.facebookreg(deviceID,firstname,lastname,phone,password,simId);
            if (result1.Equals("Dont have Auth code"))
            {
                print("Auth Method", process, result1);
                facebook.Exit(deviceID);
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
            else if(result1.Equals("Couldn't create account"))
            {
                print("Create accout", process, result1);
            }


            facebook.Exit(deviceID);
            Console.WriteLine("Success: Reg");
            Environment.Exit(0);
        }
    }
}
