using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Test.HumanResourcesService
{
    using NUnit.Framework;
    using Moq;
    using Business;
    using Data.Interfaces;
    using TestData;
    using Business.Interfaces;

    [TestFixture]
    public class GetEmployeesTests : BaseHumanResourcesTests
    {
        private HumanResourcesService hr;
        private Mock<IEmployeeDA> mockEmployeeDa;
        private Mock<IPersonPhoneDA> mockPhoneDa;
        private Mock<IAppSettingReader> mockAppReader;
        private Mock<List<BusinessObjects.Employee>> mockEmployeeList;
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
        public void GetEmployees_EmployeesListReturnedFromDataAccessLayer_SameListReturnedFromMethod()
        {
            // Arrange
            var employeeList = new List<BusinessObjects.Employee>() { ceo };
            mockEmployeeDa.Setup(x => x.GetAllEmployees()).Returns(employeeList);
            hr = new HumanResourcesService(mockEmployeeDa.Object, mockPhoneDa.Object, mockAppReader.Object);

            // Act
            var result = hr.GetEmployees();

            // Assert
            Assert.IsTrue(result.Count == employeeList.Count);
            Assert.IsTrue(result[0].Equals(ceo));
            mockEmployeeDa.Verify(x => x.GetAllEmployees());
        }

        [Test]
        public void GetEmployees_EmptyListReturnedFromDataAccessLayer_EmptyListReturnedByMethod()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetAllEmployees()).Returns(new List<BusinessObjects.Employee>());
            hr = new HumanResourcesService(mockEmployeeDa.Object, mockPhoneDa.Object, mockAppReader.Object);

            // Act
            var result = hr.GetEmployees();

            // Assert
            Assert.IsTrue(result.Count == 0);
            mockEmployeeDa.Verify(x => x.GetAllEmployees());
        }
    }
}
