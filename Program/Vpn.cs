using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;

namespace ToolTest
{
    class Vpn

    {
        #region data
        Bitmap CONNECT;
        Bitmap OK;
        Bitmap VIETPN;
        Bitmap DISCONNECT;
        Bitmap CONNECTED;
        #endregion
        public Vpn()
        {
            LoadData();
        }
        void LoadData()
        {
            CONNECT = (Bitmap)Bitmap.FromFile("C://data//vietpn//connect.png");
            OK = (Bitmap)Bitmap.FromFile("C://data//vietpn//ok.png");
            VIETPN = (Bitmap)Bitmap.FromFile("C://data//vietpn//vietpn.png");
            DISCONNECT = (Bitmap)Bitmap.FromFile("C://data//vietpn//disconnect.png");
            CONNECTED = (Bitmap)Bitmap.FromFile("C://data//vietpn//connected.png");
        }


        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        
        public string configVpn(String deviceID,String noxID)
        {

            KAutoHelper.ADBHelper.ExecuteCMD(MainProgram.linkNox + " -clone:" + noxID + " -package:com.vietpn.vpn");

            Delay(3);
            var screen1 = Services.ScreenShoot(deviceID);
            var disPoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, DISCONNECT);
            if(disPoint!= null)
            {
                return "";
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, CONNECT) == true)
                {
                    break;
                }
                Console.WriteLine("tim signup");
            }

            Delay(5);
            var screen = Services.ScreenShoot(deviceID);
            var OKpoint = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, OK);
            if(OKpoint!= null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, OKpoint.Value.X, OKpoint.Value.Y);
                Delay(1);
            }

            Delay(5);

            int dem = 10;
            while (true)
            {
                if(dem == 0)
                {
                    Console.WriteLine("Error : vpn error");
                    Environment.Exit(0);
                }
                Delay(1);
                if (Services.findImage(deviceID, CONNECTED) == true)
                {
                    break;
                }
                else dem--;
            }
            while (true)
            {
                Delay(1);
                if (Services.findImage(deviceID, VIETPN) == true)
                {
                    Console.WriteLine("click next");
                    Delay(1);
                    break;
                }
            }

            return "";

        }

       
    }
}
