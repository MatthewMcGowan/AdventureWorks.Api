using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Extensions
{
    public static class MappingExtensions
    {
        public static BusinessObjects.Employee MapToBusinessLayer(this Data.EntityFramework.Employee source)
        {
            // If null object, return a null object
            if (source == null)
            {
                return null;
            }

            // Create new BO with data mapped
            return new BusinessObjects.Employee
            {
                BusinessEntityId = source.BusinessEntityID,
                FirstName = source.Person.FirstName,
                MiddleName = source.Person.MiddleName,
                LastName = source.Person.LastName,
                JobTitle = source.JobTitle
            };
        }

        public static List<BusinessObjects.Employee> MapToBusinessLayer(this IEnumerable<Data.EntityFramework.Employee> source)
        {
            // Return empty list if none found
            if (source.IsNullOrEmpty())
            {
                return new List<BusinessObjects.Employee>();
            }

            // Create new list to return
            var result = new List<BusinessObjects.Employee>();

            // Map the IEnumerable entities to BO list
            source.ForEach(e => result.Add(e.MapToBusinessLayer()));

            // Return the list
            return result;
        }
    }
}
