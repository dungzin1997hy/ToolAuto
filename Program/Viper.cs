using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class Viper
    {

        #region data
        Bitmap VIPER;
        Bitmap CONTINUE;
        Bitmap DROP;
        Bitmap SEARCH;
        Bitmap VIETNAM;
        Bitmap PHONE;
        Bitmap CONTINUEMIN;
        Bitmap YES;
        Bitmap SMS;
        Bitmap CANTSMS;
        Bitmap CODE;
        Bitmap LOGGING;
        Bitmap WRONGCODE;
        Bitmap TRYAGAIN;
        Bitmap ACTIVE;
        Bitmap LOGINSUCCESS;
        Bitmap TICHV;

        #endregion
        public Viper()
        {
            LoadData();
        }
        void LoadData()
        {
            VIPER = (Bitmap)Bitmap.FromFile("E://data//viper//viper.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("E://data//viper//continue.png");
            DROP = (Bitmap)Bitmap.FromFile("E://data//viper//drop.png");
            SEARCH = (Bitmap)Bitmap.FromFile("E://data//viper//search.png");
            VIETNAM = (Bitmap)Bitmap.FromFile("E://data//viper//vietnam.png");
            PHONE = (Bitmap)Bitmap.FromFile("E://data//viper//phone.png");
            CONTINUEMIN = (Bitmap)Bitmap.FromFile("E://data//viper//continuemin.png");
            YES = (Bitmap)Bitmap.FromFile("E://data//viper//yes.png");
            SMS = (Bitmap)Bitmap.FromFile("E://data//viper//sms.png");
            CANTSMS = (Bitmap)Bitmap.FromFile("E://data//viper//cantsms.png");
            CODE = (Bitmap)Bitmap.FromFile("E://data//viper//code.png");
            LOGGING = (Bitmap)Bitmap.FromFile("E://data//viper//logging.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("E://data//viper//wrongcode.png");
            TRYAGAIN = (Bitmap)Bitmap.FromFile("E://data//viper//tryagain.png");
            ACTIVE = (Bitmap)Bitmap.FromFile("E://data//viper//active.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("E://data//viper//loginsuccess.png");
            TICHV = (Bitmap)Bitmap.FromFile("E://data//viper//tichv.png");

        }
        public void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseViper(String deviceID, String noxID)
        {
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.viber.voip ");
            Delay(3);
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " -package:com.viber.voip");
            Console.WriteLine("adb -s " + deviceID + " shell pm clear com.viber.voip ");
            int count = 20;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install facebook ");
                    KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " \"-apk:D:\\Nox\\apk\\viper.apk");
                    Delay(1);
                    while (true)
                    {
                        var screen1 = Services.ScreenShoot(deviceID);
                        var viperPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, VIPER);
                        //login thnahf coong

                        if (viperPoint != null)
                        {
                            Delay(1);
                            break;
                        }
                        else Delay(1);
                    }
                    return "Open Viper Success";
                }
                var screen = Services.ScreenShoot(deviceID);

                var viper = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, VIPER);

                if (viper != null)
                {
                    return "Open Viper Success";

                }
                else
                {
                    Delay(1);
                    count--;
                }
            }

        }
        public string login(String deviceID, String username, String noxID)
        {

            if (checkLogin(deviceID) == true)
            {
                Console.WriteLine("da dang nhap");
                Console.WriteLine("doi dang xuat");

                Exit(deviceID);
                chooseViper(deviceID, noxID);
                Delay(1);
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CONTINUE) == true)
                {
                    Console.WriteLine("click continue");
                    Delay(1);
                    break;
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, DROP) == true)
                {
                    Console.WriteLine("click drop");
                    Delay(1);
                    break;
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SEARCH) == true)
                {
                    Console.WriteLine("click search");
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, "84");
                    Delay(1);
                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, VIETNAM) == true)
                {
                    Console.WriteLine("click vietnam");
                    Delay(1);
                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PHONE) == true)
                {
                    Console.WriteLine("click phone");
                    Delay(1);

                    KAutoHelper.ADBHelper.InputText(deviceID, username);
                    Delay(1);
                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CONTINUEMIN) == true)
                {
                    Console.WriteLine("click CONTINUE");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi CONTINUE");
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, YES) == true)
                {
                    Console.WriteLine("click yes");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi yes");
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, ACTIVE) == true)
                {
                    Console.WriteLine("doi ");
                    break;
                }
                
            }

            return "Need Code";


        }


        public string inputCode(String deviceID, String simID)
        {
            Delay(30);

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SMS) == true)
                {
                    Console.WriteLine("click send sms");
                    Delay(1);
                    break;
                }
            }
          
            int dem = 80;
            String code = "";
            while (true)
            {
                Delay(20);
                if (Services.findImage(deviceID, CANTSMS) == true)
                {
                    return "Too much try";
                }

                if (dem == 0) break;
                code = MessageDAO.getCodeViper(simID, "");
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
                code = MessageDAO.getCodeViper(simID, "");
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
                    Console.WriteLine("click code");
                    KAutoHelper.ADBHelper.InputText(deviceID, code);

                    Delay(5);
                    break;
                }
                else Console.WriteLine("khong tim thay nut code");

            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, LOGGING) == true)
                {
                    Console.WriteLine("dang loging");
                    Delay(1);

                }
                else
                {
                    break;
                }
            }
            Delay(3);
            if (Services.findImage(deviceID, WRONGCODE) == true)
            {
                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, TRYAGAIN) == true)
                    {
                        Console.WriteLine("click try again");
                        Delay(1);
                        break;
                    }
                }
                Delay(1);
                while (true)
                {

                    var screen = Services.ScreenShoot(deviceID);
                    var codePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CODE);
                    if (codePoint == null)
                    {
                        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
                    }
                    else
                    {
                        break;
                    }
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                KAutoHelper.ADBHelper.InputText(deviceID, code);

                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, LOGGING) == true)
                    {
                        Console.WriteLine("dang loging");
                        Delay(1);

                    }
                    else
                    {
                        break;
                    }
                }

                if (Services.findImage(deviceID, WRONGCODE) == true) return "Wrong Code";
            }

            Delay(1);
            if(Services.findImage(deviceID,TICHV) == true)
            {
                Delay(2);
            }
            Delay(1);

            if (Services.findImage(deviceID, TICHV) == true)
            {
                Delay(2);
            }

            while (true)
            {
                Delay(1);
                if(Services.findImage(deviceID,LOGINSUCCESS) == true)
                {
                    break;
                }
            }
            return "Login Success";
        }


        public string logout(String deviceID)
        {
            Exit(deviceID);

            return "Logout Success";


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
            KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            Delay(1);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            Delay(1);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            Delay(1);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            Delay(3);
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.viber.voip ");
            Delay(1);
            return "Exit Success";

        }


        Boolean checkLogin(String deviceID)
        {
            Boolean isLogin = false;

            //var screen = Services.ScreenShoot(deviceID);
            //var SAVEINFOpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SAVEINFO);
            //if (SAVEINFOpoint != null)
            //{

            //    var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, OK);

            //    Console.WriteLine(point.Value.X);
            //    KAutoHelper.ADBHelper.Tap(deviceID, point.Value.X, point.Value.Y);
            //    Delay(1);

            //}

            //screen = Services.ScreenShoot(deviceID);
            //var LOGINSUCCESSpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);

            //if (LOGINSUCCESSpoint != null)
            //{
            //    isLogin = true;
            //}
            //Delay(1);
            return isLogin;
        }

    }
}
