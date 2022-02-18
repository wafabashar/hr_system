using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System1.Models
{
    public class vmSingUp
    {
        public SignUpModel signUp { set; get; }

       public List<IdentityRole> liRole { set; get; }
    }
}
