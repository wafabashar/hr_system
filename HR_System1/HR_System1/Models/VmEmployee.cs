using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System1.data;

namespace HR_System1.Models
{
    public class VmEmployee
    {

        public Employee employee { get; set; }

        public List<Department> lidepartment { get; set; }
    }
}
