using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class Common
    {
        public static void Main(string[] args)
        {            
            IWebDriver browser = null;
            try 
            {
                SelectBrowser(ref browser);
                CWorksWebAccount(browser);
            }
            catch(Exception ex)
            {
                StreamWriter streamWriter = new StreamWriter(AppConfig.GetString(Config.LOG_PATH) + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".txt", true, Encoding.GetEncoding("Shift_JIS"));
                streamWriter.Write(string.Format("[{0}]BrowserType:{1},ErrorMessage:{2}\n", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"), AppConfig.GetString(Config.BROWSER_TYPE), ex.Message));
                streamWriter.Close();
            }            
        }

        /// <summary>
        /// BROWSER_TYPEの値によって起動するブラウザを変える
        /// (firefox以外は不安定)
        /// </summary>
        /// <param name="webDriver"></param>
        public static void SelectBrowser(ref IWebDriver webDriver)
        {
            switch (AppConfig.GetString(Config.BROWSER_TYPE))
            {
                case "1": // FireFox
                    FirefoxBinary firefoxBinary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                    FirefoxProfile firefoxProfile = new FirefoxProfile();
                    webDriver = new FirefoxDriver(firefoxBinary, firefoxProfile);
                    break;
                case "2": // Chrome
                    webDriver = new ChromeDriver();
                    break;
                case "3": // IE
                    // ブラウザのズームレベルを100%にしないと落ちる
                    webDriver = new InternetExplorerDriver();
                    break;
                default:
                    throw new OriginalException("BROWSER_TYPEが不正です。1～3の間で設定してください。");
            }
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            webDriver.Url = AppConfig.GetString(Config.TEST_URL);
        }

    }
}
