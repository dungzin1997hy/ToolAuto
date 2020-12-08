using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading;

namespace ToolTest
{
    class Services
    {
        public static List<String> getAllDevice()
        {
            List<String> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            return devices;
        }

        public static Boolean findImage(String deviceId, Bitmap bitmap)
        {  
            var screen = ScreenShoot(deviceId);
            var point = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, bitmap);
            if (point != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceId, point.Value.X, point.Value.Y);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                return true;
            }
            else return false;
        }
        public Boolean checkInternet(String deviceID)
        {
            bool isHasInternet = true;
            String a = KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell ping -c 2 google.com");
            //   Console.WriteLine(a);

            if (a.Contains("unknown host"))
            {
                isHasInternet = false;
            }
            else isHasInternet = true;
            Console.WriteLine(deviceID + ": " + isHasInternet);
            Thread.Sleep(TimeSpan.FromSeconds(10));

            return isHasInternet;
        }
        public void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;

            }
        }
        public string Exit(String deviceID,String package)
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
            KAutoHelper.ADBHelper.ExecuteCMD("adb -s " + deviceID + " shell pm clear "+package);
            Delay(1);
            return "Exit Success";

        }
        public static Bitmap ScreenShoot(string deviceID = null, bool isDeleteImageAfterCapture = true, string fileName = "screenShoot.png")
        {
            Bitmap result = null;
            bool flag = string.IsNullOrEmpty(deviceID);

            if (flag)
            {
                List<string> listDevice = KAutoHelper.ADBHelper.GetDevices();
                bool flag2 = listDevice != null && listDevice.Count > 0;
                if (!flag2)
                {
                    return null;
                }
                deviceID = listDevice.First<string>();
            }
            string screenShotCount = deviceID;

            try
            {
                screenShotCount = deviceID.Split(new char[]
                {
    ':'
                })[1];
            }
            catch
            {
            }
            string nameToSave = Path.GetFileNameWithoutExtension(fileName) + screenShotCount + Path.GetExtension(fileName);
            for (; ; )
            {
                bool flag3 = File.Exists(nameToSave);
                if (!flag3)
                {
                    break;
                }
                try
                {
                    File.Delete(nameToSave);
                    break;
                }
                catch (Exception ex)
                {
                    break;
                }
            }

            string Current = Directory.GetCurrentDirectory() + "\\" + nameToSave;
            string CurrentPath = Directory.GetCurrentDirectory().Replace(@"\\", @"\");
            CurrentPath = "\"" + CurrentPath + "\"";
            try
            {
                string cmdCommand1 = string.Format("adb -s {0} shell screencap -p \"{1}\"", deviceID, "/sdcard/" + nameToSave);
                string cmdCommand2 = string.Format("adb -s " + deviceID + " pull " + "/sdcard/" + nameToSave + " " + CurrentPath);

                string result1 = KAutoHelper.ADBHelper.ExecuteCMD(cmdCommand1);

                string result2 = KAutoHelper.ADBHelper.ExecuteCMD(cmdCommand2);


                using (Bitmap bitmap = new Bitmap(Current))
                {
                    result = new Bitmap(bitmap);
                }

                if (isDeleteImageAfterCapture)
                {
                    try
                    {
                        File.Delete(nameToSave);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
