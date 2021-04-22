using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace ToolTest
{
    class NuoiYoutubeService
    {
        ViewYoutube view = new ViewYoutube();

        public void run(String deviceID, String Noxid, String link, String length)
        {
                view.chooseBigolive(deviceID, Noxid);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                view.view(deviceID, link, "600");
                view.Exit(deviceID);
                Thread.Sleep(TimeSpan.FromSeconds(10));         
        }
    }
}
