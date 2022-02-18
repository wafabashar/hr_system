using HR_System1.data;
using HR_System1.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System1.Service
{
    public class AccountService : IAccountService
    {
        UserManager<ApplicationUser> usermanager;
        SignInManager<ApplicationUser> signinmanager;
        RoleManager<IdentityRole> rolemanager;
        public AccountService(UserManager<ApplicationUser> _usermanager, SignInManager<ApplicationUser> _signinmanager,
            RoleManager<IdentityRole> _rolemanager)
        {
            usermanager = _usermanager;
            signinmanager = _signinmanager;
            rolemanager = _rolemanager;
        }
        public async Task<IdentityResult> Create(SignUpModel signupModel)
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = signupModel.Name;
            user.Email = signupModel.Email;
            user.UserName = signupModel.Email;
           var result=await usermanager.CreateAsync(user, signupModel.Passowrd);
            if (result.Succeeded)
            {
                var role = await rolemanager.FindByIdAsync(signupModel.Role_id);

                if (role != null)
                {
                    result = await usermanager.AddToRoleAsync(user, role.Name);
                }
            }
            return result;
        }

        public async Task<SignInResult> SignIn(LogInModel loginModel)
        {
            var result = await signinmanager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
            return result;
        }

        public async Task SignOut()
        {
            await signinmanager.SignOutAsync();
        }

        public async Task<IdentityResult> Add_Role(RoleModel roleModel)
        {
            IdentityRole role = new IdentityRole();
            role.Name = roleModel.Name;
            var result = await rolemanager.CreateAsync(role);
            return result;
        }

        public List<IdentityRole> GetRoles()
        {
           List<IdentityRole> liRole= rolemanager.Roles.ToList();
            return liRole;
        }


    }
}
