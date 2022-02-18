using HR_System1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System1.Service
{
  public interface IAccountService
    {

         Task<IdentityResult> Create(SignUpModel signupModel);

        Task<SignInResult> SignIn(LogInModel loginModel);

        Task SignOut();

        Task<IdentityResult> Add_Role(RoleModel roleModel);

        List<IdentityRole> GetRoles();
    }
}
