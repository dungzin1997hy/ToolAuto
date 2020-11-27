using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using Emgu.CV.CvEnum;
using Tesseract;
using System.IO;

namespace ToolTest
{
    class Tiktok
    {
        #region data
        Bitmap TIKTOK;
        Bitmap LIKE;
        Bitmap CONTINUE;
        Bitmap LOGIN;
        Bitmap LOGINACCOUNT;
        Bitmap LOGINSUCCESS;
        Bitmap NEEDCODE;
        Bitmap SETTING;
        Bitmap LOGOUTICON;
        Bitmap ME;
        Bitmap LOGOUT;
        Bitmap NOTNOW;
        Bitmap ADDACCOUNT;
        #endregion

        public Tiktok()
        {
            LoadData();
        }
        void LoadData()
        {
            TIKTOK = (Bitmap)Bitmap.FromFile("E://data//tiktok//tiktok.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("E://data//tiktok//continue.png");
            LOGIN = (Bitmap)Bitmap.FromFile("E://data//tiktok//login.png");
            LOGINACCOUNT = (Bitmap)Bitmap.FromFile("E://data//tiktok//loginaccount.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("E://data//tiktok//loginsuccess.png");
            SETTING = (Bitmap)Bitmap.FromFile("E://data//tiktok//setting.png");
            LOGOUT = (Bitmap)Bitmap.FromFile("E://data//tiktok//logouticon.png");
            ME = (Bitmap)Bitmap.FromFile("E://data//tiktok//me.png");
            LOGOUT = (Bitmap)Bitmap.FromFile("E://data//tiktok//logout.png");
            LOGOUTICON = (Bitmap)Bitmap.FromFile("E://data//tiktok//logouticon.png");
            NEEDCODE = (Bitmap)Bitmap.FromFile("E://data//tiktok//needcode.png");
            NOTNOW = (Bitmap)Bitmap.FromFile("E://data//tiktok//notnow.png");
            ADDACCOUNT = (Bitmap)Bitmap.FromFile("E://data//tiktok//addaccount.png");

        }

        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
            }
        }
        public string chooseTiktok(String deviceID)
        {

            while (true)
            {
                var screen = Services.ScreenShoot(deviceID);
                var loginSuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                if (loginSuccessPoint != null)
                {

                    return "Open TikTok Success";
                }
                screen = Services.ScreenShoot(deviceID);
                var tiktokPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, TIKTOK);
                if (tiktokPoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, tiktokPoint.Value.X, tiktokPoint.Value.Y);
                    while (true)
                    {
                        screen = Services.ScreenShoot(deviceID);
                        loginSuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                        if (loginSuccessPoint != null)
                        {
                            Delay(1);
                            return "Open TikTok Success";
                        }
                        else
                        {
                            Delay(1);
                        }
                    }
                    break;
                }
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 90, 50, 10, 50);
                Delay(1);
            }
        }
        public string login(String deviceID, String username)
        {

            KAutoHelper.ADBHelper.Tap(deviceID, 700, 1200);
            Delay(1);


            var screen = Services.ScreenShoot(deviceID);
            var loginPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGIN);
            if (loginPoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, loginPoint.Value.X, loginPoint.Value.Y);

            }
            Delay(5);

            screen = Services.ScreenShoot(deviceID);
            var addAccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ADDACCOUNT);
            if (addAccountPoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, addAccountPoint.Value.X, addAccountPoint.Value.Y);
                Delay(1);
            }

            screen = Services.ScreenShoot(deviceID);
            var loginAccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINACCOUNT);
            if (loginAccountPoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, loginAccountPoint.Value.X, loginAccountPoint.Value.Y);
                Delay(2);
            }


            KAutoHelper.ADBHelper.InputText(deviceID, username);
            Delay(1);




            screen = Services.ScreenShoot(deviceID);
            var continuePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CONTINUE);
            if (continuePoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, continuePoint.Value.X, continuePoint.Value.Y);
                Delay(1);
            }
            int dem = 10;
            while (true)
            {
                if (dem == 0) break;
                screen = Services.ScreenShoot(deviceID);
                var needcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, NEEDCODE);
                if (needcodePoint != null)
                {
                    return "Need code";
                    break;
                }
                else
                {
                    Delay(1);
                    dem--;

                }
            }
            return "Login Failed";
        }
        public string logout(String deviceID)
        {

            KAutoHelper.ADBHelper.Tap(deviceID, 700, 1200);
            Delay(1);

            var screen = Services.ScreenShoot(deviceID);
            var settingPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SETTING);
            if (settingPoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, settingPoint.Value.X, settingPoint.Value.Y);
                Delay(1);
            }


            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 50, 90, 50, 10);
            Delay(1);

            screen = Services.ScreenShoot(deviceID);
            var logoutIconPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGOUTICON);
            if (logoutIconPoint != null)
            {

                KAutoHelper.ADBHelper.Tap(deviceID, logoutIconPoint.Value.X + 10, logoutIconPoint.Value.Y + 10);
                Thread.Sleep(TimeSpan.FromMilliseconds(300));

            }
            else
            {
                Exit(deviceID);
                return "Already Logout";
            }
            screen = Services.ScreenShoot(deviceID);
            var notnowPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, NOTNOW);
            if (notnowPoint != null)
            {

                KAutoHelper.ADBHelper.Tap(deviceID, notnowPoint.Value.X, notnowPoint.Value.Y);
                Thread.Sleep(TimeSpan.FromMilliseconds(1000));

            }
            screen = Services.ScreenShoot(deviceID);
            var logoutPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGOUT);
            if (logoutPoint != null)
            {

                KAutoHelper.ADBHelper.Tap(deviceID, logoutPoint.Value.X, logoutPoint.Value.Y);
                Thread.Sleep(TimeSpan.FromMilliseconds(1000));
                return "Logout Success";
            }
            Exit(deviceID);
            return "Logout Failed";

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
