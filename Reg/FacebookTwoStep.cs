using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class FacebookTwoStep



    {
        #region data
        Bitmap HOME;
        Bitmap MUL;
        Bitmap SETTING;
        Bitmap SETTING2;
        Bitmap SECURITY;
        Bitmap TWOSTEP;
        Bitmap SMS;
        Bitmap CODE;
        Bitmap CONTINUE;
        Bitmap RESEND;
        Bitmap WRONGCODE;
        Bitmap PHONE;
        Bitmap CONFIRM;
        Bitmap PASSWORD;
        Bitmap CONTINUE2;
        Bitmap DONE;
        Bitmap CODEAUTH;
        Bitmap PHONEAUTH;


        #endregion
        public FacebookTwoStep()
        {
            LoadData();
        }
        void LoadData()
        {

            HOME = (Bitmap)Bitmap.FromFile("C://data//facebookstep//home.png");
            MUL = (Bitmap)Bitmap.FromFile("C://data//facebookstep//mul.png");
            SETTING = (Bitmap)Bitmap.FromFile("C://data//facebookstep//setting.png");
            SETTING2 = (Bitmap)Bitmap.FromFile("C://data//facebookstep//setting2.png");
            SECURITY = (Bitmap)Bitmap.FromFile("C://data//facebookstep//security.png");
            TWOSTEP = (Bitmap)Bitmap.FromFile("C://data//facebookstep//twostep.png");
            SMS = (Bitmap)Bitmap.FromFile("C://data//facebookstep//sms.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("C://data//facebookstep//continue.png");
            CODE = (Bitmap)Bitmap.FromFile("C://data//facebookstep//code.png");
            RESEND = (Bitmap)Bitmap.FromFile("C://data//facebookstep//resend.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("C://data//facebookstep//wrongcode.png");
            PHONE = (Bitmap)Bitmap.FromFile("C://data//facebookstep//phone.png");
            CONFIRM = (Bitmap)Bitmap.FromFile("C://data//facebookstep//confirm.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("C://data//facebookstep//password.png");
            CONTINUE2 = (Bitmap)Bitmap.FromFile("C://data//facebookstep//continue2.png");
            DONE = (Bitmap)Bitmap.FromFile("C://data//facebookstep//done.png");
            PHONEAUTH = (Bitmap)Bitmap.FromFile("C://data//facebookstep//phoneauth.png");
            CODEAUTH = (Bitmap)Bitmap.FromFile("C://data//facebookstep//codeauth.png");


        }


        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseFacebook(String deviceID, String noxID)
        {

            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.facebook.katana");

            Delay(10);
            int temp = 15;
            while (true)
            {
                Delay(1);
                if (temp == 0)
                {
                    break;
                }
                if (Services.findImage(deviceID, HOME) == true)
                {

                    break;
                }
                else
                {
                    temp--;
                    Console.WriteLine(deviceID + " " + temp);
                }
            }

            return "Open Facebook Success";
        }
        public string facebookstep(String deviceID, String password, String phone, String simID)
        {

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, MUL) == true)
                {
                    Delay(2);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 700, 1100, 700, 500);
                    Delay(1);
                    break;
                }
            }

            if (Services.findImage(deviceID, SETTING2) == false)
            {
                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, SETTING) == true)
                    {
                        Delay(1);
                        break;
                    }
                    else
                    {
                        KAutoHelper.ADBHelper.Swipe(deviceID, 700, 1100, 700, 500);
                    }
                }
                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, SETTING2) == true)
                    {
                        Delay(1);
                        break;
                    }
                }
            }

            while (true)
            {


                Delay(1);
                if (Services.findImage(deviceID, SECURITY) == true)
                {
                    Delay(1);
                    break;
                }
            }

            while (true)
            {


                Delay(1);
                if (Services.findImage(deviceID, TWOSTEP) == true)
                {
                    Delay(1);
                    break;
                }
            }
            while (true)
            {


                Delay(1);
                if (Services.findImage(deviceID, SMS) == true)
                {
                    Delay(1);
                    break;
                }
            }
            while (true)
            {
                Delay(1);
                if(Services.findImage(deviceID,CONTINUE) == true)
                {
                    Delay(1);
                    break;
                }
            }
            int temp = 5;
            while (true)
            {
                Delay(1);
                if (temp == 0)
                {
                    break;
                }
                if (Services.findImage(deviceID, PHONE) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID,"84" +phone);

                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, CONFIRM) == true)
                        {
                            Delay(1);
                            break;
                        }
                    }
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, PASSWORD) == true)
                        {
                            KAutoHelper.ADBHelper.InputText(deviceID, password);
                            Delay(1);
                            while (true)
                            {
                                Delay(1);
                                if (Services.findImage(deviceID, CONTINUE2) == true)
                                {
                                    Delay(1);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }
                else
                {
                    temp--;
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CODEAUTH) == true)
                {
                    break;
                }
                if (Services.findImage(deviceID, PHONEAUTH) == true)
                {
                    while (true)
                    {

                        Delay(1);
                        if (Services.findImage(deviceID, CONTINUE) == true)
                        {
                            Delay(1);
                            break;
                        }
                        else
                        {

                            Console.WriteLine("dang doi google");
                        }
                    }
                    while (true)
                    {

                        Delay(1);
                        if (Services.findImage(deviceID, CONTINUE) == true)
                        {
                            Delay(1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("dang doi google");
                        }
                    }
                }
            }


            //CODE
            int dem = 40;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0)
                {
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, RESEND) == true)
                        {
                            break;
                        }
                    }
                    dem = 40;
                    while (true)
                    {
                        if (dem == 0)
                        {
                            return "Dont have auth code";
                            break;
                        }
                        code = MessageDAO.getCodeGmail(simID, MessageDAO.FBsql);
                        if (code == "" || code == null)
                        {
                            Console.WriteLine("DANG DOI TIN NHAN");
                            dem -= 20;
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


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CONTINUE) == true)
                {
                    Delay(1);
                    break;
                }
            }
            Delay(1);
            if (Services.findImage(deviceID, WRONGCODE))
            {
                return "Wrong code";
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PASSWORD) == true)
                {
                    KAutoHelper.ADBHelper.InputText(deviceID, password);
                    Delay(1);
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, CONTINUE2) == true)
                        {
                            Delay(1);
                            break;
                        }
                    }
                }
                if (Services.findImage(deviceID, DONE) == true)
                {
                    return "Reg Success";
                }
                break;

            }
            // sau ddoanj nay
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

            return "Exit Success";


        }
    }
}
