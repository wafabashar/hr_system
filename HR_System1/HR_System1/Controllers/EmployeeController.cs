using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System1.data;
using HR_System1.Models;
using HR_System1.Service;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using ClosedXML.Excel;

namespace HR_System1.Controllers
{
    [Authorize(Roles ="Admin,User")]
    public class EmployeeController : Controller
    {
        IDepartmentService department;
        IEmployeeService employee;
        IConfiguration configuration;
        public EmployeeController(IDepartmentService _department,IEmployeeService _employee, IConfiguration _configuration)
        {
            department = _department;
            employee = _employee;
            configuration = _configuration;
        }
        public IActionResult New_Employee()
        {
            ViewData["edit"] = false;
            VmEmployee vm = new VmEmployee();
            vm.lidepartment = department.LoadAllDepartment();
            return View("Add_Employee",vm);
        }

        public IActionResult Employee_list()
        {

            List<Employee> li = employee.LoadAllEmployee();
            return View("Employee_List", li);
        }

        public IActionResult Insert(VmEmployee vm)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory() + @"/" +configuration["ImageFile"], vm.employee.Image.FileName);


            vm.employee.Image.CopyTo(new FileStream(FilePath, FileMode.Create));
            vm.employee.Image_Path = "http://localhost/HR_System1" + configuration["ImagePath"] + "/" + vm.employee.Image.FileName;

            employee.Insert(vm.employee);

            vm.lidepartment = department.LoadAllDepartment();
            return View("Add_Employee", vm);
        }

        public IActionResult Delete(int id)
        {
            employee.Delete(id);
            List<Employee> li = employee.LoadAllEmployee();
            return View("Employee_List", li);
        }

        public IActionResult Edit(int id)
        {
            VmEmployee vm = new VmEmployee();

            vm.employee = employee.Edit(id);

            vm.lidepartment = department.LoadAllDepartment();


            ViewData["edit"] = true;

            return View("Add_Employee", vm);


        }
        public IActionResult UpDate(VmEmployee vm)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory() + @"/" + configuration["ImageFile"], vm.employee.Image.FileName);


            vm.employee.Image.CopyTo(new FileStream(FilePath, FileMode.Create));
            vm.employee.Image_Path = "http://localhost/HR_System1" + configuration["ImagePath"] + "/" + vm.employee.Image.FileName;


            employee.UpDate(vm.employee);

            List<Employee> li = employee.LoadAllEmployee();
            return View("Employee_List", li);
        }

        public IActionResult Excel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "ID";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow, 3).Value = "Phone";
                worksheet.Cell(currentRow, 4).Value = "Email";
                worksheet.Cell(currentRow, 5).Value = "Gender";
                worksheet.Cell(currentRow, 6).Value = "Birth Date";
                worksheet.Cell(currentRow, 7).Value = "Join Date";
                worksheet.Cell(currentRow, 8).Value = "Department";
                List<Employee> li = employee.LoadAllEmployee();
                foreach (var emp in li )
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = emp.ID;
                    worksheet.Cell(currentRow, 2).Value = emp.Name;
                    worksheet.Cell(currentRow, 3).Value = emp.Phone;
                    worksheet.Cell(currentRow, 4).Value = emp.Email;
                    worksheet.Cell(currentRow, 5).Value = emp.Gender;
                    worksheet.Cell(currentRow, 6).Value =emp.Birth_Date ;
                    worksheet.Cell(currentRow, 7).Value =emp.Join_Date ;
                    worksheet.Cell(currentRow, 8).Value =emp.department.Name ;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Employees.xlsx");
                }
            }
        }


    }


    
}
