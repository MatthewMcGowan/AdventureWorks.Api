using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Test.HumanResourcesService
{
    using TestData;
    using NUnit.Framework;
    using Moq;
    using AdventureWorks.Business;
    using Data.Interfaces;
    using Business.Interfaces;

    public abstract class BaseHumanResourcesTests
    {
        #region Protected Fields

        protected HumanResourcesService hr;
        protected Mock<IEmployeeDA> mockEmployeeDa;
        protected Mock<IPersonPhoneDA> mockPhoneDa;
        protected Mock<IAppSettingReader> mockAppReader;
        protected BusinessObjects.Employee ceo;

        #endregion

        #region Protected Methods

        [SetUp]
        public virtual void SetUp()
        {
            // New instances of the mocks
            mockEmployeeDa = new Mock<IEmployeeDA>();
            mockPhoneDa = new Mock<IPersonPhoneDA>();
            mockAppReader = new Mock<IAppSettingReader>();

            // Mock the app reader/web.config for each method. Determines which DataAccess method will be used.
            mockAppReader.Setup(x => x.GetAppSetting(TestData.DataAccessMethodKey)).Returns(TestData.DataAccessMethodEntityFramework);

            // Create test ceo
            ceo = GetCeoEmployeeBo();
        }

        protected void CreateHumanResourcesService()
        {
            hr = new HumanResourcesService(mockEmployeeDa.Object, mockPhoneDa.Object, mockAppReader.Object);
        }

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
