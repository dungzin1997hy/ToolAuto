﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest.Program
{
    //class Instagram


    //{
    //    #region data
    //    Bitmap INSTAGRAM;
       



    //    #endregion
    //    public Instagram()
    //    {
    //        LoadData();
    //    }
    //    void LoadData()
    //    {
    //        INSTAGRAM = (Bitmap)Bitmap.FromFile("C://data//instagram//instagram.png");
            
    //    }


    //    void Delay(int delay)
    //    {
    //        while (delay > 0)
    //        {
    //            Thread.Sleep(TimeSpan.FromSeconds(1));
    //            delay--;

    //        }
    //    }
    //    public string chooseInstagram(String deviceID, String noxID)
    //    {
    //        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.instagram.android ");
    //        Exit(deviceID);
    //        KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " -package:com.instagram.android");


    //        int count = 10;
    //        while (true)
    //        {
    //            if (count == 0)
    //            {
    //                Console.WriteLine("install instagram ");
    //                KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " \"-apk:D:\\Nox\\apk\\instagram.apk\"");
    //                Delay(1);
    //                int dem = 30;
    //                while (true)
    //                {
    //                    Console.WriteLine("dang doi install");
    //                    var screen1 = Services.ScreenShoot(deviceID);
    //                    var whatsappPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, INSTAGRAM);

    //                    if (whatsappPoint != null)
    //                    {
    //                        Delay(1);
    //                        break;

    //                    }
    //                    else
    //                    {
    //                        Delay(1);
    //                        dem--;
    //                    }
    //                    if (dem == 0)
    //                    {
    //                        Console.WriteLine("looix app");
    //                        return "Open App Error";
    //                    }

    //                }
    //                return "Open Whatsapp Success";
    //            }
    //            var screen = Services.ScreenShoot(deviceID);

    //            var whatsappPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, INSTAGRAM);



    //            if (whatsappPoint1 != null)

    //            {
    //                return "Open Instagram Success";

    //            }
    //            else
    //            {
    //                Delay(1);
    //                count--;
    //            }
    //        }
    //    }
    //    public string login(String deviceID, String username, String password, String noxID)
    //    {

    //        while (true)
    //        {
    //            Delay(1);
    //            if (Services.findImage(deviceID, CONTINUE) == true)
    //            {
    //                Console.WriteLine("click continue");
    //                Delay(1);
    //                break;
    //            }
    //            else
    //            {
    //                Console.WriteLine("dang doi khoi dong xong");
    //            }
    //        }
    //        while (true)
    //        {
    //            Delay(1);
    //            if (Services.findImage(deviceID, PHONENUMBER) == true)
    //            {
    //                Console.WriteLine("click phonenumber");
    //                Delay(1);
    //                KAutoHelper.ADBHelper.InputText(deviceID, username);
    //                break;
    //            }
    //        }

    //        Delay(1);
    //        var screen = Services.ScreenShoot(deviceID);
    //        var wrongusernamePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGUSERNAME);
    //        if (wrongusernamePoint != null)
    //        {
    //            return "Wrong phonenumber";
    //        }
    //        while (true)
    //        {
    //            Delay(1);
    //            if (Services.findImage(deviceID, NEXT) == true)
    //            {
    //                Console.WriteLine("click next");
    //                Delay(1);
    //                break;
    //            }
    //        }

    //        while (true)
    //        {
    //            Delay(1);
    //            if (Services.findImage(deviceID, OK) == true)
    //            {
    //                Console.WriteLine("click ok");
    //                Delay(1);
    //                break;
    //            }
    //        }

    //        while (true)
    //        {
    //            Delay(1);
    //            if (Services.findImage(deviceID, NEEDCODE) == true)
    //            {
    //                Console.WriteLine("click NEEDCODE");
    //                Delay(1);
    //                break;
    //            }
    //        }

    //        return "Need Code";

    //    }
    //    public String inputCode(String deviceID, String simID)
    //    {

    //        while (true)
    //        {
    //            Delay(1);
    //            if (Services.findImage(deviceID, CODE) == true)
    //            {
    //                Console.WriteLine("click code");
    //                Delay(1);
    //                break;
    //            }
    //            else Console.WriteLine("khong tim thay nut SMS");

    //        }



    //        int dem = 80;
    //        String code = "";
    //        while (true)
    //        {
    //            Delay(20);
    //            if (dem == 0) break;
    //            code = MessageDAO.getCodeWhatsapp(simID, MessageDAO.FBsql);
    //            if (code == "" || code == null)
    //            {
    //                Console.WriteLine("DANG DOI TIN NHAN");
    //                dem -= 20;
    //            }
    //            else
    //            {

    //                break;
    //            }

    //        }
    //        Console.WriteLine("Code: " + code);
    //        if (code.Equals(""))
    //        {
    //            code = MessageDAO.getCodeWhatsapp(simID, "");
    //            Console.WriteLine("Code: " + code);
    //            if (code.Equals("") || code == null)
    //            {
    //                return "Dont have Auth code";
    //            }

    //        }

    //        while (true)
    //        {
    //            Delay(1);
    //            if (Services.findImage(deviceID, CODE) == true)
    //            {
    //                Console.WriteLine("click code");
    //                Delay(5);
    //                KAutoHelper.ADBHelper.InputText(deviceID, code);
    //                Delay(2);
    //                break;
    //            }
    //            else Console.WriteLine("khong tim thay nut code");

    //        }



    //        while (true)
    //        {
    //            Delay(1);
    //            if (Services.findImage(deviceID, VERIFYING) == true)
    //            {
    //                Console.WriteLine("DANG DOI");

    //            }
    //            else
    //            {
    //                break;
    //            }
    //        }


    //        while (true)
    //        {
    //            Delay(1);
    //            var screen = Services.ScreenShoot(deviceID);
    //            var wrongcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGCODE);
    //            var skippoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SKIP);
    //            var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
    //            if (wrongcodePoint != null)
    //            {
    //                Delay(1);
    //                while (true)
    //                {
    //                    Delay(1);
    //                    if (Services.findImage(deviceID, OK) == true)
    //                    {
    //                        Console.WriteLine("click OK");
    //                        Delay(5);
    //                        KAutoHelper.ADBHelper.InputText(deviceID, code);
    //                        Delay(2);
    //                        break;
    //                    }
    //                    else Console.WriteLine("khong tim thay nut code");

    //                }
    //                while (true)
    //                {
    //                    Delay(1);
    //                    if (Services.findImage(deviceID, CODE) == true)
    //                    {
    //                        Console.WriteLine("click code");
    //                        Delay(5);
    //                        KAutoHelper.ADBHelper.InputText(deviceID, code);
    //                        Delay(2);
    //                        break;
    //                    }
    //                    else Console.WriteLine("khong tim thay nut code");

    //                }



    //                while (true)
    //                {
    //                    Delay(1);
    //                    if (Services.findImage(deviceID, VERIFYING) == true)
    //                    {
    //                        Console.WriteLine("DANG DOI");

    //                    }
    //                    else
    //                    {
    //                        break;
    //                    }
    //                }

    //                while (true)
    //                {
    //                    var screen1 = Services.ScreenShoot(deviceID);
    //                    var wrongcodePoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, WRONGCODE);
    //                    var loginsuccessPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINSUCCESS);
    //                    var skipPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, SKIP);
    //                    if (wrongcodePoint1 != null)
    //                    {
    //                        return "Wrong Auth Code";
    //                    }
    //                    if (loginsuccessPoint1 != null)
    //                    {
    //                        return "Login Success";
    //                    }
    //                    if (skippoint != null)
    //                    {
    //                        KAutoHelper.ADBHelper.Tap(deviceID, skippoint.Value.X, skippoint.Value.Y);

    //                        while (true)
    //                        {
    //                            Delay(1);
    //                            if (Services.findImage(deviceID, LOGINSUCCESS) == true)
    //                            {
    //                                break;
    //                            }
    //                        }
    //                        return "Login Success";
    //                    }
    //                }

    //            }
    //            if (skippoint != null)
    //            {
    //                KAutoHelper.ADBHelper.Tap(deviceID, skippoint.Value.X, skippoint.Value.Y);

    //                while (true)
    //                {
    //                    Delay(1);
    //                    if (Services.findImage(deviceID, LOGINSUCCESS) == true)
    //                    {
    //                        break;
    //                    }
    //                }
    //                return "Login Success";
    //            }
    //            if (loginsuccessPoint != null)
    //            {
    //                return "Login Success";
    //            }
    //        }


    //        return "";
    //    }
    //    public string logout(String deviceID)
    //    {

    //        Exit(deviceID);
    //        return "Logout Success";
    //    }
    //    public string Exit(String deviceID)
    //    {

    //        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
    //        Delay(1);
    //        KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
    //        Thread.Sleep(TimeSpan.FromMilliseconds(500));
    //        KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
    //        Thread.Sleep(TimeSpan.FromMilliseconds(500));
    //        KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
    //        KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
    //        Thread.Sleep(TimeSpan.FromMilliseconds(500));
    //        KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700); ;
    //        Delay(1);
    //        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
    //        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
    //        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
    //        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
    //        Delay(5);
    //        KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.whatsapp ");
    //        return "Exit Success";


    //    }
    //    Boolean checkLogin(String deviceID)
    //    {

    //        Boolean isLogin = false;

    //        Console.WriteLine("kiem tra man hinh dang nhap");
    //        var screen = Services.ScreenShoot(deviceID);
    //        var LOGINSUCCESSpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);

    //        if (LOGINSUCCESSpoint != null)
    //        {
    //            isLogin = true;
    //        }
    //        Delay(1);
    //        return isLogin;

    //    }
    //}
}
