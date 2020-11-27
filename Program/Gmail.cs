using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

namespace ToolTest
{
    class Gmail
    {
        #region data
        Bitmap GMAIL;
        Bitmap FB;
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
        Bitmap GOTIT;
        Bitmap GOOGLE;
        #endregion
        public Gmail()
        {
            LoadData();
        }
        void LoadData()
        {
            GMAIL = (Bitmap)Bitmap.FromFile("E://data//gmail//gmail.png");
            GOTIT = (Bitmap)Bitmap.FromFile("E://data//gmail//gotit.png");
            LOGINACCOUNT = (Bitmap)Bitmap.FromFile("E://data//gmail//loginaccount.png");
            GOOGLE = (Bitmap)Bitmap.FromFile("E://data//gmail//google.png");
            
            USERNAME = (Bitmap)Bitmap.FromFile("E://data//gmail//username.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("E://data//facebook//continue.png");

            PASSWORD = (Bitmap)Bitmap.FromFile("E://data//facebook//password.png");
            LOGIN = (Bitmap)Bitmap.FromFile("E://data//facebook//login.png");
            
            WRONGUSERNAME = (Bitmap)Bitmap.FromFile("E://data//facebook//wrongusername.png");
            WRONGPASSWORD = (Bitmap)Bitmap.FromFile("E://data//facebook//wrongpassword.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("E://data//facebook//loginsuccess.png");
            SETTING = (Bitmap)Bitmap.FromFile("E://data//facebook//setting.png");
            LOGOUT = (Bitmap)Bitmap.FromFile("E://data//facebook//logout.png");
            LOGGING = (Bitmap)Bitmap.FromFile("E://data//facebook//logging.png");
            OK = (Bitmap)Bitmap.FromFile("E://data//facebook//OK.png");
            RETRY = (Bitmap)Bitmap.FromFile("E://data//facebook//retry.png");
            LOGINFAILED = (Bitmap)Bitmap.FromFile("E://data//facebook//loginfailed.png");
            NEEDCODE = (Bitmap)Bitmap.FromFile("E://data//facebook//needcode.png");
            CODE = (Bitmap)Bitmap.FromFile("E://data//facebook//code.png");
            SAVEINFO = (Bitmap)Bitmap.FromFile("E://data//facebook//saveinfo.png");
        }
        public void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseFacebook(String deviceID)
        {
            while (true)
            {
                var screen = Services.ScreenShoot(deviceID, false);
                var FBpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, FB);
                if (FBpoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, FBpoint.Value.X, FBpoint.Value.Y);
                    Delay(2);
                    return "Open FaceBook Success";
                }
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 90, 50, 10, 50);
                Delay(1);
            }

        }
        public string login(String deviceID, String username, String password)
        {
            String result = "";
            while (true)
            {
                var screen1 = Services.ScreenShoot(deviceID);
                var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINSUCCESS);
                var loginAccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINACCOUNT);
                var usernamePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, USERNAME);

                if (loginsuccessPoint != null || loginAccountPoint != null || usernamePoint != null)
                {
                    break;
                }
                else Delay(1);


            }
            if (checkLogin(deviceID) == true)
            {
                return "Already Login";
            }

            var screen = Services.ScreenShoot(deviceID);
            var LOGINACCOUNTpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINACCOUNT);
            if (LOGINACCOUNTpoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, LOGINACCOUNTpoint.Value.X, LOGINACCOUNTpoint.Value.Y);

            }
            Delay(1);
            int dem = 3;
            while (true)
            {
                if (dem < 3)
                {
                    screen = Services.ScreenShoot(deviceID);
                    var PASSWORDpoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PASSWORD);
                    if (PASSWORDpoint1 != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, PASSWORDpoint1.Value.X, PASSWORDpoint1.Value.Y);
                        KAutoHelper.ADBHelper.InputText(deviceID, password);
                    }
                    Delay(1);
                }
                if (dem == 3)
                {
                    screen = Services.ScreenShoot(deviceID);
                    var USERNAMEpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, USERNAME);
                    if (USERNAMEpoint != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, USERNAMEpoint.Value.X, USERNAMEpoint.Value.Y);
                        KAutoHelper.ADBHelper.InputText(deviceID, username);
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 46.5, 5.0);
                    }
                    Delay(1);

                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 50, 10);
                }

                screen = Services.ScreenShoot(deviceID);
                var PASSWORDpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PASSWORD);
                if (PASSWORDpoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, PASSWORDpoint.Value.X, PASSWORDpoint.Value.Y);
                    KAutoHelper.ADBHelper.InputText(deviceID, password);
                }
                Delay(1);



                screen = Services.ScreenShoot(deviceID);
                var LOGINpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGIN);
                if (LOGINpoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, LOGINpoint.Value.X, LOGINpoint.Value.Y);

                }
                Delay(1);

                //ĐỢI LOGIN
                Boolean logging = true;
                while (logging)
                {
                    Console.WriteLine("dang doi dang nhap");
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
                // LỖI SAI TK, TẮT APP
                if (WrongUserPoint != null)
                {
                    Exit(deviceID);
                    return "Wrong Username";
                }

                // LỖI SAI MK, NHẬP LẠI MK
                if (WrongPassWordPoint != null)
                {
                    var Okpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, OK);
                    KAutoHelper.ADBHelper.Tap(deviceID, Okpoint.Value.X, Okpoint.Value.Y);
                    Delay(1);
                    dem--;
                }
                if (WrongPassWordPoint != null && dem == 0)
                {
                    return "Wrong Password";
                }
                if (WrongUserPoint == null || WrongPassWordPoint == null)
                {
                    return "Need Code";
                }
            }
            return result;

        }
        public string logout(String deviceID)
        {

            var screen = Services.ScreenShoot(deviceID);
            var SETTINGpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SETTING);
            if (SETTINGpoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, SETTINGpoint.Value.X, SETTINGpoint.Value.Y);

            }
            Delay(1);

            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 50, 90, 50, 10);
            Delay(1);

            screen = Services.ScreenShoot(deviceID);
            var LOGOUTpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGOUT);

            if (SETTINGpoint != null)
            {

                KAutoHelper.ADBHelper.Tap(deviceID, LOGOUTpoint.Value.X, LOGOUTpoint.Value.Y);

            }
            Delay(1);
            Exit(deviceID);
            return "Logout Success";


        }
        public string Exit(String deviceID)
        {

            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
            Delay(1);
            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 50, 50, 10, 50);
            Delay(1);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            Delay(5);

            return "Exit Success";

        }


        Boolean checkLogin(String deviceID)
        {
            Boolean isLogin = false;




            var screen = Services.ScreenShoot(deviceID);
            var SAVEINFOpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SAVEINFO);
            if (SAVEINFOpoint != null)
            {

                var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, OK);

                Console.WriteLine(point.Value.X);
                KAutoHelper.ADBHelper.Tap(deviceID, point.Value.X, point.Value.Y);
                Delay(1);

            }

            screen = Services.ScreenShoot(deviceID);
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
