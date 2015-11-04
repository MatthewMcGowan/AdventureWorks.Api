using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.EntityFramework.Interfaces
{
    public interface IEmployeeDA
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeByBusinessEntityId(int id);

        void UpdateEmployee(BusinessObjects.Employee employee);
    }
}
