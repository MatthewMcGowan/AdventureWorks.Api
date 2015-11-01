using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Logic.Objects
{
    public class EmployeeBO
    {
        #region Public Properties

        public int BusinessEntityId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string OrganizationNode { get; set; }

        #endregion
    }
}
