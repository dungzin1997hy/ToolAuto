using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

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
        Bitmap SMS;
        Bitmap PHONENUMBER;
        Bitmap SENDCODE;
        Bitmap ENTERCODE;
        Bitmap VERIFY;
        Bitmap WRONGCODE;
        #endregion
        public Skype()
        {
            LoadData();
        }
        void LoadData()
        {
            SKYPE = (Bitmap)Bitmap.FromFile("C://data//skype//skype.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("C://data//skype//continue.png");
            USERNAME = (Bitmap)Bitmap.FromFile("C://data//skype//username.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("C://data//skype//password.png");
            LOGIN = (Bitmap)Bitmap.FromFile("C://data//skype//login.png");
            LOGINACCOUNT = (Bitmap)Bitmap.FromFile("C://data//skype//loginaccount.png");
            WRONGUSERNAME = (Bitmap)Bitmap.FromFile("C://data//skype//wrongusername.png");
            WRONGPASSWORD = (Bitmap)Bitmap.FromFile("C://data//skype//wrongpassword.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("C://data//skype//loginsuccess.png");
            SETTING = (Bitmap)Bitmap.FromFile("C://data//skype//setting.png");
            LOGOUT = (Bitmap)Bitmap.FromFile("C://data//skype//logout.png");
            OK = (Bitmap)Bitmap.FromFile("C://data//skype//ok.png");
            NOTIFY = (Bitmap)Bitmap.FromFile("C://data//skype//notify.png");
            SIGNIN = (Bitmap)Bitmap.FromFile("C://data//skype//signin.png");
            NEEDCODE = (Bitmap)Bitmap.FromFile("C://data//skype//needcode.png");
            SMS = (Bitmap)Bitmap.FromFile("C://data//skype//sms.png");
            PHONENUMBER = (Bitmap)Bitmap.FromFile("C://data//skype//phonenumber.png");
            SENDCODE = (Bitmap)Bitmap.FromFile("C://data//skype//sendcode.png");
            ENTERCODE = (Bitmap)Bitmap.FromFile("C://data//skype//entercode.png");
            CODE = (Bitmap)Bitmap.FromFile("C://data//skype//code.png");
            VERIFY = (Bitmap)Bitmap.FromFile("C://data//skype//verify.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("C://data//skype//wrongcode.png");
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




            while (true)
            {
                var screen = Services.ScreenShoot(deviceID);
                var LOGINACCOUNTpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINACCOUNT);
                if (LOGINACCOUNTpoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, LOGINACCOUNTpoint.Value.X, LOGINACCOUNTpoint.Value.Y);
                    Delay(1);
                    break;
                }

                screen = Services.ScreenShoot(deviceID);
                var signinPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SIGNIN);
                if (signinPoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, signinPoint.Value.X, signinPoint.Value.Y);
                    Delay(1);
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("nhap tai khoan");
                var screen = Services.ScreenShoot(deviceID);
                var USERNAMEpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, USERNAME);
                if (USERNAMEpoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, USERNAMEpoint.Value.X, USERNAMEpoint.Value.Y);
                    Delay(1);
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
                    var screen = Services.ScreenShoot(deviceID);
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
                Delay(1);
                var screen = Services.ScreenShoot(deviceID);
                var loginSuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                var needcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, NEEDCODE);
                if(loginSuccessPoint!= null)
                {
                    return "Login Success";

                }
                if(needcodePoint!= null)
                {
                    return "Need Code";
                }
            }

        }
        public String inputCode(String deviceID,String phoneNumber,String simID)
        {

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SMS) == true)
                {
                    Console.WriteLine("click SMS");
                    Delay(1);
                    break;
                }
                else Console.WriteLine("khong tim thay nut SMS");

            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PHONENUMBER) == true)
                {
                    Console.WriteLine("click phonenumber");
                    Delay(1);
                    int length = phoneNumber.Length;
                    String phone = phoneNumber.Substring(length - 4, 4);
                    KAutoHelper.ADBHelper.InputText(deviceID, phone);
                    Delay(1);
                    break;
                }
                else Console.WriteLine("khong tim thay phoneNumber");
            }


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SENDCODE) == true)
                {
                    Console.WriteLine("click sendcode");
                    Delay(1);
                    break;
                }
                else Console.WriteLine("khong tim thay nut sendcode");

            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, ENTERCODE) == true)
                {
                    Console.WriteLine("click ETER CODE");
                    Delay(1);
                    break;
                }
                else Console.WriteLine("khong tim thay nut sendcode");

            }



            int dem = 80;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0) break;
                code = MessageDAO.getCodeSkype(simID, MessageDAO.FBsql);
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
                code = MessageDAO.getCodeSkype(simID, "");
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
                if (Services.findImage(deviceID, VERIFY) == true)
                {
                    Console.WriteLine("click continue");
                    Delay(5);
                    break;
                }
                else Console.WriteLine("khong tim thay nut continue");
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
                        if (Services.findImage(deviceID, VERIFY) == true)
                        {
                            Console.WriteLine("click continue");
                            Delay(5);
                            break;
                        }
                        else Console.WriteLine("khong tim thay nut continue");
                    }

                    while (true)
                    {
                        var screen1 = Services.ScreenShoot(deviceID);
                        var wrongcodePoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, WRONGCODE);
                        var loginsuccessPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINSUCCESS);
                        if(wrongcodePoint1!= null)
                        {
                            return "Wrong Auth Code";
                        }
                        if(loginsuccessPoint1!= null)
                        {
                            return "Login Success";
                        }
                    }

                }
                if (loginsuccessPoint != null)
                {
                    Delay(1);
                    return "Login Success";
                }
            }


            return "";
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
