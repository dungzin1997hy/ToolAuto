using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using ToolTest.dao;

namespace ToolTest
{
    class ViewYoutube


    {
        #region data
        Bitmap YOUTUBE;
        Bitmap SEARCH;
        Bitmap LINK;
        Bitmap SUBCRIBE;



        #endregion
        public ViewYoutube()
        {
            LoadData();
        }
        void LoadData()
        {

            YOUTUBE = (Bitmap)Bitmap.FromFile("C://data//youtube//youtube.png");
            SEARCH = (Bitmap)Bitmap.FromFile("C://data//youtube//search.png");
            LINK = (Bitmap)Bitmap.FromFile("C://data//youtube//link.png");
          //  SUBCRIBE = (Bitmap)Bitmap.FromFile("E://data//youtube//subcribe.png");

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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear com.google.android.youtube");
            Delay(1);
            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.google.android.youtube");

            int temp = 30;
            while (true)
            {
                Delay(1);
                if (temp == 0)
                {
                    return "Open App Error";
                    break;
                }
                if (Services.findImage(deviceID, YOUTUBE) == true)
                {
                    Delay(1);
                    return "Open Gmail Success";
                    break;
                }
                else
                {
                    temp--;
                    Console.WriteLine(deviceID + " " + temp);
                }
            }

        }

        public string view(String deviceID, String linkyoutube, String length)
        {

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, YOUTUBE) == true)
                {
                    Delay(1);
                    break;
                }
            }

            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, SEARCH) == true)
                {
                    Delay(1);
                    KAutoHelper.ADBHelper.InputText(deviceID, linkyoutube);
                    
                    Delay(1);
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                    Delay(1);
                    break;
                }
            }

            if (Services.findImage(deviceID, LINK) == true)
            {
                Delay(1);
                KAutoHelper.ADBHelper.InputText(deviceID, linkyoutube);
            }
            else
            {
                Console.WriteLine("da nhap link");
            }

            KAutoHelper.ADBHelper.Tap(deviceID, 360, 360);
            Delay(1);
            KAutoHelper.ADBHelper.Tap(deviceID, 360, 360);

            int len = Int32.Parse(length);
            while (true)
            {
                if(len == 0)
                {
                    break;
                }
                Delay(1);
                len--;
            }
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
