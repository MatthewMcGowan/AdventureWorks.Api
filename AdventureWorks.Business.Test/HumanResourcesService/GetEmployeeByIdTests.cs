using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Test.HumanResourcesService
{
    using NUnit.Framework;
    using Moq;
    using AdventureWorks.Business;
    using Data.Interfaces;
    using TestData;
    using Business.Interfaces;

    [TestFixture]
    public class GetEmployeeByIdTests : BaseHumanResourcesTests
    {
        private HumanResourcesService hr;
        private Mock<IEmployeeDA> mockEmployeeDa;
        private Mock<IPersonPhoneDA> mockPhoneDa;
        private Mock<IAppSettingReader> mockAppReader;
        private BusinessObjects.Employee ceo;

        [SetUp]
        public void SetUp()
        {
            mockEmployeeDa = new Mock<IEmployeeDA>();
            mockPhoneDa = new Mock<IPersonPhoneDA>();
            mockAppReader = new Mock<IAppSettingReader>();

            mockAppReader.Setup(x => x.GetAppSetting(TestData.DataAccessMethodKey)).Returns(TestData.DataAccessMethodEntityFramework);

            ceo = GetCeoEmployeeBo();
        }

        [Test]
        public void GetEmployeeById_IdGiven_DataAccessGetEmployeeByBusinessEntityIdCalled()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityId(It.IsAny<int>())).Returns(It.IsAny<BusinessObjects.Employee>);
            hr = new HumanResourcesService(mockEmployeeDa.Object, mockPhoneDa.Object, mockAppReader.Object);

            // Act
            hr.GetEmployeeById(TestData.CeoBusinessEntityId);

            // Assert
            mockEmployeeDa.VerifyAll();
        }

        [Test]
        public void GetEmployeeById_IdGiven_CorrectObjectReturnedUnchanged()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityId(ceo.BusinessEntityId))
                .Returns(ceo);
            hr = new HumanResourcesService(mockEmployeeDa.Object, mockPhoneDa.Object, mockAppReader.Object);

            // Act
            var result = hr.GetEmployeeById(TestData.CeoBusinessEntityId);

            // Assert
            Assert.IsTrue(result.Equals(ceo));
        }

        [Test]
        public void GetEmployeeById_InvalidIdGiven_NullObjectReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityId(It.IsAny<int>())).Returns((BusinessObjects.Employee)null);
            hr = new HumanResourcesService(mockEmployeeDa.Object, mockPhoneDa.Object, mockAppReader.Object);

            // Act
            var result = hr.GetEmployeeById(TestData.CeoBusinessEntityId);

            // Assert
            Assert.IsTrue(result == null);
        }
    }
}
