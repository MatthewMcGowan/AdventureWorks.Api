using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Dapper.Extensions
{
    public static class MappingExtensions
    {
        public static object MapToParams(this BusinessObjects.Employee e)
        {
            return new
            {
                BusinessEntityID = e.BusinessEntityId,
                FirstName = e.FirstName,
                MiddleName = e.MiddleName,
                LastName = e.LastName,
                JobTitle = e.JobTitle
            };
        }

        public static object MapToParams(this BusinessObjects.PersonPhone p)
        {
            return new
            {
                BusinessEntityID = p.BusinessEntityId,
                PhoneNumber = p.PhoneNumber,
                PhoneNumberTypeID = p.PhoneNumberType
            };
        }
    }
}
