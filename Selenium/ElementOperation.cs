using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Selenium
{
    public class ElementOperation
    {
        private Capche capche = new Capche();
        /// <summary>
        /// titleが含まれているタグを検索しクリックする
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="title"></param>
        public void ClickTitle(IWebDriver webDriver, string title)
        {            
            try
            {
                IList<IWebElement> tag_title = webDriver.FindElements(By.XPath(string.Format("//*[contains(@title,'{0}')]", title)));
                capche.SaveCapche(webDriver);
                foreach (IWebElement tag in tag_title)
                {
                    if (tag.Displayed) 
                    {
                        tag.Click();
                        return;
                    }
                }
                throw new OriginalException(string.Format("contain:{0}, Not Found", title));
            }
            catch (Exception ex)
            {
                throw new OriginalException(string.Format("containUrl:{0}, ClickTitle, ErrorMessage:{1}", title, ex.Message));
            }
            finally
            {
                capche.SaveCapche(webDriver);
            }
        }
                
        /// <summary>
        /// valueが含まれているタグを検索しクリックする
        /// </summary>
        /// <param name="webDriver">IWebDriver</param>
        /// <param name="contain"></param>
        /// <param name="notContain"></param>
        public void ClickHref(IWebDriver webDriver, string contain, string notContain = "")
        {
            try 
            {
                IList<IWebElement> tag_a = webDriver.FindElements(By.XPath(string.Format("//*[contains(@href,'{0}')]", contain)));
                capche.SaveCapche(webDriver);
                foreach (IWebElement tag in tag_a)
                {
                    if (tag.Displayed)
                    {
                        if (notContain == "")
                        {
                            tag.Click();
                            return;                     
                        }
                        else if (!tag.GetAttribute("href").ToUpper().Contains(notContain.ToUpper()))
                        {
                            tag.Click();
                            return;
                        }
                    }
                }
                throw new OriginalException(string.Format("contain:{0}, Not Found", contain));
            }
            catch (Exception ex)
            {
                throw new OriginalException(string.Format("containUrl:{0}, ClickHref, ErrorMessage:{1}", contain, ex.Message));
            }            
            finally
            {
                capche.SaveCapche(webDriver);
            }
        }
        
        /// <summary>
        /// valueが含まれているタグを検索しクリックする
        /// </summary>
        /// <param name="webDriver">IWebDriver</param>
        /// <param name="contain">contain</param>
        public void ClickValue(IWebDriver webDriver, string contain)
        {            
            try 
            {
                IList<IWebElement> tag_input = webDriver.FindElements(By.XPath(string.Format("//*[contains(@value,'{0}')]", contain)));
                capche.SaveCapche(webDriver);
                foreach (IWebElement tag in tag_input)
                {
                    if (tag.Displayed)
                    {
                        tag.Click();
                        return;
                    }
                }
                throw new OriginalException(string.Format("contain:{0}, Not Found", contain));
            }
            catch (Exception ex)
            {
                throw new OriginalException(string.Format("containUrl:{0},ClickValue, ErrorMessage:{1}", contain, ex.Message));
            }
            finally
            {
                capche.SaveCapche(webDriver);
            }
        }

        /// <summary>
        /// classが含まれているタグを検索しクリックする
        /// </summary>
        /// <param name="webDriver">IWebDriver</param>
        /// <param name="contain">contain</param>
        public void ClickClass(IWebDriver webDriver, string contain)
        {
            try
            {
                IList<IWebElement> tag_input = webDriver.FindElements(By.XPath(string.Format("//*[contains(@class,'{0}')]", contain)));
                capche.SaveCapche(webDriver);
                foreach (IWebElement tag in tag_input)
                {
                    if (tag.Displayed)
                    {
                        tag.Click();
                        return;
                    }
                }
                throw new OriginalException(string.Format("contain:{0}, Not Found", contain));
            }
            catch (Exception ex)
            {
                throw new OriginalException(string.Format("containUrl:{0}, ClickClass, ErrorMessage:{1}", contain, ex.Message));
            }
            finally
            {
                capche.SaveCapche(webDriver);
            }
        }

        /// <summary>
        /// forが含まれているタグを検索しクリックする
        /// </summary>
        /// <param name="webDriver">webDriver</param>
        /// <param name="name">name</param>
        public void ClickFor(IWebDriver webDriver, string contain)
        {
            try
            {
                IList<IWebElement> tag_input = webDriver.FindElements(By.XPath(string.Format("//*[contains(@for,'{0}')]", contain)));
                capche.SaveCapche(webDriver);            
                foreach (IWebElement tag in tag_input)
                {
                    if (tag.Displayed)
                    {
                        tag.Click();
                        return;
                    }
                }
                throw new OriginalException(string.Format("contain:{0}, Not Found", contain));
            }
            catch (Exception ex)
            {
                throw new OriginalException(string.Format("containUrl:{0}, ClickFor, ErrorMessage:{1}", contain, ex.Message));
            }
            finally
            {
                capche.SaveCapche(webDriver);
            }
        }

        /// <summary>
        /// テキストに文字列を入力する
        /// </summary>
        /// <param name="webDriver">IWebDriver</param>
        /// <param name="Name">検索するname</param>
        /// <param name="text">入力する文字列</param>
        /// <param name="textClear">現在入力されているテキストを削除するか</param>
        public void InputText(IWebDriver webDriver, string Name, string text, Boolean textClear = true)
        {
            try
            {
                capche.SaveCapche(webDriver);
                IWebElement inputID = webDriver.FindElement(By.Name(Name));
                if(textClear)
                    inputID.Clear();
                inputID.SendKeys(text);                
            }
            catch (Exception ex)
            {
                throw new OriginalException(string.Format("containUrl:{0}, InputText, ErrorMessage:{1}", AppConfig.GetString(Name), ex.Message));
            }
            finally
            {
                capche.SaveCapche(webDriver);
            }
        }

        /// <summary>
        /// name属性から取得する
        /// </summary>
        /// <param name="webDriver">IWebDriver</param>
        /// <param name="name">検索するname</param>
        public void Submit(IWebDriver webDriver, string name)
        {
            try
            {
                capche.SaveCapche(webDriver);
                webDriver.FindElement(By.Name(name)).Click();                
            }
            catch (Exception ex)
            {
                throw new OriginalException(string.Format("name:{0}, Error:{1}", name,ex.Message));
            }
            finally
            {
                capche.SaveCapche(webDriver);
            }
        }
        
    } 
}
