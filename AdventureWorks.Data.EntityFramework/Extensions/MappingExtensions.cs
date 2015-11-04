using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.EntityFramework.Extensions
{
    public static class MappingExtensions
    {
        // Map BOs onto Entities
        // Surjective mapping onto only a subset of Entity, rest of data preserved
        // Hence map "onto", as opposed to "map to"

        public static void MapOntoEntity(this BusinessObjects.Employee source, Employee target)
        {
            target.Person.FirstName = source.FirstName;
            target.Person.MiddleName = source.MiddleName;
            target.Person.LastName = source.LastName;
            target.JobTitle = source.LastName;
        }

        public static void MapOntoEntity(this BusinessObjects.PersonPhone source, PersonPhone target)
        {
            target.BusinessEntityID = source.BusinessEntityId;
            target.PhoneNumber = source.PhoneNumber;
            target.PhoneNumberTypeID = (int)source.PhoneNumberType;
        }
    }
}
