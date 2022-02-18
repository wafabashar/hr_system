using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System1.data;

namespace HR_System1.Service
{
   public interface IDepartmentService
    {

        void Insert(Department dep);
        List<Department> LoadAllDepartment();

        void Delete(int id);

        Department Edit(int id);

        void UpDate(Department dep);
    }
}
