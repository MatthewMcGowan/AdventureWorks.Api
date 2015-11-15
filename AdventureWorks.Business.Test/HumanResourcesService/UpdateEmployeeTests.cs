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
    public class UpdateEmployeeTests : BaseHumanResourcesTests
    {
        private BusinessObjects.Employee updateCeo;

        public override void SetUp()
        {
            // Call base setup
            base.SetUp();

            // Create modified employee data to update with
            updateCeo = GetCeoEmployeeBo();
            updateCeo.FirstName = TestData.AlternativeFirstName;
        }

        [Test]
        public void UpdateEmployee_ValidObjectGiven_TrueReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityId(updateCeo.BusinessEntityId)).Returns(ceo);
            mockEmployeeDa.Setup(x => x.UpdateEmployee(updateCeo));
            CreateHumanResourcesService();

            // Act
            bool returns = hr.UpdateEmployee(updateCeo);

            // Assert
            mockEmployeeDa.VerifyAll();
            Assert.IsTrue(returns);
        }

        [Test]
        public void UpdateEmployee_NullObjectGiven_FalseReturnedAndDataAccessNeverCalled()
        {
            // Arrange
            BusinessObjects.Employee nullEmployee = null;
            CreateHumanResourcesService();

            // Act
            bool returns = hr.UpdateEmployee(nullEmployee);

            // Assert
            mockEmployeeDa.Verify(x => x.GetEmployeeByBusinessEntityId(It.IsAny<int>()), Times.Never());
            mockEmployeeDa.Verify(x => x.UpdateEmployee(It.IsAny<BusinessObjects.Employee>()), Times.Never());
            Assert.IsFalse(returns);
        }

        [Test]
        public void UpdateEmployee_BusinessEntityIdLessThanOne_FalseReturnedAndDataAccessNeverCalled()
        {
            // Arrange
            updateCeo.BusinessEntityId = -1;
            CreateHumanResourcesService();

            // Act
            bool returns = hr.UpdateEmployee(updateCeo);

            // Assert
            mockEmployeeDa.Verify(x => x.GetEmployeeByBusinessEntityId(It.IsAny<int>()), Times.Never());
            mockEmployeeDa.Verify(x => x.UpdateEmployee(It.IsAny<BusinessObjects.Employee>()), Times.Never());
            Assert.IsFalse(returns);
        }

        [Test]
        public void UpdateEmployee_EmployeeDoesntExist_FalseReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityId(updateCeo.BusinessEntityId))
                .Returns((BusinessObjects.Employee)null);
            CreateHumanResourcesService();

            // Act
            bool returns = hr.UpdateEmployee(updateCeo);

            // Assert
            mockEmployeeDa.Verify(x => x.GetEmployeeByBusinessEntityId(updateCeo.BusinessEntityId));
            mockEmployeeDa.Verify(x => x.UpdateEmployee(It.IsAny<BusinessObjects.Employee>()), Times.Never());
            Assert.False(returns);
        }
    }
}
