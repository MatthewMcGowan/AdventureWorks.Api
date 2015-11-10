using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Extensions;
using AdventureWorks.Enumerations;

namespace AdventureWorks.Data.EntityFramework.Extensions
{
    public static class MappingExtensions
    {
        #region MapToBusinessLayer

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

        public static BusinessObjects.PersonPhone MapToBusinessLayer(this Data.EntityFramework.PersonPhone source)
        {
            // If null object, return a null object
            if (source == null)
            {
                return null;
            }

            // Create new BO with data mapped
            return new BusinessObjects.PersonPhone
            {
                BusinessEntityId = source.BusinessEntityID,
                PhoneNumber = source.PhoneNumber,
                PhoneNumberType = (PhoneNumberTypeEnum)source.PhoneNumberTypeID
            };
        }

        public static List<BusinessObjects.PersonPhone> MapToBusinessLayer(this IEnumerable<Data.EntityFramework.PersonPhone> source)
        {
            // Return empty list if none found
            if (source.IsNullOrEmpty())
            {
                return new List<BusinessObjects.PersonPhone>();
            }

            // Create new list to return
            var result = new List<BusinessObjects.PersonPhone>();

            // Map the IEnumerable entities to BO list
            source.ForEach(e => result.Add(e.MapToBusinessLayer()));

            // Return the list
            return result;
        }

        #endregion

        #region MapOntoEntity

        // Map BOs onto Entities
        // Surjective mapping onto only a subset of Entity, rest of data preserved
        // Hence map "onto", as opposed to "map to"

        public static void MapOntoEntity(this BusinessObjects.Employee source, Employee target)
        {
            target.Person.FirstName = source.FirstName;
            target.Person.MiddleName = source.MiddleName;
            target.Person.LastName = source.LastName;
            target.JobTitle = source.JobTitle;
        }

        public static void MapOntoEntity(this BusinessObjects.PersonPhone source, PersonPhone target)
        {
            target.BusinessEntityID = source.BusinessEntityId;
            target.PhoneNumber = source.PhoneNumber;
            target.PhoneNumberTypeID = (int)source.PhoneNumberType;
        }

        #endregion
    }
}
