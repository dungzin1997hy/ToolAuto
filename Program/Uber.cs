using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;
namespace ToolTest
{
    class Uber
    {
        #region data
        Bitmap UBER;
        Bitmap START;
        Bitmap USERNAME;
        Bitmap NEXT;
        Bitmap NEEDCODE;
        Bitmap SENDCODE;
        Bitmap SKIP;
        Bitmap WRONGCODE;
        Bitmap LOGINSUCCESS;



        #endregion
        public Uber()
        {
            LoadData();
        }
        void LoadData()
        {
            UBER = (Bitmap)Bitmap.FromFile("E://data//whatsapp//uber.png");
            START = (Bitmap)Bitmap.FromFile("E://data//whatsapp//start.png");
            USERNAME = (Bitmap)Bitmap.FromFile("E://data//whatsapp//username.png");
            NEXT = (Bitmap)Bitmap.FromFile("E://data//whatsapp//next.png");
            NEEDCODE = (Bitmap)Bitmap.FromFile("E://data//whatsapp//needcode.png");
            SENDCODE = (Bitmap)Bitmap.FromFile("E://data//whatsapp//sendcode.png");
            SKIP = (Bitmap)Bitmap.FromFile("E://data//whatsapp//skip.png");
            SKIP = (Bitmap)Bitmap.FromFile("E://data//whatsapp//skip.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("E://data//whatsapp//wrongcode.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("E://data//whatsapp//loginsuccess.png");

        }

        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }

        public string chooseUber(String deviceID, String noxID)
        {
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.ubercab ");
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " -package:com.ubercab");


            int count = 20;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install uber ");
                    KAutoHelper.ADBHelper.ExecuteCMD("D:\\Nox\\bin\\Nox.exe -clone:" + noxID + " \"-apk:D:\\Nox\\apk\\uber.apk\"");
                    Delay(1);
                    int dem = 30;
                    while (true)
                    {
                        Console.WriteLine("dang doi install");
                        var screen1 = Services.ScreenShoot(deviceID);
                        var whatsappPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, UBER);

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
                    return "Open Uber Success";
                }
                var screen = Services.ScreenShoot(deviceID);

                var whatsappPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, UBER);



                if (whatsappPoint1 != null)

                {
                    return "Open Uber Success";

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
                if (Services.findImage(deviceID, USERNAME) == true)
                {
                    Console.WriteLine("click username");
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, username);
                    Delay(1);
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
                if (Services.findImage(deviceID, SENDCODE) == true)
                {
                    Console.WriteLine("click sendcode");
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
                code = MessageDAO.getcodeUber(simID, MessageDAO.FBsql);
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
                code = MessageDAO.getcodeUber(simID, "");
                Console.WriteLine("Code: " + code);
                if (code.Equals("") || code == null)
                {
                    return "Dont have Auth code";
                }

            }
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
            Thread.Sleep(TimeSpan.FromMilliseconds(200));KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
            Thread.Sleep(TimeSpan.FromMilliseconds(200));KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
            Thread.Sleep(TimeSpan.FromMilliseconds(200));KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
            Thread.Sleep(TimeSpan.FromMilliseconds(200));

            KAutoHelper.ADBHelper.InputText(deviceID, code);

            while (true)
            {
                Delay(1);
                var screen = Services.ScreenShoot(deviceID);
                var wrongcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGCODE);
                var skippoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SKIP);
                var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                if (wrongcodePoint != null)
                {
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
                    Thread.Sleep(TimeSpan.FromMilliseconds(200)); KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
                    Thread.Sleep(TimeSpan.FromMilliseconds(200)); KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
                    Thread.Sleep(TimeSpan.FromMilliseconds(200)); KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
                    Thread.Sleep(TimeSpan.FromMilliseconds(200));
                    KAutoHelper.ADBHelper.InputText(deviceID, code);

                    while (true)
                    {
                        Delay(1);
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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.ubercab ");
            return "Exit Success";
        }

    }
}
