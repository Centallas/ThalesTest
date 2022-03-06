using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class SaanDto
    {
        public SaanDto(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public int employee_annual_salary { get; set; }
        public string profile_image { get; set; }
    }
}
