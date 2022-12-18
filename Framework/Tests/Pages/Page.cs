using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Pages
{
    public class Page
    {

        [ThreadStatic]
        public static LoginPage LoginPage;

        [ThreadStatic]
        public static HomePage HomePage;

        [ThreadStatic]
        public static EmployeeListPage EmployeeListPage;

        [ThreadStatic]
        public static CreateNewEmployeePage CreateNewEmployeePage;


        public static void Init()
        {
            LoginPage = new LoginPage();
            HomePage = new HomePage();
            EmployeeListPage = new EmployeeListPage();
            CreateNewEmployeePage = new CreateNewEmployeePage();
        }
    }
}
