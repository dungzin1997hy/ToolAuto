using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;
namespace ToolTest
{
    class Imo

    {
        //#region data
        //Bitmap BIGO;


        //#endregion
        //public Imo()
        //{
        //    LoadData();
        //}
        //void LoadData()
        //{
        //    BIGO = (Bitmap)Bitmap.FromFile("E://data//facebookreg//bigo.png");

        //}


        //void Delay(int delay)
        //{
        //    while (delay > 0)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(1));
        //        delay--;

        //    }
        //}
        //public string chooseBigolive(String deviceID, String noxID)
        //{
        //    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear sg.bigo.live ");
        //    Exit(deviceID);
        //    KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:sg.bigo.live");


        //    int count = 20;
        //    while (true)
        //    {
        //        if (count == 0)
        //        {
        //            Console.WriteLine("install line ");
        //            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " \"-apk:" + MainProgram.linkApk + "\\bigolive.apk\"");
        //            Delay(1);
        //            int dem = 30;
        //            while (true)
        //            {
        //                Console.WriteLine("dang doi install");
        //                var screen1 = Services.ScreenShoot(deviceID);
        //                var whatsappPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, BIGO);

        //                if (whatsappPoint != null)
        //                {
        //                    Delay(1);
        //                    break;

        //                }
        //                else
        //                {
        //                    Delay(1);
        //                    dem--;
        //                }
        //                if (dem == 0)
        //                {
        //                    Console.WriteLine("looix app");
        //                    return "Open App Error";
        //                }

        //            }
        //            return "Open Line Success";
        //        }
        //        var screen = Services.ScreenShoot(deviceID);
        //        var whatsappPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BIGO);
        //        if (whatsappPoint1 != null)

        //        {
        //            return "Open Line Success";

        //        }
        //        else
        //        {
        //            Delay(1);
        //            count--;
        //        }
        //    }
        //}
        //public string BigoReg(String deviceID, String username, String simID)
        //{
        //    while (true)
        //    {
        //        Delay(1);
        //        if (Services.findImage(deviceID, PHONE) == true)
        //        {
        //            Delay(1);
        //            KAutoHelper.ADBHelper.InputText(deviceID, username);
        //            break;
        //        }
        //    }


        //    while (true)
        //    {
        //        Delay(1);
        //        if (Services.findImage(deviceID, NEXT) == true)
        //        {
        //            Delay(1);
        //            break;
        //        }
        //    }

        //    int dem = 80;
        //    String code = "";
        //    while (true)
        //    {
        //        Delay(20);
        //        if (dem == 0) break;
        //        code = MessageDAO.getCodeBigo(simID, MessageDAO.FBsql);
        //        if (code == "" || code == null)
        //        {
        //            Console.WriteLine("DANG DOI TIN NHAN");
        //            dem -= 20;
        //        }
        //        else
        //        {

        //            break;
        //        }


        //    }
        //    Console.WriteLine("Code: " + code);
        //    if (code.Equals(""))
        //    {
        //        code = MessageDAO.getCodeBigo(simID, "");
        //        Console.WriteLine("Code: " + code);
        //        if (code.Equals("") || code == null)
        //        {
        //            return "Dont have Auth code";
        //        }
        //    }

        //    while (true)
        //    {
        //        Delay(1);
        //        if (Services.findImage(deviceID, CODE) == true)
        //        {
        //            Delay(1);
        //            KAutoHelper.ADBHelper.InputText(deviceID, code);
        //            break;
        //        }
        //    }

        //    while (true)
        //    {
        //        Delay(1);
        //        if (Services.findImage(deviceID, PASSWORD) == true)
        //        {
        //            Delay(1);
        //            KAutoHelper.ADBHelper.InputText(deviceID, "test123456");
        //            break;
        //        }
        //    }

        //    while (true)
        //    {
        //        Delay(1);
        //        if (Services.findImage(deviceID, SIGNUP) == true)
        //        {
        //            Delay(1);
        //            break;
        //        }
        //    }

        //    Delay(5);
        //    Exit(deviceID);


        //    return "";
        //}

        //public string Exit(String deviceID)
        //{

        //    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
        //    Delay(1);
        //    KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
        //    Thread.Sleep(TimeSpan.FromMilliseconds(500));
        //    KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
        //    Thread.Sleep(TimeSpan.FromMilliseconds(500));
        //    KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
        //    KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700);
        //    Thread.Sleep(TimeSpan.FromMilliseconds(500));
        //    KAutoHelper.ADBHelper.Swipe(deviceID, 600, 700, 100, 700); ;
        //    Delay(1);
        //    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
        //    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
        //    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
        //    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_BACK);
        //    Delay(5);
        //    KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear sg.bigo.live ");
        //    return "Exit Success";


        //}
    }
}
