namespace AdventureWorks.Business.Test.HumanResourcesService
{
    using NUnit.Framework;
    using Moq;
    using Data.Interfaces;
    using Business;
    using Interfaces;
    using TestData;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    [TestFixture]
    public class AddPhoneNumberTests : BaseHumanResourcesTests
    {
        private BusinessObjects.PersonPhone existingCeoNumber;
        private BusinessObjects.PersonPhone newCeoNumber;
        private BusinessObjects.PersonPhone nonEmployeeNumber;

        [SetUp]
        public override void SetUp()
        {
            // Do the base setup
            base.SetUp();

            // Create additional test data
            existingCeoNumber = GetCeoPhoneBo();
            newCeoNumber = GetCeoPhoneBo();
            newCeoNumber.PhoneNumber = TestData.AlternativePhoneNumber;
            nonEmployeeNumber = GetCeoPhoneBo();
            nonEmployeeNumber.BusinessEntityId = TestData.AlternativeBusinessEntityId;
        }

        [Test]
        public void AddPhoneNumber_EmployeeExistsAndNumberNotDuplicate_PhoneNumberAddedAndTrueReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityIdAsync(newCeoNumber.BusinessEntityId)).ReturnsAsync(ceo);
            mockPhoneDa.Setup(x => x.GetPhoneNumberAsync(
                existingCeoNumber.BusinessEntityId, 
                existingCeoNumber.PhoneNumber, 
                (int)existingCeoNumber.PhoneNumberType))
                .ReturnsAsync(null);
            mockPhoneDa.Setup(x => x.AddPhoneNumber(newCeoNumber));
            CreateHumanResourcesService();

            // Act
            bool returns = hr.AddPhoneNumber(newCeoNumber);

            // Assert
            mockEmployeeDa.Verify(x => x.GetEmployeeByBusinessEntityIdAsync(newCeoNumber.BusinessEntityId));
            mockPhoneDa.Verify(x => x.GetPhoneNumberAsync(
                newCeoNumber.BusinessEntityId,
                newCeoNumber.PhoneNumber,
                (int)newCeoNumber.PhoneNumberType));
            mockPhoneDa.Verify(x => x.AddPhoneNumber(newCeoNumber));
            Assert.IsTrue(returns);
        }

        [Test]
        public void AddPhoneNumber_EmployeeDoesNotExist_FalseReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityIdAsync(nonEmployeeNumber.BusinessEntityId))
                .ReturnsAsync((BusinessObjects.Employee)null);
            mockPhoneDa.Setup(x => x.GetPhoneNumberAsync(
                nonEmployeeNumber.BusinessEntityId,
                nonEmployeeNumber.PhoneNumber,
                (int)nonEmployeeNumber.PhoneNumberType))
                .ReturnsAsync(existingCeoNumber);
            CreateHumanResourcesService();

            // Act
            bool returns = hr.AddPhoneNumber(nonEmployeeNumber);

            // Assert
            mockEmployeeDa.Verify(x => x.GetEmployeeByBusinessEntityIdAsync(nonEmployeeNumber.BusinessEntityId));
            mockPhoneDa.Verify(x => x.GetPhoneNumberAsync(
                nonEmployeeNumber.BusinessEntityId,
                nonEmployeeNumber.PhoneNumber,
                (int)nonEmployeeNumber.PhoneNumberType));
            mockPhoneDa.Verify(x => x.AddPhoneNumber(It.IsAny<BusinessObjects.PersonPhone>()), Times.Never());
            Assert.IsFalse(returns);
        }

        [Test]
        public void AddPhoneNumber_EmployeeAlreadyHasNumber_FalseReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityIdAsync(existingCeoNumber.BusinessEntityId))
                .ReturnsAsync(ceo);
            mockPhoneDa.Setup(x => x.GetPhoneNumberAsync(
                existingCeoNumber.BusinessEntityId,
                existingCeoNumber.PhoneNumber,
                (int)existingCeoNumber.PhoneNumberType))
                .ReturnsAsync(existingCeoNumber);
            mockPhoneDa.Setup(x => x.AddPhoneNumber(existingCeoNumber)).Throws(new System.Exception());
            CreateHumanResourcesService();

            // Act
            bool returns = hr.AddPhoneNumber(existingCeoNumber);

            // Assert
            mockEmployeeDa.Verify(x => x.GetEmployeeByBusinessEntityIdAsync(existingCeoNumber.BusinessEntityId));
            mockPhoneDa.Verify(x => x.GetPhoneNumberAsync(
                existingCeoNumber.BusinessEntityId,
                existingCeoNumber.PhoneNumber,
                (int)existingCeoNumber.PhoneNumberType));
            mockPhoneDa.Verify(x => x.AddPhoneNumber(It.IsAny<BusinessObjects.PersonPhone>()), Times.Never());
            Assert.IsFalse(returns);
        }
    }
}
