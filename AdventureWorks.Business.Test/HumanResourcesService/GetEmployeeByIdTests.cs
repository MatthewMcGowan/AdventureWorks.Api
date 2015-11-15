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
        [Test]
        public void GetEmployeeById_IdGiven_DataAccessGetEmployeeByBusinessEntityIdCalled()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityId(It.IsAny<int>())).Returns(It.IsAny<BusinessObjects.Employee>);
            CreateHumanResourcesService();

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
            CreateHumanResourcesService();

            // Act
            var result = hr.GetEmployeeById(TestData.CeoBusinessEntityId);

            // Assert
            mockEmployeeDa.Verify(x => x.GetEmployeeByBusinessEntityId(TestData.CeoBusinessEntityId));
            Assert.IsTrue(result.Equals(ceo));
        }

        [Test]
        public void GetEmployeeById_InvalidIdGiven_NullObjectReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityId(It.IsAny<int>())).Returns((BusinessObjects.Employee)null);
            CreateHumanResourcesService();

            // Act
            var result = hr.GetEmployeeById(TestData.CeoBusinessEntityId);

            // Assert
            mockEmployeeDa.Verify(x => x.GetEmployeeByBusinessEntityId(TestData.CeoBusinessEntityId));
            Assert.IsNull(result);
        }
    }
}
