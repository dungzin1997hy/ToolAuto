using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;

namespace ToolTest
{
    class GmailConfirm


    {
        #region data
        Bitmap GMAIL;
        Bitmap GOTIT;
        Bitmap ADD;
        Bitmap GOOGLE;
        Bitmap CREATEACCOUNT;
        Bitmap MYSELF;
        Bitmap FIRST;
        Bitmap LAST;
        Bitmap NEXT;
        Bitmap DAY;
        Bitmap MONTH;
        Bitmap YEAR;
        Bitmap GENDER;
        Bitmap FEMALE;
        Bitmap CREATE;
        Bitmap CREATEGMAIL;
        Bitmap ICON;
        Bitmap PASSWORD;
        Bitmap CONFIRM;
        Bitmap PHONENUMBER;
        Bitmap YES;
        Bitmap AGREE;
        Bitmap SIGNIN;
        Bitmap GOOGLEPLAY;
        Bitmap USERNAME;
        Bitmap DROPDOWN;
        Bitmap VIETNAM;
        Bitmap ALREADY;
        Bitmap VERIFY;
        Bitmap CODE;
        Bitmap ACCEPT;
        Bitmap ERRORPHONE;
        Bitmap TRYAGAIN;
        Bitmap MANAGE;
        Bitmap SIGN;
        Bitmap RESEND;
        Bitmap OK;
        Bitmap PHONE;
        





