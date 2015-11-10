using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.BusinessObjects
{
    public class Employee
    {
        #region Public Properties

        public int BusinessEntityId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        #endregion

        #region Public Properties

        public bool Equals(Employee obj)
        {
            if (obj == null)
            {
                return false;
            }

            return BusinessEntityId == obj.BusinessEntityId
                && FirstName == obj.FirstName
                && MiddleName == obj.MiddleName
                && LastName == obj.LastName
                && JobTitle == obj.JobTitle;
        }

        #endregion
    }
}
