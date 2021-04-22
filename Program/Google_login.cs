using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class Google_login


    {
        #region data
        Bitmap GMAIL;

        Bitmap CREATEACCOUNT;

        Bitmap SIGNIN;
        Bitmap USERNAME;
        Bitmap NEXT;
        Bitmap GOOGLE;
        Bitmap PASSWORD;
        Bitmap MESSAGE;
        Bitmap CODE;
        Bitmap WRONGCODE;
        Bitmap YES;
        Bitmap AGREE;
        Bitmap ACCEPT;
        Bitmap PHONE;
        Bitmap VERIFY;






        #endregion
        public Google_login()
        {
            LoadData();
        }
        void LoadData()
        {
            GMAIL = (Bitmap)Bitmap.FromFile("C://data//gmailReg//gmail.png");
            CREATEACCOUNT = (Bitmap)Bitmap.FromFile("C://data//gmailReg//createaccount.png");
            SIGNIN = (Bitmap)Bitmap.FromFile("C://data//gmailReg//signin.png");
            USERNAME = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//username.png");
            NEXT = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//next.png");
            GOOGLE = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//google.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//password.png");
            MESSAGE = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//message.png");
            CODE = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//code.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//wrongcode.png");
            YES = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//yes.png");
            AGREE = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//agree.png");
            ACCEPT = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//accept.png");
            PHONE = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//phone.png");
            VERIFY = (Bitmap)Bitmap.FromFile("C://data//gmaillogin//verify.png");
        }


        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseBigolive(String deviceID, String noxID)
        {

            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.android.vending");
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SIGNIN) == true)
                {
                    Delay(1);
                    break;
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CREATEACCOUNT) == true)
                {
                    Delay(1);
                    break;
                }
            }
            Delay(20);
            int temp = 30;
            while (true)
            {
                Delay(1);
                if (temp == 0)
                {
                    break;
                }
                if (Services.findImage(deviceID, SIGNIN) == true)
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
            Exit(deviceID);

            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.android.vending");
            return "Open Gmail Success";
        }
        public void checkRestart(String deviceID)
        {
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                if (Services.findImage(deviceID, CREATEACCOUNT) == true)
                {
                    Console.WriteLine("Error : openapp");
                    Environment.Exit(0);
                }
            }
        }
        public string BigoReg(String deviceID, String firstname, String lastname, String username, String password, String phone, String simID, String day, String month, String year)
        {
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SIGNIN) == true)
                {
                    Delay(1);

                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, USERNAME) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, username);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi username");
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
                else
                {
                    Console.WriteLine("dang doi next");
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, GOOGLE) == true)
                {
                    Services.findImage(deviceID, GOOGLE);
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi google");
                }
            }
            Thread thread1 = new Thread(() =>
            checkRestart(deviceID)
         );
            thread1.Start();
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PASSWORD) == true)
                {
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
                if (Services.findImage(deviceID, NEXT) == true)
                {
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi next");
                }
            }


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, GOOGLE) == true)
                {
                    Services.findImage(deviceID, GOOGLE);
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi google");
                }
            }
            Delay(3);
            if (Services.findImage(deviceID, CODE))
            {
                int dem1 = 60;
                String code1 = "";
                while (true)
                {
                    Delay(20);
                    if (dem1 == 0)
                    {

                        return "Dont have Auth code";
                    }
                    code1 = MessageDAO.getCodeGmail(simID, MessageDAO.FBsql);
                    if (code1 == "" || code1 == null)
                    {
                        Console.WriteLine("DANG DOI TIN NHAN");
                        dem1 -= 20;
                    }
                    else
                    {

                        break;
                    }

                }
                KAutoHelper.ADBHelper.InputText(deviceID, code1);
                Delay(1);
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
                    Delay(1);
                    if (Services.findImage(deviceID, PHONE) == true)
                    {
                        Delay(1);
                        KAutoHelper.ADBHelper.InputText(deviceID, "+84" + phone);
                        Delay(1);
                        break;
                    }
                }
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
                    if (Services.findImage(deviceID, VERIFY) == true)
                    {
                        break;
                    }
                }

                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, GOOGLE) == true)
                    {
                        break;
                    }
                }

                //dem1 = 60;
                //code1 = "";
                //while (true)
                //{
                //    Delay(20);
                //    if (dem1 == 0)
                //    {

                //        return "Dont have Auth code";
                //    }
                //    code1 = MessageDAO.getCodeGmail(simID, MessageDAO.FBsql);
                //    if (code1 == "" || code1 == null)
                //    {
                //        Console.WriteLine("DANG DOI TIN NHAN");
                //        dem1 -= 20;
                //    }
                //    else
                //    {

                //        break;
                //    }

                //}

                //while (true)
                //{
                //    Delay(1);
                //    if (Services.findImage(deviceID, CODE) == true)
                //    {
                //        Delay(1);
                //        KAutoHelper.ADBHelper.InputText(deviceID, code1);
                //        break;
                //    }
                //}
                //while (true)
                //{
                //    Delay(1);
                //    if (Services.findImage(deviceID, NEXT) == true)
                //    {
                //        Delay(1);
                //        break;
                //    }
                //}

            }
            ////doi message
            else
            {
                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, MESSAGE) == true)
                    {
                        Delay(1);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("dang doi message");
                    }
                }
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, GOOGLE) == true)
                {
                    Services.findImage(deviceID, GOOGLE);
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi google");
                }
            }


            int dem = 80;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0)
                {

                    return "Dont have Auth code";
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

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CODE) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, code);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi");
                }
            }


            Delay(1);

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, NEXT) == true)
                {
                    Delay(1);

                    break;
                }
                else
                {
                    Console.WriteLine("dang doi");
                }
            }

            Delay(2);
            if (Services.findImage(deviceID, WRONGCODE) == true)
            {
                return "Wrong Auth Code";
            }


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, GOOGLE) == true)
                {
                    Services.findImage(deviceID, GOOGLE);
                    Delay(1);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 350, 1100, 350, 200);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 350, 1100, 350, 200);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi");
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
                if (Services.findImage(deviceID, YES) == true)
                {
                    Delay(1);

                    break;
                }
                else
                {
                    dem--;
                    Console.WriteLine("dang doi");
                }
            }



            dem = 5;
            while (true)
            {
                if (dem == 0) { break; }
                Delay(1);
                if (Services.findImage(deviceID, AGREE) == true)
                {
                    Delay(1);
                    break;
                }
                else
                {
                    dem--;

                }

            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, ACCEPT) == true)
                {
                    Delay(1);

                    break;
                }
            }



            Delay(5);
            Exit(deviceID);

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
