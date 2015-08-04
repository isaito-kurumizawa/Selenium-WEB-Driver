using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Selenium
{
    public class OriginalException : Exception
    {
        public OriginalException() { }

        public OriginalException(string message) : base(message) { }

        public OriginalException(string message, Exception inner) : base(message) { }
    }
}
