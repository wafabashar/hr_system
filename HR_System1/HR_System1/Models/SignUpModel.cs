using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HR_System1.Models
{
    public class SignUpModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Compare("ConfirmdPassword")]
        [DataType(DataType.Password)]
        public string Passowrd { get; set; }

        [Required]
        [Display(Name = "Confirmed Password")]
        [DataType(DataType.Password)]
        public string ConfirmdPassword { get; set; }

        [Display(Name ="Role")]
        [Required]
        public string Role_id { get; set; }

    }
}
