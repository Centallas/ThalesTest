using Entity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    internal class GetEndPointData
    {
        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();

        }

        public static async Task<List<EmployeeEntity>> EmployeeOpt()
        {
            List<EmployeeEntity> employees = new List<EmployeeEntity>();
           

            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://dummy.restapiexample.com/api/v1/employees"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var empl = JsonConvert.DeserializeObject<RootObject>(apiResponse);
                    employees = empl.data.ToList();
                }
               
                return employees;

            }
        }
    }
}
