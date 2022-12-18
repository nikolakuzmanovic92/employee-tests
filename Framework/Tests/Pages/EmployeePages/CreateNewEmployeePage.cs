using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Tests.Base;
using Tests.Models;

namespace Tests.Pages
{
    public class CreateNewEmployeePage : BasePage
    {

        private readonly By
          nameInputBy = By.Id("Name"),
          salaryInputBy = By.Id("Salary"),
          durationInputBy = By.Id("DurationWorked"),
          gradeInputBy = By.Id("Grade"),
          emailInputBy = By.Id("Email"),
          createBtnBy = By.CssSelector("input[type='Submit']"),

          salaryErrorBy = By.XPath("//*[@id='Salary']/following-sibling::span"),
          durationErrorBy = By.CssSelector("input:invalid[name='DurationWorked']"),
          gradeErrorBy = By.CssSelector("input:invalid[name='Grade']");


        IWebElement NameInput => Driver.FindElement(nameInputBy);
        IWebElement SalaryInput => Driver.FindElement(salaryInputBy);
        IWebElement DurationInput => Driver.FindElement(durationInputBy);
        IWebElement GradeInput => Driver.FindElement(gradeInputBy);
        IWebElement EmailInput => Driver.FindElement(emailInputBy);
        IWebElement CreateBtn => Driver.FindElement(createBtnBy);

        public IWebElement SalaryError => Driver.FindElement(salaryErrorBy);
        public IWebElement DurationError => Driver.FindElement(durationErrorBy);
        public IWebElement GradeError => Driver.FindElement(gradeErrorBy);


        public void SetName(string name)
        {
            NameInput.SendKeys(name);
        }

        public void SetSalary(string salary)
        {
            SalaryInput.SendKeys(salary);
        }

        public void SetDuration(string duration)
        {
            DurationInput.SendKeys(duration);
        }

        public void SetGrade(string grade)
        {
            GradeInput.SendKeys(grade);
        }

        public void SetEmail(string email)
        {
            EmailInput.SendKeys(email);
        }

        public string CreateEmployee(Employee employee)
        {
            SetName(employee.Name);
            SetSalary(employee.Salary.ToString(CultureInfo.InvariantCulture));
            SetGrade(employee.Grade.ToString());
            SetDuration(employee.Duration.ToString());
            SetEmail(employee.Email);
            CreateBtn.Click();

            string keyword = "Index/";
            Driver.Wait.Until(WaitConditions.UrlContains(keyword));
            string url = Driver.Current.Url;
            
            return url.Substring(url.IndexOf(keyword) + keyword.Length);
        }

        public void FillFieldsWithWrongData(CorruptEmployee employee)
        {
            SetName(employee.Name);
            SetSalary(employee.Salary);
            SetGrade(employee.Grade);
            SetDuration(employee.Duration);
            SetEmail(employee.Email);
            CreateBtn.Click();
        }

    }
}
