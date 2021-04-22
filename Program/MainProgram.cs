using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ToolTest.dao;


namespace ToolTest
{

    class MainProgram
    {
        public static String linkNox = "D:\\Nox\\Nox\\bin\\Nox.exe";
        public static String linkApk = "C:\\apk";
        static int dem =300;
        public static void checktime()
        {
            dem--;
            if(dem == 0)
            {
                Console.WriteLine("Error : Something happend");
                Environment.Exit(0);
            }
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
        static void Main(string[] args)
        {
            try
            {
                //ZaloService zaloService = new ZaloService();
                //FaceBookService faceBookService = new FaceBookService();
                //SkypeService skypeService = new SkypeService();
                //LineRegService li = new LineRegService();
                LineRegService linereg = new LineRegService();
                GmailRegService li = new GmailRegService();
                ViberRegService viber = new ViberRegService();
                GmailConfirmService gmailConfirm = new GmailConfirmService();
                FaceBookRegService facebookreg = new FaceBookRegService();
                FacebookStepSevice facebookStepSevice = new FacebookStepSevice();
                GmailTwoStepService gmailstep = new GmailTwoStepService();
                GmailLoginService gmaillogin = new GmailLoginService();
                ViewYoutubeService viewYoutube = new ViewYoutubeService();
                //GmailServices gmailService = new GmailServices();
                //ViperServices viperServices = new ViperServices();
                //LineService line = new LineService();
                //WhatAppServices whatApp = new WhatAppServices();
                //TwitterService twitter = new TwitterService();
               // UberServices uber = new UberServices();

                switch (args[0])
                {
                    case "gmail_reg":
                        //0:script,1:device,2:firstname,3:lastname:username,5:password,6:phone,7:simid,8:noxID,
                        li.run3(args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11]);
                        break;
                    case "gmail_confirm":
                        //0:script,1:device,2:firstname,3:lastname:username,5:password,6:phone,7:simid,8:noxID,
                        gmailConfirm.run3(args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11]);
                        break;
                    case "gmail_step":
                        gmailstep.run3(args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11]);
                        break;
                    case "gmail_login":
                        gmaillogin.run3(args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11]);
                        break;
                    case "line_reg":
                        linereg.run3(args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8]);
                        break;
                    case "viber_reg":
                        viber.run3(args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8]);
                        break;
                    case "facebook_reg":
                        facebookreg.run3(args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11]);
                        break;
                    case "view_youtube":
                        viewYoutube.run(args[1], args[2], args[3], args[4]);
                        break;
                    case "nuoi_youtube":
                        viewYoutube.run(args[1], args[2], args[3],args[4]);
                        break;
                    case "facebook_step":
                        facebookStepSevice.run3(args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11]);
                        break;
                    //case "zalo_login_logout":
                    //    //0: script, 1:devices id, 2: usernam, 3: password, 4: noxID
                    //    zaloService.run1(args[1], args[2], args[3], args[5]);
                    //    break;
                    //case "facebook_login_logout":
                    //    //0: script, 1: deviceId, 2:username, 3:password, 4: simId, 5:NoxId
                    //    faceBookService.run2(args[1], args[2], args[3], args[4], args[5]);
                    //    break;



                    //case "skype_login_logout":
                    //    //0: script, 1:devices id, 2: usernam, 3: password, 4: simid,5:nox id, 6:phonenumber
                    //    skypeService.run3(args[1], args[2], args[3], args[4], args[6], args[5]);
                    //    break;

                    //case "gmail_login_logout":
                    //    //0: script, 1: deviceId, 2:username, 3:password, 4: simId, 5:NoxId
                    //    gmailService.runGmail(args[1], args[2], args[3], args[4], args[5]);
                    //    break;

                    //case "viper_login_logout":
                    //    viperServices.run3(args[1], args[2], args[3], args[4], args[6], args[5]);
                    //    break;
                    //case "line_login_logout":
                    //    line.run3(args[1], args[2], args[3], args[4], args[6], args[5]);
                    //    break;
                    //case "whatsapp_login_logout":
                    //    whatApp.run3(args[1], args[2], args[3], args[4], args[6], args[5]);
                    //    break;
                    //case "twitter_login_logout":
                    //    twitter.run3(args[1], args[2], args[3], args[4], args[6], args[5]);
                    //    break;
                    ////case "uber_login_logout":
                    ////    uber.run3(args[1], args[2], args[3], args[4], args[6], args[5]);
                    ////    break;
                    /////
                    ///String deviceID, String username, String password, String simID, String phoneNumber, String noxID
                    //case "linereg":
                    //    li.run3(args[1],args[2],args[3],args[4],args[5],args[6]);
                    //    break;
                    case "info":
                        List<String> devices = Services.getAllDevice();
                        Console.WriteLine(devices.Count());
                        foreach (var deviceID in devices)
                        {
                            Console.WriteLine(deviceID);
                        }
                        break;
                    case "scshoot":
                        Services.ScreenShoot(args[1], false);
                        break;
                    case "OpenFaceBook":
                        FaceBook fb = new FaceBook();
                        fb.Exit(args[1]);
                        String result = fb.chooseFacebook(args[1], args[2]);
                        Console.WriteLine(result);
                        break;
                    case "LoginFaceBook":
                        fb = new FaceBook();
                        result = fb.login(args[1], args[2], args[3], args[4]);
                        Console.WriteLine(result);
                        break;
                    case "LogoutFaceBook":
                        fb = new FaceBook();
                        result = fb.logout(args[1]);
                        Console.WriteLine(result);
                        break;
                    case "Exit":
                        FaceBookService fb1 = new FaceBookService();
                        fb1.Exit(args[1]);
                        break;
                    case "OpenSkype":
                        Skype sky = new Skype();
                        result = sky.chooseSkype(args[1], args[4]);
                        Console.WriteLine(result);
                        break;
                    case "LoginSkype":
                        sky = new Skype();
                        result = sky.login(args[1], args[2], args[3], args[4]);
                        Console.WriteLine(result);
                        break;
                    case "LogoutSkype":
                        sky = new Skype();
                        result = sky.logout(args[1]);
                        Console.WriteLine(result);
                        break;
                    case "OpenTiktok":
                        Tiktok tik = new Tiktok();
                        result = tik.chooseTiktok(args[1]);
                        Console.WriteLine(result);
                        break;
                    case "LoginTiktok":
                        tik = new Tiktok();
                        result = tik.login(args[1], args[2]);
                        Console.WriteLine(result);
                        break;
                    case "LogoutTiktok":
                        tik = new Tiktok();
                        result = tik.logout(args[1]);
                        Console.WriteLine(result);
                        break;
                    case "OpenZalo":
                        Zalo zalo = new Zalo();
                        result = zalo.chooseZalo(args[1], args[2]);
                        Console.WriteLine(result);
                        result = zalo.login(args[1], args[2], args[3], args[4]);
                        Console.WriteLine(result);
                        result = zalo.logout(args[1]);
                        Console.WriteLine(result);
                        break;
                    case "LoginZalo":
                        zalo = new Zalo();
                        result = zalo.login(args[1], args[2], args[3], args[4]);
                        Console.WriteLine(result);
                        break;
                    case "LogoutZalo":
                        zalo = new Zalo();
                        result = zalo.logout(args[1]);
                        Console.WriteLine(result);
                        break;
                    default:
                        Console.WriteLine("Not understand");
                        break;

                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Environment.Exit(0);
            }
        }
    }
}
