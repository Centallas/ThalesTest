using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RootObject
    {
        public string status { get; set; }
        public EmployeeEntity[] data { get; set; }
        public string message { get; set; }
    }
}
