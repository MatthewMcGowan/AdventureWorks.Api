using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Interfaces
{
    public interface IEmployeeDA
    {
        List<BusinessObjects.Employee> GetAllEmployees();

        BusinessObjects.Employee GetEmployeeByBusinessEntityId(int id);

        void UpdateEmployee(BusinessObjects.Employee employee);
    }
}
