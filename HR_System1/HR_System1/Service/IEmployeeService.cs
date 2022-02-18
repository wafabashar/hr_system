using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR_System1.data;

namespace HR_System1.Service
{
   public interface IEmployeeService
    {
        void Insert(Employee emp);
        List<Employee> LoadAllEmployee();

        void Delete(int id);

        Employee Edit(int id);

        void UpDate(Employee emp);
    }
}
