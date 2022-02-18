using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System1.data;
using HR_System1.Service;
using Microsoft.AspNetCore.Authorization;

namespace HR_System1.Controllers
{

    public class DepartmentController : Controller
    {
        IDepartmentService department;
        public DepartmentController(IDepartmentService _department)
        {
            department = _department;
        }
        public IActionResult New_Department()
        {
            ViewData["edit"] = false;
            return View("Add_Department");
        }

        public IActionResult Department_list()
        {

            List<Department> li = department.LoadAllDepartment();
            return View("Department_List", li);
        }

        public IActionResult Insert(Department dep)
        {
            department.Insert(dep);
       
            return View("Add_Department");
        }

      

        public IActionResult Delete(int id)
        {
            department.Delete(id);
            List<Department> li = department.LoadAllDepartment();
            return View("Department_List", li);
        }

        public IActionResult Edit(int id)
        {
            ViewData["edit"] = true;
           Department dep= department.Edit(id);
            return View("Add_Department", dep);
        }

        public IActionResult UpDate(Department dep)
        {
            department.UpDate(dep);

            List<Department> li = department.LoadAllDepartment();
            return View("Department_List", li);

           
        }




    }
}
