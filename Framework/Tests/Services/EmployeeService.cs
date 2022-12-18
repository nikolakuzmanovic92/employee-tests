using Framework.Configuration;
using Newtonsoft.Json;
using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tests.Models;

namespace Tests.Services
{
    public class EmployeeService
    {

        public static Employee GetCorrectEmployee()
        {
            var path = Path.Combine(Path.GetFullPath(@"../../../../Tests/"), "Resources\\EmployeeResources\\CorrectEmployees.json");
            Employee e = JsonConvert.DeserializeObject<Employee>(File.ReadAllText(path));
            return e;
        }

        public static IList<CorruptEmployee> GetIncorrectEmployees()
        {
            var path = Path.Combine(Path.GetFullPath(@"../../../../Tests/"), "Resources\\EmployeeResources\\IncorrectEmployees.json");          
            return JsonConvert.DeserializeObject<IList<CorruptEmployee>>(File.ReadAllText(path));
        }

        public static void RemoveUserFromDB(string employeeId, IWebDriver driver)
        {
            RestClient restClient = new RestClient(Settings.URL);
            
            RestRequest restRequest = new RestRequest($"Employee/Delete/{employeeId}", Method.POST);
            restRequest.AddParameter(".AspNet.ApplicationCookie", driver.Manage().Cookies.AllCookies[0].Value, ParameterType.Cookie);
            
            IRestResponse restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception( $"Unable to remove employee with ID: {employeeId} from DB!");
            }
        }

    }
}
