using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class ViberReg

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
        Bitmap NAME;
        Bitmap ABOVE;

        #endregion
        public ViberReg()
        {
            LoadData();
        }
        void LoadData()
        {
            VIPER = (Bitmap)Bitmap.FromFile("C://data//viper//viper.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("C://data//viper//continue.png");
            DROP = (Bitmap)Bitmap.FromFile("C://data//viper//drop.png");
            SEARCH = (Bitmap)Bitmap.FromFile("C://data//viper//search.png");
            VIETNAM = (Bitmap)Bitmap.FromFile("C://data//viper//vietnam.png");
            PHONE = (Bitmap)Bitmap.FromFile("C://data//viper//phone.png");
            CONTINUEMIN = (Bitmap)Bitmap.FromFile("C://data//viper//continuemin.png");
            YES = (Bitmap)Bitmap.FromFile("C://data//viper//yes.png");
            SMS = (Bitmap)Bitmap.FromFile("C://data//viper//sms.png");
            CANTSMS = (Bitmap)Bitmap.FromFile("C://data//viper//cantsms.png");
            CODE = (Bitmap)Bitmap.FromFile("C://data//viper//code.png");
            LOGGING = (Bitmap)Bitmap.FromFile("C://data//viper//logging.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("C://data//viper//wrongcode.png");
            TRYAGAIN = (Bitmap)Bitmap.FromFile("C://data//viper//tryagain.png");
            ACTIVE = (Bitmap)Bitmap.FromFile("C://data//viper//active.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("C://data//viper//loginsuccess.png");
            TICHV = (Bitmap)Bitmap.FromFile("C://data//viper//tichv.png");
            NAME = (Bitmap)Bitmap.FromFile("C://data//viper//name.png");
            ABOVE = (Bitmap)Bitmap.FromFile("C://data//viper//above.png");

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
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.viber.voip");
            Console.WriteLine("adb -s " + deviceID + " shell pm clear com.viber.voip ");
            int count = 20;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install facebook ");
                    KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " \"-apk:" + MainProgram.linkApk + "\\viper.apk");
                    Delay(1);
                    int dem = 30;
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
                    Console.WriteLine(deviceID+"click continue");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine(deviceID + "dang doi continue");
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, DROP) == true)
                {
                    Console.WriteLine(deviceID + "click drop");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine(deviceID + "dang doi drop");
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SEARCH) == true)
                {
                    Console.WriteLine(deviceID + "click search");
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, "84");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine(deviceID + "dang doi search");
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, VIETNAM) == true)
                {
                    Console.WriteLine(deviceID + "click vietnam");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine(deviceID + "dang doi vietnam");
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PHONE) == true)
                {
                    Console.WriteLine(deviceID + "click phone");
                    Delay(1);

                    KAutoHelper.ADBHelper.InputText(deviceID, username);
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine(deviceID + "dang doi phone");
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CONTINUEMIN) == true)
                {
                    Console.WriteLine(deviceID + "click CONTINUE");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine(deviceID + "dang doi CONTINUE");
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, YES) == true)
                {
                    Console.WriteLine(deviceID + "click yes");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine(deviceID + "dang doi yes");
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, ACTIVE) == true)
                {
                    Console.WriteLine(deviceID + "doi active ");
                    break;
                }

            }

            return "Need Code";


        }


        public string inputCode(String deviceID, String simID,String firstname,String lastname)
        {
            Delay(30);

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SMS) == true)
                {
                    Console.WriteLine(deviceID + "click send sms");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi sms");
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

                if (Services.findImage(deviceID, WRONGCODE) == true) return "Wrong Auth Code";
            }
            while (true)
            {
                if(Services.findImage(deviceID,NAME) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, firstname);
                    Thread.Sleep(TimeSpan.FromMilliseconds(300));
                    KAutoHelper.ADBHelper.InputText(deviceID, lastname);
                    break;
                }
            }
            while (true)
            {
                Delay(1);
                if(Services.findImage(deviceID,TICHV) == true)
                {
                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, ABOVE) == true)
                {
                    break;
                }
            }


            Delay(1);
            if (Services.findImage(deviceID, TICHV) == true)
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
                if (Services.findImage(deviceID, LOGINSUCCESS) == true)
                {
                    return "Reg Success";
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
