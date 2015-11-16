using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.TableAdapter.Core
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
            employeeAdapter = new EmployeePersonTableAdapter();
        }

        #endregion

        #region Public Methods

        public List<BusinessObjects.Employee> GetAllEmployees()
        {
            dsAdventureWorks2012.EmployeePersonDataTable employees = employeeAdapter.GetData();
            return employees.MapToBusinessLayer();
        }

        public BusinessObjects.Employee GetEmployeeByBusinessEntityId(int id)
        {
            var employee = employeeAdapter.GetEmployeePersonById(id).FirstOrDefault();
            return employee.MapToBusinessLayer();
        }

        public Task<BusinessObjects.Employee> GetEmployeeByBusinessEntityIdAsync(int id)
        {
            return Task.Run(() => (employeeAdapter.GetEmployeePersonById(id).FirstOrDefault()).MapToBusinessLayer());
        }

        public void UpdateEmployee(BusinessObjects.Employee e)
        {
            var updatedEmployee = 
                employeeAdapter.UpdateEmployeePerson(e.JobTitle, e.BusinessEntityId, e.FirstName, e.MiddleName, e.LastName);

            throw new NotImplementedException();
        }

        #endregion
    }
}
