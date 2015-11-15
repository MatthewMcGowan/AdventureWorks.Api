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
    public class DeletePhoneNumberTests : BaseHumanResourcesTests
    {
        private BusinessObjects.PersonPhone ceoNumber;

        [SetUp]
        public override void SetUp()
        {
            // Do the base setup
            base.SetUp();

            // Create additional test data
            ceoNumber = GetCeoPhoneBo();
        }

        [Test]
        public void DeletePhoneNumber_ValidPhoneNumberObjectProvided_ReturnsTrue()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityIdAsync(ceoNumber.BusinessEntityId)).ReturnsAsync(ceo);
            mockPhoneDa.Setup(x => x.GetPhoneNumberAsync(
                ceoNumber.BusinessEntityId, 
                ceoNumber.PhoneNumber, 
                (int)ceoNumber.PhoneNumberType))
                .ReturnsAsync(ceoNumber);
            mockPhoneDa.Setup(x => x.DeletePhoneNumber(ceoNumber));
            CreateHumanResourcesService();

            // Act
            bool returns = hr.DeletePhoneNumber(ceoNumber);

            // Assert
            mockEmployeeDa.VerifyAll();
            mockPhoneDa.VerifyAll();
            Assert.IsTrue(returns);
        }

        [Test]
        public void DeletePhoneNumber_EmployeeDoesntExist_ReturnsFalse()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityIdAsync(ceoNumber.BusinessEntityId))
                .ReturnsAsync(null);
            mockPhoneDa.Setup(x => x.GetPhoneNumberAsync(
                ceoNumber.BusinessEntityId,
                ceoNumber.PhoneNumber,
                (int)ceoNumber.PhoneNumberType))
                .ReturnsAsync(ceoNumber);
            mockPhoneDa.Setup(x => x.DeletePhoneNumber(ceoNumber));
            CreateHumanResourcesService();

            // Act
            bool returns = hr.DeletePhoneNumber(ceoNumber);

            // Assert
            mockEmployeeDa.Verify(x => x.GetEmployeeByBusinessEntityIdAsync(ceoNumber.BusinessEntityId));
            mockPhoneDa.Verify(x => x.DeletePhoneNumber(ceoNumber), Times.Never());
            Assert.False(returns);
        }

        [Test]
        public void DeletePhoneNumber_NumberDoesntExist_ReturnsFalse()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityIdAsync(ceoNumber.BusinessEntityId))
                .ReturnsAsync(ceo);
            mockPhoneDa.Setup(x => x.GetPhoneNumberAsync(
                ceoNumber.BusinessEntityId,
                ceoNumber.PhoneNumber,
                (int)ceoNumber.PhoneNumberType))
                .ReturnsAsync(null);
            mockPhoneDa.Setup(x => x.DeletePhoneNumber(ceoNumber));
            CreateHumanResourcesService();

            // Act
            bool returns = hr.DeletePhoneNumber(ceoNumber);

            // Assert
            mockPhoneDa.Verify(x => x.GetPhoneNumberAsync(
                ceoNumber.BusinessEntityId,
                ceoNumber.PhoneNumber,
                (int)ceoNumber.PhoneNumberType));
            mockPhoneDa.Verify(x => x.DeletePhoneNumber(It.IsAny<BusinessObjects.PersonPhone>()), Times.Never);
            Assert.False(returns);
        }
    }
}
