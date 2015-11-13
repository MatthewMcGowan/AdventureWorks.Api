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

        public static BusinessObjects.Employee MapToBusinessLayer(this dsAdventureWorks2012.EmployeePersonRow row)
        {
            // Return a new BO with all values assigned
            return new BusinessObjects.Employee
            {
                BusinessEntityId = row.BusinessEntityID,
                FirstName = row.FirstName,
                MiddleName = row.MiddleName,
                LastName = row.LastName,
                JobTitle = row.JobTitle
            };
        }

        public static List<BusinessObjects.Employee> MapToBusinessLayer(this dsAdventureWorks2012.EmployeePersonDataTable employeeTable)
        {
            // Create new list to be returned
            var employeeList = new List<BusinessObjects.Employee>();

            // If the employee table is empty, return the empty list
            if (employeeTable == null || employeeTable.Rows.Count < 1)
            {
                return employeeList;
            }

            // Otherwise, create a BO for each row in the table and add to the return list
            foreach(var row in employeeTable)
            {
                employeeList.Add(row.MapToBusinessLayer());
            };

            // Return the new list of BOs
            return employeeList;
        }

        #endregion
    }
}
