using Framework.Selenium;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using Tests.Base;
using Tests.Models;
using Tests.Pages;
using Tests.Services;

namespace Tests
{
    public class CreateEmployeeTests : TestBase
    {

        static IList<CorruptEmployee> CorruptEmployees = EmployeeService.GetIncorrectEmployees();
        static Employee employee = EmployeeService.GetCorrectEmployee();

        [Test, Category("EmployeeTests")]
        [Parallelizable]
        public void CreateEmployeeAndVerifyCreated()
        {
            Page.HomePage.NavBar.ClickLogin();
            Page.LoginPage.Login();
            Page.HomePage.NavBar.ClickEmployeeList();
            Page.EmployeeListPage.ClickCreateNewEmployee();
            EmployeeId = Page.CreateNewEmployeePage.CreateEmployee(employee);

            Assert.IsTrue(Page.EmployeeListPage.CheckIfEmployeeInList(employee.Name), 
                "Employee not created!");
        }

        [Test, Category("EmployeeTests")]
        [TestCaseSource("CorruptEmployees")]
        [Parallelizable(ParallelScope.Children)]
        public void CheckValidationMessages(CorruptEmployee employee)
        {
            Page.HomePage.NavBar.ClickLogin();
            Page.LoginPage.Login();
            Page.HomePage.NavBar.ClickEmployeeList();
            Page.EmployeeListPage.ClickCreateNewEmployee();
            Page.CreateNewEmployeePage.FillFieldsWithWrongData(employee);

            switch (employee.Name)
            {
                case "Salary": Assert.IsTrue(Driver.Wait.Until(
                                        WaitConditions.ElementDisplayed(Page.CreateNewEmployeePage.SalaryError)));
                                        break;
                
                case "Duration": Assert.IsTrue(Driver.Wait.Until(
                                        WaitConditions.ElementDisplayed(Page.CreateNewEmployeePage.DurationError)));
                                        break;

                case "Grade":   Assert.IsTrue(Driver.Wait.Until(
                                        WaitConditions.ElementDisplayed(Page.CreateNewEmployeePage.GradeError)));
                                        break;

                default: throw new Exception("For given case test is not implemented");
            }
        }
    }
}