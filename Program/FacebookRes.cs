using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using ToolTest.dao;

namespace ToolTest
{

    class FacebookRes
    {
        #region data

        Bitmap USERNAME;
        Bitmap LOGINACCOUNT;
        Bitmap LOGINSUCCESS;
        Bitmap FBICON;
        Bitmap LOGIN;
        Bitmap NEWACCOUNT;
        Bitmap NEXT;
        Bitmap NAME;
        Bitmap FEMALE;
        Bitmap DELETE;
        Bitmap PASSWORD;
        Bitmap SIGNUP;
        Bitmap CREATING;
        Bitmap COULDNT;
        Bitmap ADDPHONE;
        Bitmap PHONENUMBER;
        Bitmap SENDCODE;
        Bitmap CODEINPUT;
        Bitmap CONFIRM;
        Bitmap SAVEPASSWORD;
        Bitmap SAVEPASSWORD2;
        Bitmap OK2;
        Bitmap EMAIL;
        Bitmap YES;
        Bitmap YESEMAIL;

        #endregion
        public FacebookRes()
        {
            LoadData();
        }
        void LoadData()
        {

            USERNAME = (Bitmap)Bitmap.FromFile("C://data//facebookreg//username.png");
            LOGINACCOUNT = (Bitmap)Bitmap.FromFile("C://data//facebookreg//loginaccount.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("C://data//facebookreg//loginsuccess.png");
            FBICON = (Bitmap)Bitmap.FromFile("C://data//facebookreg//fbicon.png");
            LOGIN = (Bitmap)Bitmap.FromFile("C://data//facebookreg//login.png");
            NEWACCOUNT = (Bitmap)Bitmap.FromFile("C://data//facebookreg//newaccount.png");
            NEXT = (Bitmap)Bitmap.FromFile("C://data//facebookreg//next.png");
            NAME = (Bitmap)Bitmap.FromFile("C://data//facebookreg//name.png");
            FEMALE = (Bitmap)Bitmap.FromFile("C://data//facebookreg//female.png");
            DELETE = (Bitmap)Bitmap.FromFile("C://data//facebookreg//delete.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("C://data//facebookreg//password.png");
            SIGNUP = (Bitmap)Bitmap.FromFile("C://data//facebookreg//signup.png");
            CREATING = (Bitmap)Bitmap.FromFile("C://data//facebookreg//creating.png");
            COULDNT = (Bitmap)Bitmap.FromFile("C://data//facebookreg//couldnt.png");
            ADDPHONE = (Bitmap)Bitmap.FromFile("C://data//facebookreg//addphone.png");
            PHONENUMBER = (Bitmap)Bitmap.FromFile("C://data//facebookreg//phonenumber.png");
            SENDCODE = (Bitmap)Bitmap.FromFile("C://data//facebookreg//sendcode.png");
            CODEINPUT = (Bitmap)Bitmap.FromFile("C://data//facebookreg//codeinput.png");
            CONFIRM = (Bitmap)Bitmap.FromFile("C://data//facebookreg//confirm.png");
            SAVEPASSWORD = (Bitmap)Bitmap.FromFile("C://data//facebookreg//savepassword.png");
            SAVEPASSWORD2 = (Bitmap)Bitmap.FromFile("C://data//facebookreg//savepassword2.png");
            EMAIL = (Bitmap)Bitmap.FromFile("C://data//facebookreg//email.png");
            OK2 = (Bitmap)Bitmap.FromFile("C://data//facebookreg//ok2.png");
            YES = (Bitmap)Bitmap.FromFile("C://data//facebookreg//yes.png");
            YESEMAIL = (Bitmap)Bitmap.FromFile("C://data//facebookreg//yesemail.png");
            
        }
        public void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }

        public string Exit(String deviceID)
        {
            try
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
                //KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.facebook.katana ");
                Delay(1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return "Exit Success";

        }

        public string chooseFacebook(String deviceID, String noxID)
        {
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.facebook.katana ");
            Delay(3);
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " \"-apk:" + MainProgram.linkApk + "\\Facebook.apk\"");
            Console.WriteLine("adb -s " + deviceID + " shell pm clear com.facebook.katana ");
            int count = 20;
            while (true)
            {
                
                Console.WriteLine("dag doi len");
                var screen = Services.ScreenShoot(deviceID);
                var FBIconPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, FBICON);
                var loginsuccessPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                var loginAccountPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINACCOUNT);
                var usernamePoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, USERNAME);
                var loginPoint11 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGIN);

