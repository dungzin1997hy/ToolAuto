using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using ToolTest.dao;
namespace ToolTest
{
    class GmailReg

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
        Bitmap GETNEWCODE;





        #endregion
        public GmailReg()
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
            PASSWORD = (Bitmap)Bitmap.FromFile("C://data//gmailReg//password.png");
            CONFIRM = (Bitmap)Bitmap.FromFile("C://data//gmailReg//confirm.png");
            PHONENUMBER = (Bitmap)Bitmap.FromFile("C://data//gmailReg//phonenumber.png");
            YES = (Bitmap)Bitmap.FromFile("C://data//gmailReg//yes.png");
            AGREE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//agree.png");
            GOOGLEPLAY = (Bitmap)Bitmap.FromFile("C://data//gmailReg//googleplay.png");
            SIGNIN = (Bitmap)Bitmap.FromFile("C://data//gmailReg//signin.png");
            USERNAME = (Bitmap)Bitmap.FromFile("C://data//gmailReg//username.png");
            DROPDOWN = (Bitmap)Bitmap.FromFile("C://data//gmailReg//dropdown.png");
            VIETNAM = (Bitmap)Bitmap.FromFile("C://data//gmailReg//vietnam.png");
            ALREADY = (Bitmap)Bitmap.FromFile("C://data//gmailReg//already.png");
            GETNEWCODE = (Bitmap)Bitmap.FromFile("C://data//gmailReg//getnewcode.png");

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
            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, SIGNIN) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}
            Services.pressImage(deviceID, SIGNIN, "sign in");
            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, CREATEACCOUNT) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}
            Services.pressImage(deviceID, CREATEACCOUNT, "create account");
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
                    Console.WriteLine(deviceID+" "+temp);
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
        public string BigoReg(String deviceID, String firstname, String lastname, String username, String password, String phone, String simID,String day, String month,String year)
        {


            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, SIGNIN) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}
            Services.pressImage(deviceID, SIGNIN, "signin");
            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, CREATEACCOUNT) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}
            Services.pressImage(deviceID, CREATEACCOUNT, "create account");
            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, MYSELF) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("dang doi");
            //    }
            //}
            Services.pressImage(deviceID, MYSELF, "myself");

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, FIRST) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, firstname);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi");
                }
            }
            Thread thread1 = new Thread(() =>
              checkRestart(deviceID)
           );
            thread1.Start();
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, LAST) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, lastname);
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
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, DAY) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID,  day);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi");
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, MONTH) == true)
                {
                    Delay(1);
                    int monthnumber = Int32.Parse(month);
                    for (int i = 0; i < monthnumber; i++)
                    {
                        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_DPAD_DOWN);
                    }
                    Thread.Sleep(TimeSpan.FromMilliseconds(500));
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi");
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, YEAR) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, year);
                    break;
                }
                else
                {
                    Console.WriteLine("dang doi");
                }
            }


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, GENDER) == true)
                {

                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, FEMALE) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("dang doi");
                    //    }
                    //}
                    Services.pressImage(deviceID, FEMALE, "female");
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
            //NHAP
            while (true)
            {
                var screen2 = Services.ScreenShoot(deviceID);
                var usernamepoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, USERNAME);
                var creategmailpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, CREATE);
                if (usernamepoint != null)
                {
                    while (true)
                    {
                        Services.findImage(deviceID, ICON);
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
                    //        Console.WriteLine("dang doi next");
                    //    }
                    //}
                    Services.pressImage(deviceID, NEXT, "next");
                    var screen3 = Services.ScreenShoot(deviceID);
                    var alreadyPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen3, ALREADY);
                    if (alreadyPoint != null)
                    {
                        return "Already Have Account";
                    }
                    break;
                }
                if (creategmailpoint != null)
                {
                    //while (true)
                    //{
                    //    Delay(1);
                    //    if (Services.findImage(deviceID, CREATE) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("dang doi create");
                    //    }
                    //}
                    Services.pressImage(deviceID, CREATE, "create");

                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, CREATEGMAIL) == true)
                        {
                            Delay(1);
                            KAutoHelper.ADBHelper.InputText(deviceID, username);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("dang doi creategmail");
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
                    //        Console.WriteLine("dang doi next");
                    //    }
                    //}
                    Services.pressImage(deviceID, NEXT, "next");
                    break;
                }
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
                if (Services.findImage(deviceID, ICON)) 
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
            var screen = Services.ScreenShoot(deviceID);
            var confirmPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CONFIRM);
            if (confirmPoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, confirmPoint.Value.X, confirmPoint.Value.Y);
                Delay(1);
                KAutoHelper.ADBHelper.InputText(deviceID, password);
            }
            Delay(1);
            screen = Services.ScreenShoot(deviceID);
            confirmPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CONFIRM);
            if (confirmPoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, confirmPoint.Value.X, confirmPoint.Value.Y);
                Delay(1);
                KAutoHelper.ADBHelper.InputText(deviceID, password);
            }
            Delay(1);


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
                    KAutoHelper.ADBHelper.InputText(deviceID,"+84"+phone);
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
                    //    if(Services.findImage(deviceID,GETNEWCODE) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}
                    Services.pressImage(deviceID, GETNEWCODE, "getnewcode");
                    //while (true)
                    //{
                    //    Delay(1);
                    //    if(Services.findImage(deviceID,NEXT) == true)
                    //    {
                    //        Delay(1);
                    //        break;
                    //    }
                    //}

                    Services.pressImage(deviceID, NEXT, "next");
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
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, ICON) == true)
                {
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
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, YES) == true)
                {
                    Delay(1);

                    break;
                }
                else
                {
                    KAutoHelper.ADBHelper.Swipe(deviceID, 350, 1100, 350, 200);
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

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, ICON) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 350, 1100, 350, 200);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 350, 1100, 350, 200);
                    break;
                }
            }

            //while (true)
            //{
            //    Delay(1);
            //    if (Services.findImage(deviceID, AGREE) == true)
            //    {
            //        Delay(1);
            //        break;
            //    }
            //}
            Services.pressImage(deviceID, AGREE, "agree");

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