        #endregion
        public GmailConfirm()
        {
            LoadData();
        }
        void LoadData()
        {

            GMAIL = (Bitmap)Bitmap.FromFile("C://data//gmailReg//gmail.png");
            GOTIT = (Bitmap)Bitmap.FromFile("C://data//gmailReg//gotit.png");
            ADD = (Bitmap)Bitmap.FromFile("C://data//gmailReg//add.png");
            GOOGLE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//google.png");
            CREATEACCOUNT = (Bitmap)Bitmap.FromFile("C://data//gmailReg//createaccount.png");
            MYSELF = (Bitmap)Bitmap.FromFile("C://data//gmailReg//myself.png");
            FIRST = (Bitmap)Bitmap.FromFile("C://data//gmailReg//first.png");
            LAST = (Bitmap)Bitmap.FromFile("C://data//gmailReg//last.png");
            NEXT = (Bitmap)Bitmap.FromFile("C://data//gmailReg//next.png");
            DAY = (Bitmap)Bitmap.FromFile("C://data//gmailReg//day.png");
            MONTH = (Bitmap)Bitmap.FromFile("C://data//gmailReg//month.png");
            YEAR = (Bitmap)Bitmap.FromFile("C://data//gmailReg//year.png");
            GENDER = (Bitmap)Bitmap.FromFile("C://data//gmailReg//gender.png");
            FEMALE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//female.png");
            CREATE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//create.png");
            CREATEGMAIL = (Bitmap)Bitmap.FromFile("C://data//gmailReg//creategmail.png");
            ICON = (Bitmap)Bitmap.FromFile("C://data//gmailReg//icon.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("C://data//gmailReg//password2.png");
            CONFIRM = (Bitmap)Bitmap.FromFile("C://data//gmailReg//confirm.png");
            PHONENUMBER = (Bitmap)Bitmap.FromFile("C://data//gmailReg//phonenumber.png");
            YES = (Bitmap)Bitmap.FromFile("C://data//gmailReg//yes.png");
            AGREE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//agree.png");
            GOOGLEPLAY = (Bitmap)Bitmap.FromFile("C://data//gmailReg//googleplay.png");
            SIGNIN = (Bitmap)Bitmap.FromFile("C://data//gmailReg//signin.png");
            USERNAME = (Bitmap)Bitmap.FromFile("C://data//gmailReg//username.png");
            DROPDOWN = (Bitmap)Bitmap.FromFile("C://data//gmailReg//dropdown.png");
            VIETNAM = (Bitmap)Bitmap.FromFile("C://data//gmailReg//vietnam.png");

            VERIFY = (Bitmap)Bitmap.FromFile("C://data//gmailReg//verify.png");
            CODE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//code.png");
            ACCEPT = (Bitmap)Bitmap.FromFile("C://data//gmailReg//accept.png");
            ERRORPHONE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//errorphone.png");
            TRYAGAIN = (Bitmap)Bitmap.FromFile("C://data//gmailReg//tryagain.png");
            MANAGE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//manage.png");
            SIGN = (Bitmap)Bitmap.FromFile("C://data//gmailReg//sign.png");
            RESEND = (Bitmap)Bitmap.FromFile("C://data//gmailReg//resend.png");
            OK = (Bitmap)Bitmap.FromFile("C://data//gmailReg//ok.png");
            PHONE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//phone.png");

        }


        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseBigolive(String deviceID, String noxID,String username,String password)
        {

            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.android.vending");
            Delay(5);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.android.vending");

            while (true)
            {
                Delay(1);
                if(Services.findImage(deviceID, OK) == true)
                {
                    Delay(1);
                    break;
                }
                if (Services.findImage(deviceID, ICON) == true)
                {
                    Delay(1);
                    return "Open Gmail Success";
                    break;
                }
                if (Services.findImage(deviceID, TRYAGAIN) == true)
                {
                    Delay(1);
                    while (true)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, 650, 80);
                        Delay(1);
                        if (Services.findImage(deviceID, MANAGE) == true)
                        {
                            break;
                        }
                        else
                        {
                            Delay(1);
                        }
                    }

                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, SIGN))
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, SIGN, "sign");

                }

                if(Services.findImage(deviceID,SIGNIN) == true)
                {
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, PHONE))
                        {
                            Delay(1);
                            KAutoHelper.ADBHelper.InputText(deviceID,username);
                            break;
                        }
                    }
                    return "Open Gmail Success";
                    
                }
            }
            return "Open Gmail Success";
        }
        public string BigoReg(String deviceID, String firstname, String lastname, String username, String password, String phone, String simID, String day, String month, String year)
        {


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
            //    if (Services.findImage(deviceID, ICON) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}
            Services.pressImage(deviceID, ICON, "icon");

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, PASSWORD) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, password);
                    break;
                }
                Delay(1);
                if (Services.findImage(deviceID, PASSWORD) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, password);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi");
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

            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, ICON) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("dang doi icon");
            //    }
            //}
            Services.pressImage(deviceID, ICON, "icon");

            Delay(3);
            if (Services.findImage(deviceID, CODE))
            {

            }
            else
            {

                //dropdonw
                //while (true)
                //{
                //    Delay(1);
                //    if (Services.findImage(deviceID, DROPDOWN) == true)
                //    {
                //        Delay(1);

                //        break;
                //    }
                //    else
                //    {
                //        Console.WriteLine("dang doi DROPDOWN");
                //    }
                //}

                Services.pressImage(deviceID, DROPDOWN, "dropdown");
                while (true)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    if (Services.findImage(deviceID, VIETNAM) == true)
                    {
                        Delay(1);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("dang doi vietnam");
                        KAutoHelper.ADBHelper.Swipe(deviceID, 500, 1200, 500, 200);
                        Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    }
                }


                for (int i = 0; i <= 20; i++)
                {
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DEL);
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }

                //while (true)
                //{
                //    Delay(1);
                //    if (Services.findImage(deviceID, ICON) == true)
                //    {
                //        Delay(1);

                //        break;
                //    }
                //    else
                //    {
                //        Console.WriteLine("dang doi");
                //    }
                //}
                Services.pressImage(deviceID, ICON, "icon");
                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, PHONENUMBER) == true)
                    {
                        Delay(1);
                        KAutoHelper.ADBHelper.InputText(deviceID, "+84" + phone);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("dang doi");
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
                //    else
                //    {
                //        Console.WriteLine("dang doi");
                //    }
                //}
                Services.pressImage(deviceID, NEXT, "next");

                //while (true)
                //{
                //    Delay(1);
                //    if (Services.findImage(deviceID, VERIFY) == true)
                //    {
                //        Console.WriteLine("click verify");
                //        Delay(1);
                //        break;
                //    }
                //}
                Services.pressImage(deviceID, VERIFY, "verify");

                var screen = Services.ScreenShoot(deviceID);
                var errorPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, ERRORPHONE);
                if (errorPoint != null)
                {
                    return "Error Phone";
                }
            }
            int dem = 40;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0)
                {
                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, RESEND) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, RESEND, "resend");
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
                    //    if (Services.findImage(deviceID, VERIFY) == true)
                    //    {
                    //        Console.WriteLine("click verify");
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, VERIFY, "next");
                    dem = 40;
                    code = "";
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

            KAutoHelper.ADBHelper.InputText(deviceID, code);
            Delay(1);


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CODE) == true)
                {


                    KAutoHelper.ADBHelper.InputText(deviceID, code);
                    Delay(1);
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
                Delay(1);
                if(dem == 0)
                {
                    break;
                }
                if (Services.findImage(deviceID, NEXT) == true)
                {
                    Delay(1);

                    break;
                }
                else
                {
                    Console.WriteLine("dang doi");
                    dem--;
                }
            }
            Delay(5);
            dem = 5;
            while (true)
            {
                if (dem == 0)
                {
                    break;
                }
                Delay(1);
                if (Services.findImage(deviceID, OK) == true)
                {
                    Delay(1);
                    break;
                }
                else
                {
                    dem--;
                }
            }
            Delay(5);
            int temp = 10;
            while (true)
            {
                Delay(1);
                if (temp == 0)
                {
                    break;
                }
                if (Services.findImage(deviceID, ACCEPT) == true)
                {
                    break;
                }
                else
                {
                    temp--;
                }
            }

            Delay(5);
            Exit(deviceID);
            Console.WriteLine("Success : confirm success");
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
