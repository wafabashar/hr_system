using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace HR_System1.data
{

    [Table("Employees")]
    public class Employee
    {

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression(@"07(7|8|9)\d{7}")]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTime Birth_Date { get; set; }

        public string Image_Path { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public DateTime Join_Date { get; set; }

        [ForeignKey("department")]
        public int Department_id { get; set; }
        public Department department { get; set; }



    }
}
