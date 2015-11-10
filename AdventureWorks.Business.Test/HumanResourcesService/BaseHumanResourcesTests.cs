using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Test.HumanResourcesService
{
    using TestData;

    public abstract class BaseHumanResourcesTests
    {
        #region Protected Methods

        protected BusinessObjects.Employee GetCeoEmployeeBo()
        {
            return new BusinessObjects.Employee
            {
                BusinessEntityId = TestData.CeoBusinessEntityId,
                FirstName = TestData.CeoFirstName,
                MiddleName = TestData.CeoMiddleName,
                LastName = TestData.CeoLastName,
                JobTitle = TestData.CeoJobTitle
            };
        }

        protected BusinessObjects.PersonPhone GetCeoPhoneBo()
        {
            return new BusinessObjects.PersonPhone
            {
                BusinessEntityId = TestData.CeoBusinessEntityId,
                PhoneNumber = TestData.CeoPhoneNumber,
                PhoneNumberType = TestData.CeoPhoneNumberType
            };
        }

        #endregion
    }
}
