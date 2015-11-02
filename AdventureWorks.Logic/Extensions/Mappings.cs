using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Extensions
{
    using Objects;
    using AdventureWorks.Business.Extensions;

    public static class Mappings
    {
        public static Employee MapToBusinessLayer(this Data.EntityFramework.Employee source)
        {
            if (source == null)
            {
                return null;
            }

            return new Employee
            {
                BusinessEntityId = source.BusinessEntityID,
                FirstName = source.Person.FirstName,
                MiddleName = source.Person.MiddleName,
                LastName = source.Person.LastName,
                JobTitle = source.JobTitle
            };
        }

        public static List<Employee> MapToBusinessLayer(this IEnumerable<Data.EntityFramework.Employee> source)
        {
            var result = new List<Employee>();

            source.ForEach(e => result.Add(e.MapToBusinessLayer()));

            return result;
        }
    }
}
