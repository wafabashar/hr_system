using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System1.data
{
    [Table("Departments")]
    public class Department
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Employee> liEmployee { get; set; }
    }
}
