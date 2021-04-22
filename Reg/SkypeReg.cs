using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class SkypeReg
    {
        #region data
        Bitmap SKYPE;
        Bitmap LOGIN;
        Bitmap LOGINACCOUNT;
        Bitmap SIGNIN;
        Bitmap CREATEACCOUNT;
        Bitmap PHONENUMBER;
        Bitmap NEXT;
        Bitmap ALREADY;
        Bitmap CODE;
        Bitmap ADDDETAIL;
        Bitmap LOGINSUCCESS;
        #endregion
        public SkypeReg()
        {
            LoadData();
        }
        void LoadData()
        {
            SKYPE = (Bitmap)Bitmap.FromFile("C://data//skype//skype.png");
            LOGIN = (Bitmap)Bitmap.FromFile("C://data//skype//login.png");
            LOGINACCOUNT = (Bitmap)Bitmap.FromFile("C://data//skype//loginaccount.png");
            SIGNIN = (Bitmap)Bitmap.FromFile("C://data//skype//signin.png");
            CREATEACCOUNT = (Bitmap)Bitmap.FromFile("C://data//skype//createaccount.png");
            PHONENUMBER = (Bitmap)Bitmap.FromFile("C://data//skype//phonenumber.png");
            NEXT = (Bitmap)Bitmap.FromFile("C://data//skype//next.png");
            ALREADY = (Bitmap)Bitmap.FromFile("C://data//skype//already.png");
            CODE = (Bitmap)Bitmap.FromFile("C://data//skype//code.png");
            ADDDETAIL = (Bitmap)Bitmap.FromFile("C://data//skype//adddetail.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("C://data//skype//loginsuccess.png");
        }
        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string Exit(String deviceID)
        {

            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
            Delay(1);
            KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
            KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700); ;
            Delay(1);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            Delay(5);
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.skype.raider ");
            return "Exit Success";


        }
        public string chooseSkype(String deviceID, String noxID)
        {
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.skype.raider ");
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.skype.raider");


            int count = 20;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install skype ");
                    KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " \"-apk:" + MainProgram.linkApk + "\\Skype.apk\"");
                    Delay(1);
                    int dem = 30;
                    while (true)
                    {
                        Console.WriteLine("dang doi install");
                        var screen1 = Services.ScreenShoot(deviceID);
                        var loginAccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINACCOUNT);
                        var singinPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, SIGNIN);
                     
                        if (loginAccountPoint != null || singinPoint != null)
                        {
                            Delay(1);
                            break;

                        }
                        else
                        {
                            Delay(1);
                            dem--;
                        }
                        if (dem == 0)
                        {
                            Console.WriteLine("looix app");
                            return "Open App Error";
                        }

                    }
                    return "Open Skype Success";
                }
                var screen = Services.ScreenShoot(deviceID);


                var loginAccountPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINACCOUNT);
                var signinPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SIGNIN);
  


                if (loginAccountPoint1 != null || signinPoint != null)

                {
                    return "Open Skype Success";

                }
                else
                {
                    Delay(1);
                    count--;
                }
            }
        }

        public string skypeReg(String deviceID,String phonenumber,String simId,String firstname,String lastname)
        {

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CREATEACCOUNT) == true)
                {
                    Delay(1);
                    break;
                }
                else
                    Console.WriteLine("CREATE ACCOUNT TIM");
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PHONENUMBER) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, phonenumber);
                    break;
                }
                else
                    Console.WriteLine("TIM phonenumber");
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, NEXT) == true)
                {
                    Delay(1);
                
                    break;
                }
                else
                    Console.WriteLine("TIM NEXT");
            }
            Delay(1);
            if(Services.findImage(deviceID,ALREADY) == true)
            {
                return "Already Have Account";
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CODE) == true)
                {
                    Delay(1);

                    break;
                }
                else
                    Console.WriteLine("TIM code");
            }

            int dem = 80;
            String code = "";
            while (true)
            {
              
                if (dem == 0) break;
                code = MessageDAO.getCodeSkype(simId, MessageDAO.FBsql);
                if (code == "" || code == null)
                {
                    Console.WriteLine("DANG DOI TIN NHAN");
                    dem -= 20;
                }
                else
                {

                    break;
                }


            }
            Console.WriteLine("Code: " + code);
            if (code.Equals(""))
            {
                code = MessageDAO.getCodeSkype(simId, "");
                Console.WriteLine("Code: " + code);
                if (code.Equals("") || code == null)
                {
                    return "Dont have Auth code";
                }

            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CODE) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, code);

                    break;
                }
                else
                    Console.WriteLine("TIM code");
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID,NEXT) == true)
                {
                    Delay(1);

                    break;
                }
                else
                    Console.WriteLine("TIM NEXT");
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, ADDDETAIL) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, 100, 500);
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, firstname);
                    Delay(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, 400, 500);
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, lastname);
                    break;
                }
                else
                    Console.WriteLine("TIM NEXT");
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, NEXT) == true)
                {
                    Delay(1);

                    break;
                }
                else
                    Console.WriteLine("TIM NEXT");
            }


            return "";
        }
    }
}
