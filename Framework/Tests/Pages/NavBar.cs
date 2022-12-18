using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Pages
{
    public class NavBar
    {

        private static By
           logInBtnBy = By.Id("loginLink"),
           registerBtnBy = By.Id("registerLink"),
           employeeListBy = By.LinkText("Employee List"),
           homeLinkBy = By.LinkText("Home"),
           logOffBy = By.LinkText("Log off"),
           manageUsersBy = By.LinkText("Manage Users"),
           employeeDetailsBy = By.LinkText("Employee Details");


        IWebElement LogInBtn => Driver.FindElement(logInBtnBy);
        IWebElement RegisterBtn => Driver.FindElement(registerBtnBy);
        IWebElement EmployeeList => Driver.FindElement(employeeListBy);
        IWebElement HomeLink => Driver.FindElement(homeLinkBy);
        IWebElement LogOffBtn => Driver.FindElement(logOffBy);


        public void ClickLogin()
        {
            LogInBtn.Click();
        }

        public void ClickRegisterBtn()
        {
            RegisterBtn.Click();
        }

        public void ClickEmployeeList()
        {
            EmployeeList.Click();
        }

        public void ClickHome()
        {
            HomeLink.Click();
        }

        public void ClickLogOff()
        {
            LogOffBtn.Click();
        }

    }
}
