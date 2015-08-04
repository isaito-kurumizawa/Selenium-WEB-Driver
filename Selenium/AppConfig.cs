using System;
using System.Configuration;

namespace Selenium
{

    /// <summary>
    /// コンフィグの設定。
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// 文字列を返す。
        /// </summary>
        /// <param name="key">
        /// <returns></returns>
        public static string GetString(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 整数を返す。
        /// </summary>
        /// <param name="key">
        /// <param name="ret">
        /// <returns></returns>
        public static bool GetInt(string key, out int ret)
        {
            return int.TryParse(ConfigurationManager.AppSettings[key], out ret);
        }

    }
}
