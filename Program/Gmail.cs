using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class Gmail
    {
        #region data
        Bitmap firefox;
        Bitmap address;
        Bitmap opensuccess;
        Bitmap loginaccount;
        Bitmap username;
        Bitmap CONTINUE;
        Bitmap WRONGUSERNAME;
        Bitmap INPUTPASSWORD;
        Bitmap PASSWORD;
        Bitmap SAVEPASSWORD;
        Bitmap WRONGPASSWORD;
        Bitmap INPUTCODE;
        Bitmap TRYOTHERWAY;
        Bitmap MESSAGE;
        Bitmap CODE;
        Bitmap WRONGCODE;
        Bitmap LOGINSUCCESS;
        Bitmap TOOMUCH;
        #endregion
        public Gmail()
        {
            LoadData();
        }
        void LoadData()
        {
            firefox = (Bitmap)Bitmap.FromFile("E://data//gmail//firefox.png");
            address = (Bitmap)Bitmap.FromFile("E://data//gmail//address.png");
            opensuccess = (Bitmap)Bitmap.FromFile("E://data//gmail//opensuccess.png");
            loginaccount = (Bitmap)Bitmap.FromFile("E://data//gmail//loginaccount.png");
            username = (Bitmap)Bitmap.FromFile("E://data//gmail//username.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("E://data//gmail//continue.png");
            WRONGUSERNAME = (Bitmap)Bitmap.FromFile("E://data//gmail//wrongusername.png");
            INPUTPASSWORD = (Bitmap)Bitmap.FromFile("E://data//gmail//inputpassword.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("E://data//gmail//password.png");
            SAVEPASSWORD = (Bitmap)Bitmap.FromFile("E://data//gmail//savepassword.png");
            WRONGPASSWORD = (Bitmap)Bitmap.FromFile("E://data//gmail//wrongpassword.png");
            INPUTCODE = (Bitmap)Bitmap.FromFile("E://data//gmail//inputcode.png");
            TRYOTHERWAY = (Bitmap)Bitmap.FromFile("E://data//gmail//tryotherway.png");
            MESSAGE = (Bitmap)Bitmap.FromFile("E://data//gmail//message.png");
            CODE = (Bitmap)Bitmap.FromFile("E://data//gmail//code.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("E://data//gmail//wrongcode.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("E://data//gmail//loginsuccess.png");
            TOOMUCH = (Bitmap)Bitmap.FromFile("E://data//gmail//toomuch.png");

          

        }
        public void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseFireFox(String deviceID, String noxID)
        {
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear org.mozilla.firefox ");
            Delay(3);
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " -package:org.mozilla.firefox");
            Console.WriteLine("adb -s " + deviceID + " shell pm clear org.mozilla.firefox ");
            int count = 20;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install firefox ");
                    KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " \"-apk:D:\\Nox\\apk\\firefox.apk\"");
                    Delay(1);
                    int dem = 30;
                    while (true)
                    {
                        var screen1 = Services.ScreenShoot(deviceID);
                        var firefoxPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, firefox);
                        

                        if (firefoxPoint != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, firefoxPoint.Value.X, firefoxPoint.Value.Y);
                            Delay(1);
                            break;
                        }
                        else
                        {
                            dem--;
                            Delay(1);
                        }
                        if(dem == 0)
                        {
                            Console.WriteLine("loi app");
                            return "Open App Error";
                        }

                    }
                    return "Open FireFox Success";
                }
                var screen = Services.ScreenShoot(deviceID);
                var firefoxP = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, firefox);
                

                if (firefoxP != null)
                {
                    return "Open FireFox Success";

                }
                else
                {
                    Delay(1);
                    count--;
                }
            }

        }

        public string chooseGmail(String deviceID)
        {
            while (true)
            {
                Delay(1);
                var screen = Services.ScreenShoot(deviceID);
                var addressPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, address);
                if(addressPoint!= null)
                {
                    Console.WriteLine("click o dia chi");
                    KAutoHelper.ADBHelper.Tap(deviceID, addressPoint.Value.X, addressPoint.Value.Y);
                    Delay(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, addressPoint.Value.X, addressPoint.Value.Y);
                    Delay(1);
                    Delay(7);
                    Console.WriteLine("nhap gmail");
                    KAutoHelper.ADBHelper.InputText(deviceID, "gmail.com");
                    Delay(1);
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                    Delay(2);
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("ngoif doi");
                Delay(1);
                var screen = Services.ScreenShoot(deviceID);
                var opensuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, opensuccess);
                var loginaccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, opensuccess);
                if(opensuccessPoint!= null)
                {
                    break;
                }
                if(loginaccountPoint!= null)
                {
                    Console.WriteLine("click dang nhap");
                    KAutoHelper.ADBHelper.Tap(deviceID, loginaccountPoint.Value.X, loginaccountPoint.Value.Y);
                    Delay(1);
                    while (Services.findImage(deviceID, opensuccess) == false)
                    {
                        Delay(1);
                    }
                    break;

                }
            }

            KAutoHelper.ADBHelper.Tap(deviceID, 300, 1000);
            Delay(1);

            return "Open Gmail Success";



        }

        public string login(String deviceID, String name, String password, String noxID)
        {
           
            if (checkLogin(deviceID) == true)
            {
                Console.WriteLine("da dang nhap");
                Console.WriteLine("doi dang xuat");
                logout(deviceID);
                Exit(deviceID);
                chooseFireFox(deviceID, noxID);
                chooseGmail(deviceID);
                Delay(1);
            }

            
            Delay(1);
            int dem = 3;
            while (true)
            {
                if (dem < 3)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, 300, 1000);
                    Delay(1);
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, PASSWORD) == true)
                        {
                            Console.WriteLine("click password");
                            break;
                        }
                        else Console.WriteLine("khong tim thay nut password");
                    }
                    KAutoHelper.ADBHelper.InputText(deviceID, password);
                    Delay(1);
                }
                if (dem == 3)
                {
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, username) == true)
                        {

                            Console.WriteLine("click username");
                            Delay(1);
                            KAutoHelper.ADBHelper.InputText(deviceID, name);
                            Delay(1);
                            break;
                        }
                        else Console.WriteLine("khong tim thay nut username");
                    }
                    Services.findImage(deviceID, username);
                    while (true)
                    {
                        Delay(1);
                        if(Services.findImage(deviceID,CONTINUE) == true)
                        {
                            Console.WriteLine("click continue username");
                            Delay(1);
                            break;
                        }
                    }

                    while (true)
                    {
                        Delay(1);
                        var screen = Services.ScreenShoot(deviceID);
                        var wrongusernamePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGUSERNAME);
                        var inputpasswordPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, INPUTPASSWORD);
                        if(wrongusernamePoint!= null)
                        {
                            Console.WriteLine("wrong username");
                            Delay(1);
                            Exit(deviceID);
                            return "Wrong Username";
                        }
                        if(inputpasswordPoint != null)
                        {
                            Console.WriteLine("den nhap password");
                            Delay(1);
                            KAutoHelper.ADBHelper.Tap(deviceID, 300, 1000);
                            Delay(1);
                            break;

                        }
                     
                    }
                }

                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, PASSWORD) == true)
                    {
                        Console.WriteLine("click password");
                        break;
                    }
                    else Console.WriteLine("khong tim thay nut password");
                }
                KAutoHelper.ADBHelper.InputText(deviceID, password);
                Delay(1);

                while (true)
                {
                    Delay(1);
                    if(Services.findImage(deviceID,CONTINUE) == true)
                    {
                        Console.WriteLine("click continue");
                        Delay(1);
                        break;
                    }
                }


                while (true)
                {
                    Delay(1);
                    if(Services.findImage(deviceID,SAVEPASSWORD) == true)
                    {
                        Console.WriteLine("click never");
                        Delay(1);
                        break;

                    }
                }

                while (true)
                {
                    Delay(1);
                    var screen = Services.ScreenShoot(deviceID);
                    var wrongpasswordPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGPASSWORD);
                    var inputcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, INPUTCODE);
                    var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                    var toomuchPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, TOOMUCH);
                    // thiếu đoạn đăng nhập thành công
                    if(wrongpasswordPoint!= null)
                    {
                        Console.WriteLine("sia mat khau");
                        dem--;
                        break;
                    }
                    
                    if(toomuchPoint!= null)
                    {
                        Console.WriteLine("thu qua nhieu lan");
                        Delay(1);
                        return "Too Much Try";
                    }
                    if(inputcodePoint != null)
                    {
                        Console.WriteLine("can code");
                        Delay(1);
                        return "Choose Auth Method";
                    }
                    
                    if(loginsuccessPoint!= null)
                    {
                        Console.WriteLine("login success");
                        return "Login Success";
                    }
                }
            }
            

        }


        public string inputCode(String deviceID, String simID)
        {

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, TRYOTHERWAY) == true)
                {
                    Console.WriteLine("click cach khac");
                    Delay(5);
                    break;
                }
                else Console.WriteLine("khong tim thay nut other way");

            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, MESSAGE) == true)
                {
                    Console.WriteLine("click message");
                    Delay(5);
                    KAutoHelper.ADBHelper.Tap(deviceID, 300, 900);
                    Delay(1);
                    break;
                }
                else Console.WriteLine("khong tim thay tin nhan");
            }







            int dem = 80;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0) break;
                code = MessageDAO.getCodeGmail(simID, MessageDAO.FBsql);
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
                code = MessageDAO.getCodeGmail(simID, "");
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
                    break;
                }
                else Console.WriteLine("khong tim thay nut code");

            }


            KAutoHelper.ADBHelper.InputText(deviceID, code);
            Delay(2);


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CONTINUE) == true)
                {
                    Console.WriteLine("click continue");
                    Delay(5);
                    break;
                }
                else Console.WriteLine("khong tim thay nut continue");
            }


            //screen = Services.ScreenShoot(deviceID);
            //codePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGCODE);
            //if (codePoint != null)
            //{
            //    Console.WriteLine("sai code ");
            //    return "Wrong Auth Code";
            //}


            //while (true)
            //{
            //    screen = Services.ScreenShoot(deviceID);
            //    var loggingPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGGING);

            //    if (loggingPoint == null)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Delay(1);
            //    }
            //}

            while (true)
            {
                Delay(1);
                var screen = Services.ScreenShoot(deviceID);
                var wrongcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGCODE);
                var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                if(wrongcodePoint!= null)
                {
                    Delay(1);
                    return "Wrong Auth Code";

                }
                if(loginsuccessPoint!= null)
                {
                    Delay(1);
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
            KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            Delay(1);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            Delay(1);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            Delay(1);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
            Delay(3);
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear org.mozilla.firefox ");
            Delay(3);
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

