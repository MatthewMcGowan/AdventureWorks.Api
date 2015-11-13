using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.AdoDotNet.Core
{
    using AdventureWorks.Data.Interfaces;
    using dsAdventureWorks2012TableAdapters;
    using Extensions;

    public class EmployeeDA : BaseDA, IEmployeeDA
    {
        #region Private Fields

        

        #endregion

        #region Constructors

        public EmployeeDA()
        {

        }

        #endregion

        #region Public Methods

        public List<BusinessObjects.Employee> GetAllEmployees()
        {
            employeeAdapter = new EmployeePersonTableAdapter();
            dsAdventureWorks2012.EmployeePersonDataTable employees = employeeAdapter.GetData();
            return employees.MapToBusinessLayer();
        }

        public BusinessObjects.Employee GetEmployeeByBusinessEntityId(int id)
        {
            employeeAdapter = new EmployeePersonTableAdapter();
            dsAdventureWorks2012.EmployeePersonRow employee = employeeAdapter.GetEmployeePersonById(id).FirstOrDefault();
            return employee.MapToBusinessLayer();
        }

        public Task<BusinessObjects.Employee> GetEmployeeByBusinessEntityIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(BusinessObjects.Employee employee)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
