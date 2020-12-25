using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class Twitter
    {
        #region data
        Bitmap TWITTER;
        Bitmap LOGINACCOUNT;
        Bitmap USERNAME;
        Bitmap PASSWORD;
        Bitmap LOGIN;
        Bitmap NEEDCODE;
        Bitmap LOGGING;
        Bitmap CODE;
        Bitmap LOGIN2;
        Bitmap LOGINSUCCESS;
        Bitmap SETTING;
        Bitmap SETTING2;
        Bitmap ACCOUNT;
        Bitmap LOGOUT;
        Bitmap OK;
        Bitmap WRONGCODE;


        #endregion
        public Twitter()
        {
            LoadData();
        }
        void LoadData()
        {
            TWITTER = (Bitmap)Bitmap.FromFile("E://data//twitter//twitter.png");
            LOGINACCOUNT = (Bitmap)Bitmap.FromFile("E://data//twitter//loginaccount.png");
            USERNAME = (Bitmap)Bitmap.FromFile("E://data//twitter//username.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("E://data//twitter//password.png");
            LOGIN = (Bitmap)Bitmap.FromFile("E://data//twitter//login.png");
            LOGGING = (Bitmap)Bitmap.FromFile("E://data//twitter//logging.png");
            NEEDCODE = (Bitmap)Bitmap.FromFile("E://data//twitter//needcode.png");
            CODE = (Bitmap)Bitmap.FromFile("E://data//twitter//code.png");
            LOGIN2 = (Bitmap)Bitmap.FromFile("E://data//twitter//login2.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("E://data//twitter//loginsuccess.png");
            SETTING = (Bitmap)Bitmap.FromFile("E://data//twitter//setting.png");
            SETTING2 = (Bitmap)Bitmap.FromFile("E://data//twitter//setting2.png");
            ACCOUNT = (Bitmap)Bitmap.FromFile("E://data//twitter//account.png");
            LOGOUT = (Bitmap)Bitmap.FromFile("E://data//twitter//logout.png");
            OK = (Bitmap)Bitmap.FromFile("E://data//twitter//ok.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("E://data//twitter//wrongcode.png");
            

        }


        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseTwitter(String deviceID, String noxID)
        {
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.twitter.android ");
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " -package:com.twitter.android");


            int count = 20;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install twitter ");
                    KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " \"-apk:D:\\Nox\\apk\\twitter.apk\"");
                    Delay(1);
                    int dem = 30;
                    while (true)
                    {
                        Console.WriteLine("dang doi install");
                        var screen1 = Services.ScreenShoot(deviceID);
                        var whatsappPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, TWITTER);

                        if (whatsappPoint != null)
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
                    return "Open Twitter Success";
                }
                var screen = Services.ScreenShoot(deviceID);

                var whatsappPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, TWITTER);



                if (whatsappPoint1 != null)

                {
                    return "Open Twitter Success";

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
                chooseTwitter(deviceID, noxID);
                Delay(1);
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, LOGINACCOUNT) == true)
                {
                    Console.WriteLine("click LOGIN ACCOUNT");
                    Delay(1);
                    break;
                }
            }
            while (true)
            {
                Delay(1);
                var screen1 = Services.ScreenShoot(deviceID);
                var usernamePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, USERNAME);
                if(usernamePoint!= null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, usernamePoint.Value.X, (usernamePoint.Value.Y + 60));
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID,username);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi usenarme");
                }
            }

            while (true)
            {
                Delay(1);
                var screen1 = Services.ScreenShoot(deviceID);
                var passwordPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, PASSWORD);
                if(passwordPoint!= null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, passwordPoint.Value.X, (passwordPoint.Value.Y + 60));
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, password);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi password");
                }
            }


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, LOGIN) == true)
                {
                    Console.WriteLine("click LOGIN");
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("khong tim thay login");
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, LOGGING) == true)
                {
                    Console.WriteLine("DANG LOGGING");
                 
                }
                else
                {
                    Console.WriteLine("loging xong");
                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, NEEDCODE) == true)
                {
                    Console.WriteLine("click NEEDCODE");
                    Delay(1);
                    return "Need Code";
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi need code");
                }
            }

            return "Need Code";

        }
        public String inputCode(String deviceID, String simID)
        {

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CODE) == true)
                {
                    Console.WriteLine("click code");
                    Delay(1);
                    break;
                }
                else Console.WriteLine("khong tim thay nut SMS");

            }



            int dem = 80;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0) break;
                code = MessageDAO.getCodeViper(simID, MessageDAO.FBsql);
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
                    Console.WriteLine("click code");
                    Delay(5);
                    KAutoHelper.ADBHelper.InputText(deviceID, code);
                    Delay(2);
                    break;
                }
                else Console.WriteLine("khong tim thay nut code");

            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, LOGIN2) == true)
                {
                    Console.WriteLine("click login");
                    break;
                }
                
            }

            while (true)
            {
                Delay(1);
                var screen = Services.ScreenShoot(deviceID);
                var wrongcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGCODE);
                var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                if (wrongcodePoint != null)
                {
                    Delay(1);
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, CODE) == true)
                        {
                            Console.WriteLine("click CODE");
                            Delay(2);
                            KAutoHelper.ADBHelper.InputText(deviceID, code);
                            Delay(2);
                            break;
                        }
                        else Console.WriteLine("khong tim thay nut code");

                    }


                    while (true)
                    {
                        var screen1 = Services.ScreenShoot(deviceID);
                        var wrongcodePoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, WRONGCODE);
                        var loginsuccessPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINSUCCESS);
                        if (wrongcodePoint1 != null)
                        {
                            return "Wrong Auth Code";
                        }
                        if (loginsuccessPoint1 != null)
                        {
                            return "Login Success";
                        }
                    }

                }
                
                if (loginsuccessPoint != null)
                {
                    return "Login Success";
                }
            }


            return "";
        }
        public string logout(String deviceID)
        {

            while (true)
            {
                Delay(1);
                if(Services.findImage(deviceID,SETTING) == true)
                {
                    Console.WriteLine("click setting");
                    break;
                }
                else
                {
                    Console.WriteLine("khong tim thay setting");
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SETTING2) == true)
                {
                    Console.WriteLine("click setting and");
                    break;
                }
                else
                {
                    Console.WriteLine("khong tim thay setting");
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, ACCOUNT) == true)
                {
                    Console.WriteLine("click account");
                    Delay(1);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 300, 1000, 300, 750);
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("khong tim thay account");
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, LOGOUT) == true)
                {
                    Console.WriteLine("click LOUGOUT and");
                    break;
                }
                else
                {
                    Console.WriteLine("khong tim thay LOGOUT");
                }

            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, OK) == true)
                {
                    Console.WriteLine("click ok");
                    break;
                }
                else
                {
                    Console.WriteLine("khong tim thay OK");
                }
            }
            while (true)
            {
                Delay(1);
                if(Services.findImage(deviceID,TWITTER) == true)
                {
                    break;
                }
            }
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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.twitter.android ");
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
