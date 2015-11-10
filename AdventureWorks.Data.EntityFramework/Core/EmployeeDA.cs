using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Common;
using AdventureWorks.Data.Interfaces;

namespace AdventureWorks.Data.EntityFramework.Core
{
    using System.Linq;
    using System.Data.Entity;
    using Extensions;
    using System.Threading.Tasks;

    public class EmployeeDA : BaseDA, IEmployeeDA
    {
        #region Constructors

        public EmployeeDA() : base()
        {
        }

        #endregion

        #region Public Methods

        public List<BusinessObjects.Employee> GetAllEmployees()
        {
            // Return all employees
            return Db.Employees.MapToBusinessLayer();
        }

        public BusinessObjects.Employee GetEmployeeByBusinessEntityId(int id)
        {
            // Return employee with specified BusinessEntityId
            return Db.Employees.Find(id).MapToBusinessLayer();
        }

        public Task<BusinessObjects.Employee> GetEmployeeByBusinessEntityIdAsync(int id)
        {
            // Return employee with specified BusinessEntityId
            return Task.Run (() => Db.Employees.Find(id).MapToBusinessLayer());
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
