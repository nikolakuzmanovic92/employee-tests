﻿using Framework.Selenium;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tests.Base;

namespace Tests.Pages
{
    public class LoginPage : BasePage
    {

        private static By
           usernameBy = By.Id("UserName"),
           passwordBy = By.Id("Password"),
           logintBtnBy = By.CssSelector("input[value='Log in']"),
           registerLinkBy = By.LinkText("Register as a new user");

        IWebElement Username => Driver.FindElement(usernameBy);
        IWebElement Password => Driver.FindElement(passwordBy);
        IWebElement LogintBtn => Driver.FindElement(logintBtnBy);
        IWebElement RegisterLink => Driver.FindElement(registerLinkBy);

        public void Login(string user = "", string pass = "")   //This method will be converted to API call
        {
            if (user == "" || pass == "")
            {
                //Environment variables should be used instead of having them in json.
                var path = Path.Combine(Path.GetFullPath(@"../../../../Tests/"), "Resources\\LoginResource\\AdminCredentials.json");
                Dictionary<string, string> credentialsJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(path));
                Username.SendKeys(credentialsJson["username"]);
                Password.SendKeys(credentialsJson["password"]);
            }
            else
            {
                Username.SendKeys(user);
                Password.SendKeys(pass);
            }

            LogintBtn.Click();
        }

    }
}
