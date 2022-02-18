using HR_System1.Models;
using HR_System1.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System1.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public IActionResult SignIn_view()
        {
            vmSingUp vm = new vmSingUp();
            vm.liRole = accountService.GetRoles();
            return View("SignIn",vm);
        }

        public async Task<IActionResult> Create_Account(vmSingUp vm)
        {
          var result=await accountService.Create(vm.signUp);
            vm.liRole = accountService.GetRoles();
            return View("SignIn",vm);
        }

        public  IActionResult LogIn_view( )
        {
            
            return View("LogIn");
        }

        public IActionResult AccessDenide()
        {

            return View();
        }

        

        public async Task<IActionResult> LogIn(LogInModel loginModel)
        {
            var result = await accountService.SignIn(loginModel);
            if (result.Succeeded)
            {
                return RedirectToAction("New_Employee", "Employee");
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid UserName or Password";
                return View("LogIn");
            }
            
        }

        public async Task<IActionResult> LogOut()
        {
            await accountService.SignOut();
            return View("LogIn");
        }

        public IActionResult New_Role( )
        {
            
            return View();
        }

        public async Task<IActionResult> Create_Role(RoleModel roleModel)
        {
            var result = await accountService.Add_Role(roleModel);

            return View("New_Role");
        }


    }
}
