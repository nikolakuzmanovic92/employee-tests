using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Selenium
{
    public  class Browser
    {
        public BrowserName BrowserName { get; set; }

    }

    public enum BrowserName
    {
        InternetExplorer,
        Firefox,
        Chrome
    }
}
