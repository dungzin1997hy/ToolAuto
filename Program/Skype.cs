using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace ToolTest
{
    class Skype
    {
        #region data
        Bitmap SKYPE;
        Bitmap LIKE;
        Bitmap CONTINUE;
        Bitmap USERNAME;
        Bitmap PASSWORD;
        Bitmap LOGIN;
        Bitmap LOGINACCOUNT;
        Bitmap WRONGUSERNAME;
        Bitmap WRONGPASSWORD;
        Bitmap LOGINSUCCESS;
        Bitmap SETTING;
        Bitmap LOGOUT;
        Bitmap LOGGING;
        Bitmap OK;
        Bitmap RETRY;
        Bitmap LOGINFAILED;
        Bitmap NEEDCODE;
        Bitmap CODE;
        Bitmap SAVEINFO;
        Bitmap NOTIFY;
        Bitmap SIGNIN;
        #endregion
        public Skype()
        {
            LoadData();
        }
        void LoadData()
        {
            SKYPE = (Bitmap)Bitmap.FromFile("E://data//skype//skype.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("E://data//skype//continue.png");
            USERNAME = (Bitmap)Bitmap.FromFile("E://data//skype//username.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("E://data//skype//password.png");
            LOGIN = (Bitmap)Bitmap.FromFile("E://data//skype//login.png");
            LOGINACCOUNT = (Bitmap)Bitmap.FromFile("E://data//skype//loginaccount.png");
            WRONGUSERNAME = (Bitmap)Bitmap.FromFile("E://data//skype//wrongusername.png");
            WRONGPASSWORD = (Bitmap)Bitmap.FromFile("E://data//skype//wrongpassword.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("E://data//skype//loginsuccess.png");
            SETTING = (Bitmap)Bitmap.FromFile("E://data//skype//setting.png");
            LOGOUT = (Bitmap)Bitmap.FromFile("E://data//skype//logout.png");
            OK = (Bitmap)Bitmap.FromFile("E://data//skype//ok.png");
            NOTIFY = (Bitmap)Bitmap.FromFile("E://data//skype//notify.png");
            SIGNIN = (Bitmap)Bitmap.FromFile("E://data//skype//signin.png");
        }


        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseSkype(String deviceID, String noxID)
        {
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.skype.raider ");
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " -package:com.skype.raider");


            int count = 10;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install skype ");
                    KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " \"-apk:D:\\Nox\\apk\\Skype.apk\"");
                    Delay(1);
                    int dem = 30;
                    while (true)
                    {
                        Console.WriteLine("dang doi install");
                        var screen1 = Services.ScreenShoot(deviceID);
                        var loginAccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINACCOUNT);
                        var singinPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, SIGNIN);
                        var loginSuccess = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINSUCCESS);
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
                var LOGINSUCCESSpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);


                if (loginAccountPoint1 != null || signinPoint != null || LOGINSUCCESSpoint != null)

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
        public string login(String deviceID, String username, String password, String noxID)
        {
            while (true)
            {
                var screen2 = Services.ScreenShoot(deviceID);
                var loginAccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, LOGINACCOUNT);
                var signinPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, SIGNIN);
                var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, LOGINSUCCESS);

                if (loginAccountPoint != null || signinPoint1 != null || loginsuccessPoint != null)
                {
                    break;
                }
                else Delay(1);
            }

            if (checkLogin(deviceID) == true)
            {
                Console.WriteLine("da dang nhap");
                Console.WriteLine("doi dang xuat");
                logout(deviceID);
                Exit(deviceID);
                chooseSkype(deviceID, noxID);
                Delay(1);
            }





            var screen = Services.ScreenShoot(deviceID);
            var LOGINACCOUNTpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINACCOUNT);
            if (LOGINACCOUNTpoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, LOGINACCOUNTpoint.Value.X, LOGINACCOUNTpoint.Value.Y);
                Delay(1);
            }

            screen = Services.ScreenShoot(deviceID);
            var signinPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SIGNIN);
            if (signinPoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, signinPoint.Value.X, signinPoint.Value.Y);
                Delay(1);
            }


            while (true)
            {
                Console.WriteLine("nhap tai khoan");
                screen = Services.ScreenShoot(deviceID);
                var USERNAMEpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, USERNAME);
                if (USERNAMEpoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, USERNAMEpoint.Value.X, USERNAMEpoint.Value.Y);
                    KAutoHelper.ADBHelper.InputText(deviceID, username);
                    Delay(1);
                    break;
                }
                Delay(1);
            }


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CONTINUE) == true)
                {
                    Console.WriteLine("click continue");
                    break;
                }
                else
                {
                    Console.WriteLine("khong tim thay nut continue");
                }
            }
            //screen = Services.ScreenShoot(deviceID);
            //var continuePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CONTINUE);
            //if (continuePoint != null)
            //{
            //    KAutoHelper.ADBHelper.Tap(deviceID, continuePoint.Value.X, continuePoint.Value.Y);
            //    Delay(1);
            //}




            var screen1 = Services.ScreenShoot(deviceID);
            var wrongUsernamePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, WRONGUSERNAME);
            if (wrongUsernamePoint != null)
            {
                return "Wrong Username";
            }


            int dem = 3;
            while (true)
            {

                if (dem == 0)
                {

                    Exit(deviceID);
                    return "Wrong Password";
                    break;
                }


                while (true)
                {
                    screen = Services.ScreenShoot(deviceID);
                    var PASSWORDpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PASSWORD);
                    if (PASSWORDpoint != null)
                    {
                        Console.WriteLine("nhap mat khau");
                        KAutoHelper.ADBHelper.Tap(deviceID, PASSWORDpoint.Value.X, PASSWORDpoint.Value.Y);
                        KAutoHelper.ADBHelper.InputText(deviceID, password);
                        Delay(1);
                        break;

                    }
                    else
                    Delay(1);
                }

                
                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, LOGIN) == true)
                    {
                        Console.WriteLine("click login");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("khong tim thay nut login");
                    }
                }
                //screen = Services.ScreenShoot(deviceID);
                //var LOGINpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGIN);
                //if (LOGINpoint != null)
                //{
                //    Console.WriteLine("click login lan 2");
                //    KAutoHelper.ADBHelper.Tap(deviceID, LOGINpoint.Value.X, LOGINpoint.Value.Y);

                //}
                Delay(1);


                var screen2 = Services.ScreenShoot(deviceID);
                var wrongPassWordPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, WRONGPASSWORD);
                if (wrongPassWordPoint != null)
                {
                    dem--;
                }
                else break;

            }
            while (true)
            {
                Boolean isLogin = checkLogin(deviceID);
                if (isLogin == true) break;
            }

            return "Login Success";

        }
        public string logout(String deviceID)
        {

            while (true)
            {
                if(Services.findImage(deviceID,SETTING)== true)
                {
                    Console.WriteLine("click setting");
                    Delay(1);
                    break;
                }
            }
            //var screen = Services.ScreenShoot(deviceID);
            //var SETTINGpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SETTING);
            //if (SETTINGpoint != null)
            //{

            //    KAutoHelper.ADBHelper.Tap(deviceID, SETTINGpoint.Value.X, SETTINGpoint.Value.Y);
            //    Delay(1);
            //}

            while (true)
            {
                if (Services.findImage(deviceID, LOGOUT) == true)
                {
                    Delay(1);
                    Console.WriteLine("click setting");
                    break;
                }
            }
            Delay(5);
            //screen = Services.ScreenShoot(deviceID);
            //var logoutPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGOUT);
            //if (logoutPoint != null)
            //{

            //    KAutoHelper.ADBHelper.Tap(deviceID, logoutPoint.Value.X + 10, logoutPoint.Value.Y + 10);
            //    Thread.Sleep(TimeSpan.FromMilliseconds(5000));
            //}
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
        Boolean checkLogin(String deviceID)
        {

            Boolean isLogin = false;

            Console.WriteLine("kiem tra man hinh dang nhap");
            var screen = Services.ScreenShoot(deviceID);
            var LOGINSUCCESSpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);

            if (LOGINSUCCESSpoint != null)
            {
                isLogin = true;
            }
            Delay(1);
            return isLogin;

        }
    }
}
