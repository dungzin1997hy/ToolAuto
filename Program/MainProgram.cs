﻿using System;
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

        static void Main(string[] args)
        {
           

            
            ZaloService zaloService = new ZaloService();
            FaceBookService faceBookService = new FaceBookService();
            SkypeService skypeService = new SkypeService();
           
            switch (args[0])
            {
                case "run1":
                    //0: script, 1:devices id, 2: usernam, 3: password, 4: noxID
                    zaloService.run1(args[1], args[2], args[3],args[5]);
                    break;
                case "run2":
                    //0: script, 1: deviceId, 2:username, 3:password, 4: simId, 5:NoxId
                    faceBookService.run2(args[1], args[2], args[3], args[4],args[5]);
                    break;

                case "run3":
                    //0: script, 1:devices id, 2: usernam, 3: password, 4: noxID
                    skypeService.run3(args[1], args[2], args[3], args[5]);
                    break;
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
                    String result = fb.chooseFacebook(args[1],args[2]);
                    Console.WriteLine(result);
                    break;
                case "LoginFaceBook":
                    fb = new FaceBook();
                    result = fb.login(args[1], args[2], args[3],args[4]);
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
                    result = sky.chooseSkype(args[1],args[4]);
                    Console.WriteLine(result);
                    break;
                case "LoginSkype":
                    sky = new Skype();
                    result = sky.login(args[1], args[2], args[3],args[4]);
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
                    result = zalo.chooseZalo(args[1],args[2]);
                    Console.WriteLine(result);
                    result = zalo.login(args[1], args[2], args[3],args[4]);
                    Console.WriteLine(result);
                    result = zalo.logout(args[1]);
                    Console.WriteLine(result);
                    break;
                case "LoginZalo":
                    zalo = new Zalo();
                    result = zalo.login(args[1], args[2], args[3],args[4]);
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
            
           
        }
    }
}