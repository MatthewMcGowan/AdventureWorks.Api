using AdventureWorks.Business.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Interfaces
{
    public interface IHumanResourcesService
    {
        List<Employee> GetEmployees();

        Employee GetEmployeeById(int id);

        void UpdateEmployee(Employee employee);
    }
}
