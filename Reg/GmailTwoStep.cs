using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using ToolTest.dao;

namespace ToolTest
{
    class GmailTwoStep


    {
        #region data
        Bitmap GMAIL;
        Bitmap NOTNOW;
        Bitmap POINT;
        Bitmap FORYOU;
        Bitmap MANAGE;
        Bitmap HOME;
        Bitmap SECURITY;
        Bitmap SECURITY2;
        Bitmap STEP;
        Bitmap ALLOW;
        Bitmap GOOGLE;
        Bitmap NEXT;
        Bitmap PASSWORD;
        Bitmap CONFIRM;
        Bitmap VERIFI;
        Bitmap STARTED;
        Bitmap CONTINUE;
        Bitmap SHOWMORE;
        Bitmap TEXT;
        Bitmap NEXT2;
        Bitmap CODE;
        Bitmap TURNON;
        Bitmap GOOGLEACCOUNT;
        Bitmap VERIFY;
        Bitmap NEXT3;
        Bitmap GOOGLE2;
        Bitmap PASSWORD2;
        Bitmap ACCEPT;
        Bitmap SETTING;
        Bitmap REFRESH;
        Bitmap RESEND;

        #endregion
        public GmailTwoStep()
        {
            LoadData();
        }
        void LoadData()
        {

            GMAIL = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//gmail.png");
            NOTNOW = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//notnow.png");
            POINT = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//point.png");
            FORYOU = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//foryou.png");
            MANAGE = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//manage.png");
            HOME = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//home.png");
            SECURITY = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//security.png");
            SECURITY2 = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//security2.png");
            STEP = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//step.png");
            ALLOW = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//allow.png");
            GOOGLE = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//google.png");
            NEXT = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//next.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//password.png");
            CONFIRM = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//confirm.png");
            VERIFI = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//verifi.png");
            STARTED = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//started.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//continue.png");
            SHOWMORE = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//showmore.png");
            TEXT = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//text.png");
            NEXT2 = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//next2.png");
            CODE = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//code.png");
            TURNON = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//turnon.png");
            GOOGLEACCOUNT = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//googleaccount.png");
            VERIFY = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//verify.png");
            NEXT3 = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//next3.png");
            GOOGLE2 = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//google2.png");
            PASSWORD2 = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//password2.png");
            ACCEPT = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//accept.png");
            SETTING = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//setting.png");
            REFRESH = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//refresh.png");
            RESEND = (Bitmap)Bitmap.FromFile("C://data//gmailtwostep//resend.png");

        }


        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseBigolive(String deviceID, String noxID,String password)
        {

            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.android.vending");

            Delay(10);
            int temp = 15;
            while (true)
            {
                

                Delay(1);
                if (temp == 0)
                {
                    break;
                }
                if(Services.findImage(deviceID,ACCEPT) == true)
                {
                    break;
                }
                if(Services.findImage(deviceID,VERIFY) == true)
                {
                    Delay(1);
                    //while (true)
                    //{
                    //    Delay(1);
                    //    if(Services.findImage(deviceID,NEXT3) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, NEXT3, "next");

                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, GOOGLE2) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, GOOGLE2, "google");


                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, PASSWORD2) == true)
                        {

                            Delay(1);
                            KAutoHelper.ADBHelper.InputText(deviceID, password);
                            Delay(1);
                            break;
                        }
                    }
                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, NEXT3) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, NEXT3, "next");

                    int dem = 5;
                    while (true)
                    {
                        Delay(1);
                        if(dem == 0)
                        {
                            break;
                        }
                        if (Services.findImage(deviceID, ACCEPT) == true)
                        {
                            break;
                        }
                        else
                        {
                            dem--;
                        }
                    }
                    break;
                }
                if (Services.findImage(deviceID, POINT) == true)
                {
                    Delay(1);
                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, NOTNOW) == true)
                    //    {
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, NOTNOW, "notnow");

                    break;
                }
                else if (Services.findImage(deviceID, FORYOU) == true)
                {
                    Delay(1);
                    break;
                }
                else
                {
                    temp--;
                    Console.WriteLine(deviceID + " " + temp);
                }
            }

            return "Open Gmail Success";
        }
        public string gmailstep(String deviceID, String firstname, String lastname, String username, String password, String phone, String simID, String day, String month, String year)
        {

            Delay(1);
            KAutoHelper.ADBHelper.Tap(deviceID, 650, 75);
            int dem = 5;
            while (true)
            {
                if (dem <= 0)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, 650, 75);
                }
                Delay(1);
                if (Services.findImage(deviceID, MANAGE) == true)
                {
                    Delay(1);
                    break;
                }
                else
                {
                    dem--;
                }
            }
            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, HOME) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}

            Services.pressImage(deviceID, HOME, "home");


            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, SECURITY) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}
            Services.pressImage(deviceID, SECURITY, "security");


            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, SECURITY2) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}
            Services.pressImage(deviceID, SECURITY2, "security");

            while (true)
            {

                KAutoHelper.ADBHelper.Swipe(deviceID, 710, 550, 710, 450);
                Delay(1);
                if (Services.findImage(deviceID, STEP) == true)
                {
                    Delay(1);
                    break;
                }
            }
            Delay(5);
            dem = 3;
            while (true)
            {
                Delay(1);
                if (dem == 0)
                {
                    break;
                }
                if (Services.findImage(deviceID, ALLOW) == true)
                {
                    Delay(1);
                    break;
                }
                else
                {
                    dem--;
                }
            }
            Delay(2);
            dem = 3;
            while (true)
            {
                Delay(1);
                if (dem == 0)
                {
                    break;
                }
                if (Services.findImage(deviceID, ALLOW) == true)
                {
                    Delay(1);
                    break;
                }
                else
                {
                    dem--;
                }
            }

            //check bat nhap password
            //
            Delay(5);
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, GOOGLEACCOUNT) == true)
                {
                    Delay(1);
                    break;
                }
                Delay(1);
                if (Services.findImage(deviceID, GOOGLEACCOUNT) == true)
                {
                    Delay(1);
                    break;
                }

                if (Services.findImage(deviceID, GOOGLE) == true)
                {
                    Delay(1);
                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, NEXT) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, NEXT, "next");


                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, GOOGLE) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("dang doi google sau password");
                    //    }
                    //}
                    Services.pressImage(deviceID, GOOGLE, "google sau pass");

                    //tieesp
                    while (true)
                    {
                        Delay(1);
                        Services.findImage(deviceID, GOOGLE);
                        if (Services.findImage(deviceID, PASSWORD) == true)
                        {
                            Delay(1);
                            KAutoHelper.ADBHelper.InputText(deviceID, password);
                            Delay(1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("dang doi PASSWORD");
                        }
                    }

                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, NEXT) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, NEXT, "next");

                    dem = 7;
                    while (true)
                    {
                        if (dem == 0)
                        {

                            //while (true)
                            //{
                            //    Delay(1);
                            //    if(Services.findImage(deviceID,SETTING) == true)
                            //    {
                            //        Delay(1);
                            //        break;
                            //    }
                            //}
                            Services.pressImage(deviceID, SETTING, "setting");


                            //while (true)
                            //{
                            //    Delay(1);
                            //    if (Services.findImage(deviceID, REFRESH) == true)
                            //    {
                            //        Delay(1);
                            //        break;
                            //    }
                            //}
                            Services.pressImage(deviceID, REFRESH, "refresh");

                            dem = 7;
                        }
                        Delay(1);
                        if (Services.findImage(deviceID, CONFIRM) == true)
                        {
                            Delay(1);
                            break;
                        }
                        else
                        {
                            dem--;
                        }
                    }

                    dem = 5;
                    while (true)
                    {
                        if (dem == 0)
                        {
                            break;
                        }
                        Delay(1);
                        if (Services.findImage(deviceID, GOOGLEACCOUNT) == true)
                        {
                            Delay(1);
                            break;
                        }
                        else
                        {
                            dem--;
                            Console.WriteLine("dang doi google");
                        }
                    }
                    break;
                }
               
            }

            

            while (true)
            {
                Delay(1);
                KAutoHelper.ADBHelper.Swipe(deviceID, 700, 1000, 700, 400);
                Console.WriteLine("swipe");
                if (Services.findImage(deviceID, STARTED) == true)
                {
                    Delay(1);
                    break;
                }
            }

            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, GOOGLE) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("dang doi google");
            //    }
            //}
            Services.pressImage(deviceID, GOOGLE, "google");

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PASSWORD) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, password);
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi PASSWORD");
                }
            }

            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, NEXT) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}
            Services.pressImage(deviceID, NEXT, "next");


            while (true)
            {
                Delay(1);
                if(Services.findImage(deviceID,TEXT) == true)
                {
                    Delay(1);
                    break;
                }
                Delay(1);
                if (Services.findImage(deviceID, TEXT) == true)
                {
                    Delay(1);
                    break;
                }
                if (Services.findImage(deviceID, SHOWMORE) == true)
                {
                    Delay(1);
                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, TEXT) == true)
                {
                    Delay(1);
                    break;
                }
            }
            Delay(3);
            KAutoHelper.ADBHelper.Swipe(deviceID, 700, 1000, 700, 400);
            KAutoHelper.ADBHelper.Swipe(deviceID, 700, 1000, 700, 400);
            Delay(1);
            KAutoHelper.ADBHelper.Tap(deviceID,170,580);
            KAutoHelper.ADBHelper.Tap(deviceID,170,580);
            KAutoHelper.ADBHelper.Tap(deviceID,170,580);
            Delay(1);
            KAutoHelper.ADBHelper.InputText(deviceID, "+84" + phone);
            Delay(1);
            
           
            while (true)
            {
                Delay(1);
                KAutoHelper.ADBHelper.Swipe(deviceID, 700, 1000, 700, 400);
                if (Services.findImage(deviceID, NEXT2) == true)
                {
                    Delay(1);
                    break;
                }
            }

            dem = 5;
            while (true)
            {
                if (dem == 0)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, 150, 250);
                    KAutoHelper.ADBHelper.Tap(deviceID, 150, 250);
                    break;
                }
                Delay(1);
                if (Services.findImage(deviceID, GOOGLEACCOUNT) == true)
                {
                    Delay(1);
                    break;
                }
                else
                {
                    dem--;
                    Console.WriteLine("dang doi google");
                }
            }
            dem = 40;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0) {
                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, RESEND)== true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, RESEND, "resend");
                    while (true)
                    {
                        Delay(1);
                        KAutoHelper.ADBHelper.Swipe(deviceID, 700, 1000, 700, 400);
                        if (Services.findImage(deviceID, NEXT2) == true)
                        {
                            Delay(1);
                            break;
                        }
                    }

                    dem = 40;
                    code = "";
                    while (true)
                    {
                        if(dem == 0)
                        {
                            return "Dont have auth code";
                        }
                        code = MessageDAO.getCodeGmail(simID, MessageDAO.FBsql);
                        if(code == ""||code == null)
                        {
                            Console.WriteLine("dang doi tin nhan");
                            dem -= 20;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            
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
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, code);
                    Delay(1);
                    break;
                }
            }


            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, NEXT2) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("dang doi next");
            //    }
            //}
            Services.pressImage(deviceID, NEXT2, "next");
            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, TURNON) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("dang doi turn on");
            //    }
            //}
            Services.pressImage(deviceID, TURNON, "turn on");


            Delay(5);
            return "Reg Success";
            return "";
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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear sg.bigo.live ");
            return "Exit Success";


        }
    }
}
