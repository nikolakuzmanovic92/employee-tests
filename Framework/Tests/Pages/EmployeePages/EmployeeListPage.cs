using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Tests.Base;
using Tests.Models;

namespace Tests.Pages
{
    public class EmployeeListPage : BasePage
    {

        private static By
          createNewBy = By.LinkText("Create New"),
          searchBtnBy = By.CssSelector("input[value='Search']"),
          searchInputBy = By.Name("searchTerm"),
          tableBy = By.XPath("//table/tbody/tr");


        IWebElement CreateNew => Driver.FindElement(createNewBy);
        IWebElement SearchBtn => Driver.FindElement(searchBtnBy);
        IWebElement SearchInput => Driver.FindElement(searchInputBy);

        


        public Employee GetTableDetailsForEmployee(string name)
        {
            Employee employee = new Employee() { Name = name }; //da li treba to string?

            SearchForEmployee(name);

            List<IWebElement> TableRows = Driver.FindElements(tableBy).ToList();

            if (TableRows.Count == 2)
            {
                var resultCols = TableRows[1].FindElements(By.TagName("td"));
                employee.Salary = Convert.ToDouble(resultCols[1].Text, CultureInfo.InvariantCulture);
                employee.Duration = Convert.ToInt32(resultCols[2].Text);
                employee.Grade = Convert.ToInt32(resultCols[3].Text);
                employee.Email = resultCols[4].Text;

            } else
            {
                employee = null;
            }
           
            return employee;
        }

        public void ClickCreateNewEmployee()
        {
            CreateNew.Click();
        }

        public void SearchForEmployee(string name)
        {
            SearchInput.SendKeys(name);
            SearchBtn.Click();
        }
     
        public bool CheckIfEmployeeInList(string name)
        {
            return GetTableDetailsForEmployee(name) == null ? false : true;
        }
    }
}