                if (FBIconPoint != null || loginsuccessPoint1 != null || loginAccountPoint1 != null || usernamePoint1 != null || loginPoint11 != null)
                {
                    return "Open FaceBook Success";

                }
                else
                {
                    Delay(1);
                    count--;
                }
            }

        }

        public string facebookreg(String deviceId, String firstname, String lastname,String phonenumber,String password,String simID)
        {
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, NEWACCOUNT) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut dang ki");
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, NEXT) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut NEXT");
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, NAME) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut NAME");
            }


            KAutoHelper.ADBHelper.Tap(deviceId, 80, 400);
            Delay(1);
            KAutoHelper.ADBHelper.InputText(deviceId, firstname);
            Delay(1);
            KAutoHelper.ADBHelper.Tap(deviceId, 400, 400);
            Delay(1);
            KAutoHelper.ADBHelper.InputText(deviceId, lastname);
            Delay(1);

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, NEXT) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut NEXT");
            }

            KAutoHelper.ADBHelper.Swipe(deviceId, 456, 443,456,1250);
            Delay(1);
            KAutoHelper.ADBHelper.Swipe(deviceId, 456, 443,456,1250);

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, NEXT) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut NEXT");
            }


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, FEMALE) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut female");
            }
            
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, NEXT) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut NEXT");
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, DELETE) == true)
                {

                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceId, phonenumber);
                    break;
                }
                else
                    Console.WriteLine("tim nut DELETE");
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, NEXT) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut NEXT");
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, PASSWORD) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceId, password);
                    break;
                }
                else
                    Console.WriteLine("tim nut password");
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, NEXT) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut NEXT");
            }


            //ddoan nay thi phai

            int dem = 5;
            while (true)
            {
                if(dem ==0)
                {
                    break;
                }
                Delay(1);
                if(Services.findImage(deviceId,EMAIL) == true)
                {
                    Delay(1);
                    while (true)
                    {
                        Delay(1);
                        if(Services.findImage(deviceId,YES) == true)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    dem--;
                }
            }

//////cos mail r cos khi khong can nhap code
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, SIGNUP) == true)
                {
                    break;
                }
                else
                    Console.WriteLine("tim nut singup");
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, CREATING) == true)
                {
                    Console.WriteLine("dang doi tao tai khoan");
                }
                else
                {
                    Console.WriteLine("het doi tao tai khoan");
                    break;
                }
            }
            Delay(10);
            var screen = Services.ScreenShoot(deviceId);
            var couldnotPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, COULDNT);
            if(couldnotPoint != null)
            {
                Console.WriteLine ("Error: Couldn't create account");
                return "Couldn't create account";
            }
            //batdau click doi den nut nhap code
            dem = 5;
            while (true) {
                if(dem == 0)
                {
                    break;
                }
                Delay(1);
                if(Services.findImage(deviceId,SAVEPASSWORD2) == true)
                {
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
                if (Services.findImage(deviceId, SAVEPASSWORD) == true)
                {
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
                if (Services.findImage(deviceId, OK2) == true)
                {
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
                if(Services.findImage(deviceId,YESEMAIL) == true)
                {
                    Delay(1);
                    break;
                }
            }
            // click ok neu co

///kiemer tra co phair nhap code ko, neu ko thif bo qua


            
            //ket thuc nhap code
            dem = 80;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0) break;
                code = MessageDAO.getCodeFacebook(simID, MessageDAO.FBsql);
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
                code = MessageDAO.getCodeFacebook(simID, "");
                Console.WriteLine("Code: " + code);
                if (code.Equals("") || code == null)
                {
                    return "Dont have Auth code";
                }
            }


            while (true)
            {
                Delay(1);
                if(Services.findImage(deviceId,CODEINPUT) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceId, code);
                    break;
                }
            }

            
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceId, CONFIRM) == true)
                {
                    Delay(1);
                    break;
                }
                else
                {
                    Console.WriteLine("doi CONFIRM code");
                }
            }
            Delay(10);
            return "Reg Success";
        }
    }
}
