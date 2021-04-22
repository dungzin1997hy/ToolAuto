using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ToolTest
{
    class ViewYoutubeService
    {
        ViewYoutube view = new ViewYoutube();

        public void run(String deviceID,String Noxid, String link, String length)
        {
            
            for(int i=1;i<=3;i++)
            {
                view.chooseBigolive(deviceID, Noxid);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                view.view(deviceID, link, length);
                view.Exit(deviceID);
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }
}
