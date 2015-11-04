using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Api.Models
{
    using AdventureWorks.Enumerations;

    public class EmployeePhoneModel
    {
        #region Public Methods

        public int BusinessEntityId { get; set; }

        public string PhoneNumber { get; set; }

        public PhoneNumberTypeEnum PhoneNumberType { get; set; }

        #endregion
    }
}