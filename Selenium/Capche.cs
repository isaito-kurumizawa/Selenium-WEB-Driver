using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OpenQA.Selenium;

namespace Selenium
{
    class Capche
    {
        /// <summary>
        /// キャプチャ
        /// </summary>
        /// <param name="webDriver"></param>
        public void SaveCapche(IWebDriver webDriver)
        {
            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            byte[] screenshotAsByteArray = ss.AsByteArray;
            if (!Directory.Exists(string.Format(@"{0}{1}", AppConfig.GetString(Config.CAPCHE_PATH), Config.NOW)))
                Directory.CreateDirectory(string.Format(@"{0}{1}", AppConfig.GetString(Config.CAPCHE_PATH), Config.NOW));

            ss.SaveAsFile(string.Format(@"{0}\{1}\{2}.jpg", AppConfig.GetString(Config.CAPCHE_PATH), Config.NOW, DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")), ImageFormat.Jpeg); 
        }
    } 
}
