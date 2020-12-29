using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using Emgu.CV.Cuda;
using ToolTest.dao;

namespace ToolTest
{
    class FaceBook
    {

        #region data
        Bitmap FB;
        Bitmap LIKE;
        Bitmap CONTINUE;
        Bitmap USERNAME;
        Bitmap PASSWORD;
        Bitmap LOGIN;
        Bitmap LOGINACCOUNT;
        Bitmap WRONGUSERNAME;
        Bitmap WRONGPASSWORD;
        Bitmap WRONGCODE;
        Bitmap LOGINSUCCESS;
        Bitmap SETTING;
        Bitmap LOGOUT;
        Bitmap LOGGING;
        Bitmap OK;
        Bitmap RETRY;
        Bitmap LOGINFAILED;
        Bitmap NEEDCODE;
        Bitmap CODE;
        Bitmap SAVEINFO;
        Bitmap INTERNETERROR;
        Bitmap FBICON;
        Bitmap FRIEND;
        Bitmap SKIP;
        Bitmap NOTNOW;
        Bitmap YESCONTINUE;
        #endregion
        public FaceBook()
        {
            LoadData();
        }
        void LoadData()
        {
            FB = (Bitmap)Bitmap.FromFile("C://data//facebook//fb.png");
            LIKE = (Bitmap)Bitmap.FromFile("C://data//facebook//like.png");
            CONTINUE = (Bitmap)Bitmap.FromFile("C://data//facebook//continue.png");
            USERNAME = (Bitmap)Bitmap.FromFile("C://data//facebook//username.png");
            PASSWORD = (Bitmap)Bitmap.FromFile("C://data//facebook//password.png");
            LOGIN = (Bitmap)Bitmap.FromFile("C://data//facebook//login.png");
            LOGINACCOUNT = (Bitmap)Bitmap.FromFile("C://data//facebook//loginaccount.png");
            WRONGUSERNAME = (Bitmap)Bitmap.FromFile("C://data//facebook//wrongusername.png");
            WRONGPASSWORD = (Bitmap)Bitmap.FromFile("C://data//facebook//wrongpassword.png");
            LOGINSUCCESS = (Bitmap)Bitmap.FromFile("C://data//facebook//loginsuccess.png");
            SETTING = (Bitmap)Bitmap.FromFile("C://data//facebook//setting.png");
            LOGOUT = (Bitmap)Bitmap.FromFile("C://data//facebook//logout.png");
            LOGGING = (Bitmap)Bitmap.FromFile("C://data//facebook//logging.png");
            OK = (Bitmap)Bitmap.FromFile("C://data//facebook//OK.png");
            RETRY = (Bitmap)Bitmap.FromFile("C://data//facebook//retry.png");
            LOGINFAILED = (Bitmap)Bitmap.FromFile("C://data//facebook//loginfailed.png");
            NEEDCODE = (Bitmap)Bitmap.FromFile("C://data//facebook//needcode.png");
            CODE = (Bitmap)Bitmap.FromFile("C://data//facebook//code.png");
            SAVEINFO = (Bitmap)Bitmap.FromFile("C://data//facebook//saveinfo.png");
            INTERNETERROR = (Bitmap)Bitmap.FromFile("C://data//facebook//interneterror.png");
            FBICON = (Bitmap)Bitmap.FromFile("C://data//facebook//fbicon.png");
            FRIEND = (Bitmap)Bitmap.FromFile("C://data//facebook//friend.png");
            SKIP = (Bitmap)Bitmap.FromFile("C://data//facebook//skip.png");
            NOTNOW = (Bitmap)Bitmap.FromFile("C://data//facebook//notnow.png");
            YESCONTINUE = (Bitmap)Bitmap.FromFile("C://data//facebook//yescontinue.png");
            WRONGCODE = (Bitmap)Bitmap.FromFile("C://data//facebook//wrongcode.png");

        }
        public void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string chooseFacebook(String deviceID, String noxID)
        {
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.facebook.katana ");
            Delay(3);
            Exit(deviceID);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox+ "-clone:" + noxID + " -package:com.facebook.katana");
            Console.WriteLine("adb -s " + deviceID + " shell pm clear com.facebook.katana ");
            int count = 20;
            while (true)
            {
                if (count == 0)
                {
                    Console.WriteLine("install facebook ");
                    KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox +" -clone:" + noxID + " \"-apk:"+MainProgram.linkApk+"\\Facebook.apk\"");
                    Delay(1);
                    while (true)
                    {
                        var screen1 = Services.ScreenShoot(deviceID);
                        var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINSUCCESS);
                        var loginAccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINACCOUNT);
                        var usernamePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, USERNAME);
                        var loginPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGIN);

                        if (loginPoint1 != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, loginPoint1.Value.X, loginPoint1.Value.Y);
                            Delay(1);
                            break;
                        }
                        if (loginsuccessPoint != null || loginAccountPoint != null || usernamePoint != null)
                        {
                            break;
                        }
                        else Delay(1);


                    }
                    return "Open FaceBook Success";
                }
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
        public string login(String deviceID, String username, String password, String noxID)
        {
            String result = "";
            while (true)
            {
                Console.WriteLine("doi khoi dong xong");
                var screen1 = Services.ScreenShoot(deviceID);
                var loginsuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINSUCCESS);
                var loginAccountPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGINACCOUNT);
                var usernamePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, USERNAME);
                var loginPoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, LOGIN);

                if (loginPoint1 != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, loginPoint1.Value.X, loginPoint1.Value.Y);
                    Delay(1);
                    break;
                }
                if (loginsuccessPoint != null || loginAccountPoint != null || usernamePoint != null)
                {
                    break;
                }
                else Delay(1);


            }
            if (checkLogin(deviceID) == true)
            {
                Console.WriteLine("da dang nhap");
                Console.WriteLine("doi dang xuat");
                logout(deviceID);
                Exit(deviceID);
                chooseFacebook(deviceID, noxID);
                Delay(1);
            }

            var screen = Services.ScreenShoot(deviceID);
            var LOGINACCOUNTpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINACCOUNT);
            if (LOGINACCOUNTpoint != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, LOGINACCOUNTpoint.Value.X, LOGINACCOUNTpoint.Value.Y);

            }
            Delay(1);
            int dem = 3;
            while (true)
            {
                if (dem < 3)
                {
                    screen = Services.ScreenShoot(deviceID);
                    var PASSWORDpoint1 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PASSWORD);
                    if (PASSWORDpoint1 != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, PASSWORDpoint1.Value.X, PASSWORDpoint1.Value.Y);
                        KAutoHelper.ADBHelper.InputText(deviceID, password);
                    }
                    Delay(1);
                }
                if (dem == 3)
                {
                    while (true)
                    {
                        Delay(1);
                        if (Services.findImage(deviceID, USERNAME) == true)
                        {
                            Console.WriteLine("click username");
                            break;
                        }
                        else Console.WriteLine("khong tim thay nut username");
                    }
                    KAutoHelper.ADBHelper.InputText(deviceID, username);
                    Delay(1);

                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 50, 20);

                    //Delay(2);
                    //screen = Services.ScreenShoot(deviceID);
                    //var USERNAMEpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, USERNAME);
                    //if (USERNAMEpoint != null)
                    //{
                    //    Console.WriteLine("nhap username");
                    //    KAutoHelper.ADBHelper.Tap(deviceID, USERNAMEpoint.Value.X, USERNAMEpoint.Value.Y);
                    //    KAutoHelper.ADBHelper.InputText(deviceID, username);
                    //    KAutoHelper.ADBHelper.TapByPercent(deviceID, 46.5, 20);
                    //}
                    //Delay(1);

                    
                }

                while (true)
                {
                    Delay(1);
                    if (Services.findImage(deviceID, PASSWORD) == true)
                    {
                        Console.WriteLine("click password");
                        break;
                    }
                    else Console.WriteLine("khong tim thay nut username");
                }
                KAutoHelper.ADBHelper.InputText(deviceID, password);
                Delay(1);
                //screen = Services.ScreenShoot(deviceID);
                //var PASSWORDpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, PASSWORD);
                //if (PASSWORDpoint != null)
                //{
                //    Console.WriteLine("nhap passwowrd");
                //    KAutoHelper.ADBHelper.Tap(deviceID, PASSWORDpoint.Value.X, PASSWORDpoint.Value.Y);
                //    KAutoHelper.ADBHelper.InputText(deviceID, password);
                //}
                //Delay(1);



                screen = Services.ScreenShoot(deviceID);
                var LOGINpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGIN);
                if (LOGINpoint != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, LOGINpoint.Value.X, LOGINpoint.Value.Y);

                }
                Delay(3);
                while (true)
                {
                    Delay(1);
                    if(Services.findImage(deviceID,LOGIN) == false)
                    {
                        break;
                    }
                }
                //ĐỢI LOGIN
                Boolean logging = true;
                while (logging)
                {
                    Console.WriteLine("dang doi dang nhap");
                    screen = Services.ScreenShoot(deviceID);
                    var LOGGINGpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGGING);

                    if (LOGGINGpoint == null)
                    {
                        Console.WriteLine("loging xong");
                        logging = false;
                    }
                    Delay(1);
                }
                Delay(5);

                // CHECK LỖI
                screen = Services.ScreenShoot(deviceID);
                var WrongUserPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGUSERNAME);
                var WrongPassWordPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGPASSWORD);
                var InterneterrorPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, INTERNETERROR);
                var loginSuccessPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                var yesContinuePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, YESCONTINUE);
                var findFriendPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, FRIEND);
                if (InterneterrorPoint != null)
                {

                    return "Internet Error";
                }
                // LỖI SAI TK, TẮT APP

                if (WrongUserPoint != null)
                {
                    Console.WriteLine("sai tai khoan");
                    return "Wrong Username";
                }

                // LỖI SAI MK, NHẬP LẠI MK
                if (WrongPassWordPoint != null)
                {
                    Console.WriteLine("sai mat khau");
                    var Okpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, OK);
                    KAutoHelper.ADBHelper.Tap(deviceID, Okpoint.Value.X, Okpoint.Value.Y);
                    Delay(1);
                    dem--;
                }

                if (loginSuccessPoint != null)
                {
                    Console.WriteLine("dang nhap thanh cong");
                    return "Login Success";
                }

                if (findFriendPoint != null)
                {
                    skipFriendPoint(deviceID);
                    return "Login Success";

                }

                if (WrongPassWordPoint != null && dem == 0)
                {
                    return "Wrong Password";
                }
                if (WrongUserPoint == null && WrongPassWordPoint == null)
                {
                    Delay(2);
                    Console.WriteLine("can code ");
                    return "Need Code";
                }


            }
            return result;

        }


        public string inputCode(String deviceID, String simID)
        {

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, NEEDCODE) == true)
                {
                    Console.WriteLine("click needcode");
                    Delay(5);
                    break;
                }
                else Console.WriteLine("khong tim thay nut need code");

            }

            //while (true)
            //{
            //    Console.WriteLine("doi bang need code");
            //    var screen1 = Services.ScreenShoot(deviceID);
            //    var needcodePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, NEEDCODE);
            //    if (needcodePoint != null)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Delay(1);
            //    }
            //}


            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, OK) == true)
                {
                    Console.WriteLine("click ok");
                    Delay(5);
                    break;
                }
                else Console.WriteLine("khong tim thay nut ok");

            }
            //var screen = Services.ScreenShoot(deviceID);
            //var OKPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, OK);
            //if (OKPoint != null)
            //{
            //    Console.WriteLine("click ok can code");
            //    KAutoHelper.ADBHelper.Tap(deviceID, OKPoint.Value.X, OKPoint.Value.Y);
            //    Delay(1);
            //}


            int dem = 80;
            String code = "";
            while (true)
            {
                Delay(20);
                if (dem == 0) break;
                code = MessageDAO.getCodeFacebook(simID,MessageDAO.FBsql);
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
                if (Services.findImage(deviceID, CODE) == true)
                {
                    Console.WriteLine("click code");
                    Delay(5);
                    break;
                }
                else Console.WriteLine("khong tim thay nut code");

            }

            //screen = Services.ScreenShoot(deviceID);
            //var codePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CODE);
            //if (codePoint != null)
            //{
            //    Console.WriteLine("click vaof code");
            //    KAutoHelper.ADBHelper.Tap(deviceID, codePoint.Value.X, codePoint.Value.Y);
            //    Delay(1);
            //}

            KAutoHelper.ADBHelper.InputText(deviceID, code);
            Delay(2);

            //while (true)
            //{
            //    Delay(1);
            //    screen = Services.ScreenShoot(deviceID);
            //    var continuePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, CONTINUE);
            //    if (continuePoint != null)
            //    {
            //        Console.WriteLine("nhan continue");
            //        KAutoHelper.ADBHelper.Tap(deviceID, continuePoint.Value.X, continuePoint.Value.Y);
            //        Delay(5);
            //        break;
            //    }
            //    else Console.WriteLine("khong thay nut continue");
            //}

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CONTINUE) == true)
                {
                    Console.WriteLine("click continue");
                    Delay(5);
                    break;
                }
                else Console.WriteLine("khong tim thay nut continue");
            }


            if (Services.findImage(deviceID, WRONGCODE) == true)
            {
                Console.WriteLine("Wrong code");
                return "Wrong Auth Code";
            }

            if (Services.findImage(deviceID, WRONGCODE) == true)
            {
                Console.WriteLine("Wrong code");
                return "Wrong Auth Code";
            }

            //screen = Services.ScreenShoot(deviceID);
            //codePoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, WRONGCODE);
            //if (codePoint != null)
            //{
            //    Console.WriteLine("sai code ");
            //    return "Wrong Auth Code";
            //}


            //while (true)
            //{
            //    screen = Services.ScreenShoot(deviceID);
            //    var loggingPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGGING);

            //    if (loggingPoint == null)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Delay(1);
            //    }
            //}

            while (true)
            {
                if (Services.findImage(deviceID, LOGGING) == true)
                {
                    Console.WriteLine("dang doi loging");
                    Delay(1);
                }
                else
                {
                    break;
                }
            }

            skipFriendPoint(deviceID);
            return "Login Success";
        }

        public void skipFriendPoint(String deviceID)
        {
            Delay(5);

            if (Services.findImage(deviceID, SKIP) == true)
            {
                Console.WriteLine("tim thay ban be");

            }
            else Console.WriteLine("khong tim thay ban be");
            Delay(5);

            if (Services.findImage(deviceID, SKIP) == true)
            {
                Console.WriteLine("tim thay ban be");

            }
            else Console.WriteLine("khong tim thay ban be");

            Delay(10);
            while (true)
            {
                Console.WriteLine("dang doi not now");
               var screen = Services.ScreenShoot(deviceID);
                var loginSuccesPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, LOGINSUCCESS);
                var notNowPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, NOTNOW);
                if (notNowPoint != null)
                {
                    Console.WriteLine("click not now");
                    KAutoHelper.ADBHelper.Tap(deviceID, notNowPoint.Value.X, notNowPoint.Value.Y);
                    Delay(1);
                    break;
                }
                if (loginSuccesPoint != null)
                {
                    Delay(1);
                    break;
                }
            }
            Delay(3);

        }

        public string logout(String deviceID)
        {
            Exit(deviceID);
            //while (true)
            //{

            //    var screen1 = Services.ScreenShoot(deviceID);
            //    var SETTINGpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, SETTING);
            //    if (SETTINGpoint != null)
            //    {
            //        KAutoHelper.ADBHelper.Tap(deviceID, SETTINGpoint.Value.X, SETTINGpoint.Value.Y);
            //        Delay(1);
            //        break;

            //    }
            //    Delay(1);
            //}

            //Delay(3);
            //KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 50, 90, 50, 10);
            //Delay(2);
            //while (true)
            //{
                
            //    Delay(1);
            //    if(Services.findImage(deviceID,LOGOUT) == true)
            //    {
            //        Console.WriteLine("click logout");
            //        break;
            //    }
            //}

           
            return "Logout Success";


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
                KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.facebook.katana ");
                Delay(1);
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return "Exit Success";

        }


        Boolean checkLogin(String deviceID)
        {
            Boolean isLogin = false;

            var screen = Services.ScreenShoot(deviceID);
            var SAVEINFOpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, SAVEINFO);
            if (SAVEINFOpoint != null)
            {

                var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, OK);

                Console.WriteLine(point.Value.X);
                KAutoHelper.ADBHelper.Tap(deviceID, point.Value.X, point.Value.Y);
                Delay(1);

            }

            screen = Services.ScreenShoot(deviceID);
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

