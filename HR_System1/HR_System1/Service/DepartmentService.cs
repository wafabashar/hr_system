using HR_System1.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HR_System1.Service
{
    public class DepartmentService : IDepartmentService
    {

        Hr_Context context;

        public DepartmentService(Hr_Context _context)
        {
            context = _context;
        }

        public void Delete(int id)
        {
           Department dep= context.department.Find(id);
            context.Remove(dep);
            context.SaveChanges();
        }

        public Department Edit(int id)
        {
            
           Department dep= context.department.Find(id);
            return dep;
           
        }

        public void Insert(Department dep)
        {
            context.Add(dep);
            context.SaveChanges();
        }

        public List<Department> LoadAllDepartment()
        {
            List<Department> li = context.department.ToList();
            return li;
        }

        public void UpDate(Department dep)
        {
            context.department.Attach(dep);
            context.Entry(dep).State =EntityState.Modified;
            context.SaveChanges();
        }
    }
}
