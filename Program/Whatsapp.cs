using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class Whatsapp

    {
        #region data
        Bitmap WHATSAPP;
        Bitmap CONTINUE;
        Bitmap PHONENUMBER;
        Bitmap NEXT;
        Bitmap OK;
        Bitmap NEEDCODE;
        Bitmap CODE;
        Bitmap VERIFYING;
        Bitmap SKIP;
        Bitmap LOGINSUCCESS;
        Bitmap WRONGUSERNAME;
        Bitmap WRONGCODE;
        Bitmap NAME;
        Bitmap NEXT2;
        
        
        
        #endregion
        public Whatsapp()
        {
            LoadData();
        }
        void LoadData()
        {
            WHATSAPP = (Bitmap)Bitmap.FromFile("C://data//whatsapp//whatsapp.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("C://data//whatsapp//continue.png");
            PHONENUMBER = (Bitmap)Bitmap.FromFile("C://data//whatsapp//phonenumber.png");
            NEXT = (Bitmap)Bitmap.FromFile("C://data//whatsapp//next.png");
            OK = (Bitmap)Bitmap.FromFile("C://data//whatsapp//ok.png");
            NEEDCODE = (Bitmap)Bitmap.FromFile("C://data//whatsapp//needcode.png");
            CODE = (Bitmap)Bitmap.FromFile("C://data//whatsapp//code.png");
            VERIFYING = (Bitmap)Bitmap.FromFile("C://data//whatsapp//verifying.png");
            SKIP = (Bitmap)Bitmap.FromFile("C://data//whatsapp//skip.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("C://data//whatsapp//loginsuccess.png");
            WRONGUSERNAME = (Bitmap)Bitmap.FromFile("C://data//whatsapp//wrongusername.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("C://data//whatsapp//wrongcode.png");
            NAME = (Bitmap)Bitmap.FromFile("C://data//whatsapp//name.png");
            NEXT2 = (Bitmap)Bitmap.FromFile("C://data//whatsapp//next2.png");
           
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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.whatsapp ");
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.whatsapp");


            int count = 20;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install whatsapp ");
                    KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " \"-apk:" + MainProgram.linkApk + "\\whatsapp.apk\"");
                    Delay(1);
                    int dem = 30;
                    while (true)
                    {
                        Console.WriteLine("dang doi install");
                        var screen1 = Services.ScreenShoot(deviceID);
                        var whatsappPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, WHATSAPP);
                        
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
                    return "Open Whatsapp Success";
                }
                var screen = Services.ScreenShoot(deviceID);

                var whatsappPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WHATSAPP);
              


                if (whatsappPoint1 != null)

                {
                    return "Open Whatsapp Success";

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
                if (Services.findImage(deviceID, PHONENUMBER) == true)
                {
                    Console.WriteLine("click phonenumber");
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, username);
                    break;
                }
            }

            Delay(1);
            var screen = Services.ScreenShoot(deviceID);
            var wrongusernamePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGUSERNAME);
            if(wrongusernamePoint!= null)
            {
                return "Wrong phonenumber";
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
                if (Services.findImage(deviceID, NEEDCODE) == true)
                {
                    Console.WriteLine("click NEEDCODE");
                    Delay(1);
                    break;
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
                code = MessageDAO.getCodeWhatsapp(simID, MessageDAO.FBsql);
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
                code = MessageDAO.getCodeWhatsapp(simID, "");
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
                if (Services.findImage(deviceID, VERIFYING) == true)
                {
                    Console.WriteLine("DANG DOI");
                   
                }
                else
                {
                    break;
                }
            }


            while (true)
            {
                Delay(1);
                var screen = Services.ScreenShoot(deviceID);
                var wrongcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGCODE);
                var skippoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SKIP);
                var namepoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, NAME);
                var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                if (wrongcodePoint != null)
                {
                    Delay(1);
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, OK) == true)
                        {
                            Console.WriteLine("click OK");
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
                        if (Services.findImage(deviceID, VERIFYING) == true)
                        {
                            Console.WriteLine("DANG DOI");

                        }
                        else
                        {
                            break;
                        }
                    }

                    while (true)
                    {
                        var screen1 = Services.ScreenShoot(deviceID);
                        var wrongcodePoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, WRONGCODE);
                        var loginsuccessPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINSUCCESS);
                        var skipPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, SKIP);
                        if (wrongcodePoint1 != null)
                        {
                            return "Wrong Auth Code";
                        }
                        if (loginsuccessPoint1 != null)
                        {
                            return "Login Success";
                        }
                        if (skipPoint1 != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, skippoint.Value.X, skippoint.Value.Y);

                            while (true)
                            {
                                Delay(1);
                                if (Services.findImage(deviceID, LOGINSUCCESS) == true)
                                {
                                    break;
                                }
                            }
                            return "Login Success";
                        }
                    }

                }
                if (skippoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, skippoint.Value.X, skippoint.Value.Y);
                    Delay(2);
                    var screen5 = Services.ScreenShoot(deviceID);
                    var namePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen5, NAME);
                    if (namePoint != null) {

                        while (true)
                        {
                            Delay(1);
                            if (Services.findImage(deviceID, NAME) == true)
                            {
                                KAutoHelper.ADBHelper.InputText(deviceID, "anh");
                                break;
                            }
                        }
                        while (true)
                        {
                            Delay(1);
                            if(Services.findImage(deviceID,NEXT2) == true)
                            {
                                break;
                            }
                        }
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
                if(loginsuccessPoint!= null)
                {
                    return "Login Success";
                }
                if(namepoint!= null)
                {
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, NAME) == true)
                        {
                            KAutoHelper.ADBHelper.InputText(deviceID, "anh");
                            break;
                        }
                    }
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, NEXT2) == true)
                        {
                            break;
                        }
                    }
                }
                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, LOGINSUCCESS) == true)
                    {
                        break;
                    }
                }
                return "Login Success";
            
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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.whatsapp ");
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
