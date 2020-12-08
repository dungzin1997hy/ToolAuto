using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace ToolTest
{
    class Zalo
    {
        #region data
        Bitmap ZALO;
        Bitmap LOGINACCOUNT;
        Bitmap CLEAR;

        Bitmap USERNAME;
        Bitmap PASSWORD;

        Bitmap CONTINUE;
        Bitmap LOGGING;
        Bitmap WRONGUSERNAME;
        Bitmap LOGIN;
        Bitmap WRONGPASSWORD;
        Bitmap WRONGPASSWORD2;
        Bitmap LOGINSUCCESS;
        Bitmap MORE;
        Bitmap SETTING;
        Bitmap LOGOUT;
        Bitmap YES;
        Bitmap Skip;


        #endregion
        public Zalo()
        {
            LoadData();
        }
        void LoadData()
        {
            ZALO = (Bitmap)Bitmap.FromFile("E://data//zalo//zalo.png");
            LOGINACCOUNT = (Bitmap)Bitmap.FromFile("E://data//zalo//loginaccount.png");
            CLEAR = (Bitmap)Bitmap.FromFile("E://data//zalo//clear.png");
            USERNAME = (Bitmap)Bitmap.FromFile("E://data//zalo//username.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("E://data//zalo//password.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("E://data//zalo//continue.png");
            LOGGING = (Bitmap)Bitmap.FromFile("E://data//zalo//logging.png");
            WRONGUSERNAME = (Bitmap)Bitmap.FromFile("E://data//zalo//wrongusername.png");
            WRONGPASSWORD = (Bitmap)Bitmap.FromFile("E://data//zalo//wrongpassword.png");
            MORE = (Bitmap)Bitmap.FromFile("E://data//zalo//more.png");
            SETTING = (Bitmap)Bitmap.FromFile("E://data//zalo//setting.png");
            LOGOUT = (Bitmap)Bitmap.FromFile("E://data//zalo//logout.png");
            YES = (Bitmap)Bitmap.FromFile("E://data//zalo//yes.png");
            WRONGPASSWORD2 = (Bitmap)Bitmap.FromFile("E://data//zalo//wrongpassword2.png");
            Skip = (Bitmap)Bitmap.FromFile("E://data//zalo//skip.png");
        }
        public void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseZalo(String deviceID, String noxID)
        {
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.zing.zalo ");
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " -package:com.zing.zalo");


            int count = 10;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install zalo ");
                    KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " \"-apk:D:\\Nox\\apk\\Zalo.apk\"");
                    Delay(1);
                    int dem = 30;
                    while (true)
                    {
                        Console.WriteLine("dang doi install");
                        var screen1 = Services.ScreenShoot(deviceID);
                        var loginAccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINACCOUNT);

                        if (loginAccountPoint != null)
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
                    return "Open Zalo Success";
                }
                var screen = Services.ScreenShoot(deviceID);


                var loginAccountPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINACCOUNT);
                var morePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, MORE);

                if (loginAccountPoint1 != null || morePoint != null)
          
                {
                    return "Open Zalo Success";

                }
                else
                {
                    Delay(1);
                    count--;
                }
            }

        }
        public string login(String deviceID, String username, String password, String noxID)
        {


            if (checkLogin(deviceID) == true)
            {
                Console.WriteLine("da dang nhap");
                Console.WriteLine("doi dang xuat");
                logout(deviceID);
                Exit(deviceID);
                chooseZalo(deviceID, noxID);
                Delay(1);
            }

            var screen = Services.ScreenShoot(deviceID);
            var LOGINACCOUNTpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINACCOUNT);
            if (LOGINACCOUNTpoint != null)
            {
                Console.WriteLine("click dang nhap");
                KAutoHelper.ADBHelper.Tap(deviceID, LOGINACCOUNTpoint.Value.X, LOGINACCOUNTpoint.Value.Y);

            }
            Delay(1);

            screen = Services.ScreenShoot(deviceID);
            var clearPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CLEAR);
            if (clearPoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, clearPoint.Value.X, clearPoint.Value.Y);
                Delay(1);
            }

            int dem = 3;
            while (true)
            {


                screen = Services.ScreenShoot(deviceID);
                clearPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CLEAR);
                if (clearPoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, clearPoint.Value.X, clearPoint.Value.Y);
                    Delay(1);
                }


                while (true)
                {
                    if (Services.findImage(deviceID, USERNAME) == true)
                    {
                        Console.WriteLine("click username");
                        Delay(1);
                        KAutoHelper.ADBHelper.InputText(deviceID, username);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 46.5, 5.0);
                        break;
                    }
                    else Console.WriteLine("khong thay username");
                }

                //screen = Services.ScreenShoot(deviceID);
                //var USERNAMEpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, USERNAME);
                //if (USERNAMEpoint != null)
                //{
                //    Console.WriteLine("nhap username");
                //    KAutoHelper.ADBHelper.Tap(deviceID, USERNAMEpoint.Value.X, USERNAMEpoint.Value.Y);
                //    KAutoHelper.ADBHelper.InputText(deviceID, username);
                //    KAutoHelper.ADBHelper.TapByPercent(deviceID, 46.5, 5.0);
                //}
                //Delay(1);

                KAutoHelper.ADBHelper.TapByPercent(deviceID, 50, 10);


                while (true)
                {
                    if (Services.findImage(deviceID, PASSWORD) == true)
                    {
                        Console.WriteLine("click password");
                        Delay(1);
                        KAutoHelper.ADBHelper.InputText(deviceID, password);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 46.5, 5.0);
                        break;
                    }
                    else Console.WriteLine("khong thay password");
                }

                //screen = Services.ScreenShoot(deviceID);
                //var PASSWORDpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PASSWORD);
                //if (PASSWORDpoint != null)
                //{
                //    KAutoHelper.ADBHelper.Tap(deviceID, PASSWORDpoint.Value.X, PASSWORDpoint.Value.Y);
                //    KAutoHelper.ADBHelper.InputText(deviceID, password);
                //}
                //Delay(1);

                while (true)
                {

                    Delay(1);
                    if (Services.findImage(deviceID, CONTINUE) == true)
                    {
                        Console.WriteLine("click continue");
                        break;

                    }
                    else Console.WriteLine("khong tim thay nut continue");
                }

                screen = Services.ScreenShoot(deviceID);
                var continuePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CONTINUE);
                if (continuePoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, continuePoint.Value.X, continuePoint.Value.Y);

                }
                Delay(1);

                //ĐỢI LOGIN
                Boolean logging = true;
                while (logging)
                {
                    Console.WriteLine("doi logging");
                    screen = Services.ScreenShoot(deviceID);
                    var LOGGINGpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGGING);

                    if (LOGGINGpoint == null)
                    {
                        logging = false;
                    }
                    Delay(1);
                }


                // CHECK LỖI
                screen = Services.ScreenShoot(deviceID);
                var WrongUserPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGUSERNAME);
                var WrongPassWordPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGPASSWORD);
                var WrongPassWord2Point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGPASSWORD2);

                if (WrongPassWord2Point != null)
                {
                    return "Wrong Password";
                }
                if (WrongUserPoint != null || WrongPassWordPoint != null && dem > 0)
                {
                    Console.WriteLine("Wrong username or password");
                    dem--;
                }

                if (WrongUserPoint != null || WrongPassWordPoint != null && dem == 0)
                {
                    return "Wrong Username or Password";
                }
                if (WrongUserPoint == null && WrongPassWordPoint == null)
                {
                    Console.WriteLine("login thanh cong");
                    Delay(3);
                    break;
            
                    
                }
            }

            Services.findImage(deviceID, Skip);
            Delay(1);
            Services.findImage(deviceID, Skip);
            Delay(1);

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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.zing.zalo ");

            return "Exit Success";

        }


        Boolean checkLogin(String deviceID)
        {
            Boolean isLogin = false;

            var screen = Services.ScreenShoot(deviceID);

            var morePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, MORE);

            if (morePoint != null)
            {
               return true;
            }

            Delay(2);
            morePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, MORE);

            if (morePoint != null)
            {
                return true;
            }
            Delay(1);
            return isLogin;
        }

    }
}

