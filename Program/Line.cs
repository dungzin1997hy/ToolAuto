using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class Line


    {
        #region data
        Bitmap LINE;
        Bitmap LOGIN;
        Bitmap LOGINPHONE;
        Bitmap PHONENUMBER;
        Bitmap NEXT;
        Bitmap OK;
        Bitmap WRONGUSERNAME;
        Bitmap NEEDCODE;
        Bitmap WRONGCODE;
        Bitmap YESACCOUNT;
        Bitmap PASSWORD;
        Bitmap SKIP;
        Bitmap CONTINUE;
        Bitmap LOGINSUCCESS;



        #endregion
        public Line()
        {
            LoadData();
        }
        void LoadData()
        {
            LINE = (Bitmap)Bitmap.FromFile("E://data//line//line.png");
            LOGIN = (Bitmap)Bitmap.FromFile("E://data//line//login.png");
            LOGINPHONE = (Bitmap)Bitmap.FromFile("E://data//line//loginphone.png");
            PHONENUMBER = (Bitmap)Bitmap.FromFile("E://data//line//phonenumber.png");
            NEXT = (Bitmap)Bitmap.FromFile("E://data//line//next.png");
            OK = (Bitmap)Bitmap.FromFile("E://data//line//ok.png");
            WRONGUSERNAME = (Bitmap)Bitmap.FromFile("E://data//line//wrongusername.png");
            NEEDCODE = (Bitmap)Bitmap.FromFile("E://data//line//needcode.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("E://data//line//wrongcode.png");
            YESACCOUNT = (Bitmap)Bitmap.FromFile("E://data//line//yesaccount.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("E://data//line//password.png");
            SKIP = (Bitmap)Bitmap.FromFile("E://data//line//skip.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("E://data//line//continue.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("E://data//line//loginsuccess.png");


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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear jp.naver.line.android ");
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " -package:jp.naver.line.android");


            int count = 20;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install line ");
                    KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " \"-apk:D:\\Nox\\apk\\line.apk\"");
                    Delay(1);
                    int dem = 30;
                    while (true)
                    {
                        Console.WriteLine("dang doi install");
                        var screen1 = Services.ScreenShoot(deviceID);
                        var whatsappPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LINE);

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
                    return "Open Line Success";
                }
                var screen = Services.ScreenShoot(deviceID);
                var whatsappPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LINE);
                if (whatsappPoint1 != null)

                {
                    return "Open Line Success";

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
                Delay(1);
                if (Services.findImage(deviceID, LOGIN) == true)
                {
                    Console.WriteLine("click login");
                    Delay(1);
                    break;
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, LOGINPHONE) == true)
                {
                    Console.WriteLine("click phonenumber");
                    Delay(1);
                   
                    break;
                }
            }

            Delay(1);
            
            while (true)
            {
                var screen = Services.ScreenShoot(deviceID);
                var phoneNumberPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PHONENUMBER);
                if (phoneNumberPoint == null)
                {
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
                   
                }
                else
                {
                    Console.WriteLine("delete het");
                    break;
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PHONENUMBER) == true)
                {
                    Console.WriteLine("click phonenumber");
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, username);
                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, NEXT) == true)
                {
                    Console.WriteLine("click next");
                    Delay(1);
                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, OK) == true)
                {
                    Console.WriteLine("click ok");
                    Delay(1);
                    break;
                }
            }


            while (true)
            {
                Delay(1);
                var screen = Services.ScreenShoot(deviceID);
                var wrongusernamePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGUSERNAME);
                var needcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, NEEDCODE);
                if (wrongusernamePoint != null)
                {
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, OK) == true)
                        {
                            Console.WriteLine("click ok");
                            Delay(1);
                            break;
                        }
                    }

                    while (true)
                    {
                        Delay(1);
                        var screen1 = Services.ScreenShoot(deviceID);
                        var phoneNumberPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PHONENUMBER);
                        if (phoneNumberPoint == null)
                        {
                            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);

                        }
                        else
                        {
                            break;
                        }
                        Thread.Sleep(TimeSpan.FromMilliseconds(100));
                    }


                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, PHONENUMBER) == true)
                        {
                            Console.WriteLine("click phonenumber");
                            Delay(1);
                            KAutoHelper.ADBHelper.InputText(deviceID, username);
                            break;
                        }
                    }

                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, NEXT) == true)
                        {
                            Console.WriteLine("click next");
                            Delay(1);
                            break;
                        }
                    }

                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, OK) == true)
                        {
                            Console.WriteLine("click ok");
                            Delay(1);
                            break;
                        }
                    }
                    while (true)
                    {
                        Delay(1);
                        var screen2 = Services.ScreenShoot(deviceID);
                        var needcodePoint2 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, NEEDCODE);
                        var wrongusernamePoint2 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, WRONGUSERNAME);
                        if (needcodePoint2 != null)
                        {
                            return "Need Code";
                        }
                        if(wrongusernamePoint2!= null)
                        {
                            return "Wrong username";
                        }

                    }

                }
                if(needcodePoint!= null)
                {
                    return "Need Code";
                }

            }
            return "Need Code";

        }
        public String inputCode(String deviceID, String simID)
        {
            int dem = 80;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0) break;
                code = MessageDAO.getCodeLine(simID, MessageDAO.FBsql);
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
                code = MessageDAO.getCodeLine(simID, "");
                Console.WriteLine("Code: " + code);
                if (code.Equals("") || code == null)
                {
                    return "Dont have Auth code";
                }

            }

            Delay(1);
            KAutoHelper.ADBHelper.InputText(deviceID, code);
            Delay(1);

            while (true)
            {
                Delay(1);
                var screen = Services.ScreenShoot(deviceID);
                var wrongcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGCODE);
                var yesaccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, YESACCOUNT);
                var skippoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SKIP);
                if (wrongcodePoint != null)
                {
                    Delay(1);
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, OK) == true)
                        {
                            Console.WriteLine("click OK");
                            Delay(2);
                            for(int i = 0; i <= 10; i++)
                            {
                                KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
                                Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            }
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
                        var yesaccountPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, YESACCOUNT);
                        var skippoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, SKIP);
                        if (wrongcodePoint1 != null)
                        {
                            return "Wrong Auth Code";
                        }
                       
                        if (yesaccountPoint1 != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, yesaccountPoint1.Value.X, yesaccountPoint1.Value.Y);
                            Delay(1);
                            while (true)
                            {
                                Delay(1);
                                if (Services.findImage(deviceID, PASSWORD) == true)
                                {
                                    break;
                                }
                            }
                            return "Input Password";
                        }
                        if(skippoint!= null)
                        {
                            Delay(1);
                            KAutoHelper.ADBHelper.Tap(deviceID, skippoint.Value.X, skippoint.Value.Y);
                            Delay(1);

                            //while (true)
                            //{
                            //    Delay(1);
                            //    if (Services.findImage(deviceID, CONTINUE) == true)
                            //    {
                            //        Console.WriteLine("click continue");
                            //        break;
                            //    }
                            //}

                            while (true)
                            {
                                Delay(1);
                                if (Services.findImage(deviceID, NEXT) == true)
                                {
                                    break;
                                }
                            }

                            while (true)
                            {
                                Delay(1);
                                var screen3 = Services.ScreenShoot(deviceID);
                                var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen3, LOGINSUCCESS);
                                if (loginsuccessPoint != null)
                                {
                                    return "Login Success";
                                }
                            }
                        }
                    }

                }
                if (yesaccountPoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, yesaccountPoint.Value.X, yesaccountPoint.Value.Y);

                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, PASSWORD) == true)
                        {
                            break;
                        }
                    }
                    return "Input Password";
                }
                if(skippoint1!= null)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, skippoint1.Value.X, skippoint1.Value.Y);
                    Delay(1);

                    

                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, NEXT) == true)
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        Delay(1);
                        var screen3 = Services.ScreenShoot(deviceID);
                        var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen3, LOGINSUCCESS);
                        if (loginsuccessPoint != null)
                        {
                            return "Login Success";
                        }
                    }
                }
               
            }


            return "";
        }
        public string inputPassword(String deviceID,String password)
        {
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PASSWORD) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, password);
                    break;
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, NEXT) == true)
                {
                    Delay(1);
                    break;
                }
            }


            while (true)
            {
                var screen = Services.ScreenShoot(deviceID);
                var skipPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SKIP);
                var loginSuccess = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                if(skipPoint!= null)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, skipPoint.Value.X, skipPoint.Value.Y);
                    Delay(1);

                    while (true)
                    {
                        Delay(1);
                        if(Services.findImage(deviceID,CONTINUE) == true)
                        {
                            Console.WriteLine("click continue");
                            break;
                        }
                    }

                    while (true)
                    {
                        Delay(1);
                        if(Services.findImage(deviceID,NEXT) == true)
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        Delay(1);
                        var screen3 = Services.ScreenShoot(deviceID);
                        var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen3, LOGINSUCCESS);
                        if(loginsuccessPoint!= null)
                        {
                            return "Login Success";
                        }
                    }
                }
                if(loginSuccess!= null)
                {
                    return "Login Success";
                }
            }
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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear jp.naver.line.android ");
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
