using Framework.Configuration;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Pages;
using Tests.Services;

namespace Tests.Base
{
    public abstract class TestBase
    {
        [ThreadStatic]
        public static string EmployeeId;

        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            ConfigReader.SetFrameworkSettings();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            Driver.Init();
            Page.Init();
            Driver.Goto(Settings.URL);
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if(outcome == TestStatus.Failed)
            {
                Driver.TakeScreenshot("test_failed");
            }

            if(EmployeeId != null)
            {
                EmployeeService.RemoveUserFromDB(EmployeeId, Driver.Current);
                EmployeeId = null;
            }

            Driver.Quit();
        }


    }
}
