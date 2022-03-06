using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebThales.Models;


namespace WebThales.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> employees = new List<Employee>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44353/api/employee/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var empl = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                    employees = empl;
                }
            }
            return View(employees);
        }

    }
}
