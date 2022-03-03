using System;

namespace Business_Logic_Layer.DTOs
{
    public class EmployeeDto
    {
        public EmployeeDto(int id)
        {
            this.id = id;
        }
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }
}
