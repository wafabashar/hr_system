using HR_System1.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR_System1.Service
{
    public class EmployeeService : IEmployeeService
    {
        Hr_Context context;
        public EmployeeService(Hr_Context _context)
        {
            context = _context;
        }

       

        public void Insert(Employee emp)
        {
            context.Add(emp);
            context.SaveChanges();
        }

        public List<Employee> LoadAllEmployee()
        {
            List<Employee> li = context.employee.Include("department").ToList();
            return li;
        }

        public void Delete(int id)
        {
            Employee emp = context.employee.Find(id);
            context.Remove(emp);
            context.SaveChanges();

        }

        public Employee Edit(int id)
        {
            Employee emp = context.employee.Find(id);
            return emp;
        }

        public void UpDate(Employee emp)
        {
            context.Attach(emp);
            context.Entry(emp).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
