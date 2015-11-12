using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.AdoDotNet.Extensions
{
    using BusinessObjects;

    public static class MappingExtensions
    {
        #region MapToBusinessLayer

        public static BusinessObjects.Employee MapToBusinessLayer(this dsAdventureWorks2012.EmployeePersonRow employeeAdapter)
        {
            return new BusinessObjects.Employee
            {
                BusinessEntityId = employeeAdapter.BusinessEntityID,
                FirstName = employeeAdapter.FirstName,
                MiddleName = employeeAdapter.MiddleName,
                LastName = employeeAdapter.LastName,
                JobTitle = employeeAdapter.JobTitle
            };
        }

        #endregion
    }
}
