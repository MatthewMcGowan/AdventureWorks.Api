using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Common;

namespace AdventureWorks.Data.EntityFramework.Core
{
    using System.Linq;
    using System.Data.Entity;
    using Interfaces;
    using Extensions;

    public class EmployeeDA : BaseDA, IEmployeeDA
    {
        #region Constructors

        public EmployeeDA() : base()
        {
        }

        #endregion

        #region Public Methods

        public IEnumerable<Employee> GetAllEmployees()
        {
            // Return all employees
            return Db.Employees;
        }

        public Employee GetEmployeeByBusinessEntityId(int id)
        {
            // Return employee with specified BusinessEntityId
            return Db.Employees.Find(id);
        }

        public void UpdateEmployee(BusinessObjects.Employee employee)
        {
            // Get the current employee entity
            var entity = Db.Employees.Find(employee.BusinessEntityId);

            // Map our business object onto the entity
            employee.MapOntoEntity(entity);

            // Save the changes to the entity
            Db.SaveChanges();
        }

        #endregion
    }
}
