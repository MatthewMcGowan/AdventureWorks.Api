using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Dapper.Core
{
    using AdventureWorks.Data.Interfaces;

    public class EmployeeDA : IEmployeeDA
    {
        public List<BusinessObjects.Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public BusinessObjects.Employee GetEmployeeByBusinessEntityId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BusinessObjects.Employee> GetEmployeeByBusinessEntityIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(BusinessObjects.Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
