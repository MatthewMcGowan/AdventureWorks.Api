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
        private HumanResourcesService hr;
        private Mock<IEmployeeDA> mockEmployeeDa;
        private Mock<IPersonPhoneDA> mockPhoneDa;
        private Mock<IAppSettingReader> mockAppReader;
        private BusinessObjects.Employee ceo;
        private BusinessObjects.PersonPhone existingCeoNumber;
        private BusinessObjects.PersonPhone newCeoNumber;
        private BusinessObjects.PersonPhone nonEmployeeNumber;

        [SetUp]
        public void SetUp()
        {
            // New instances of the mocks
            mockEmployeeDa = new Mock<IEmployeeDA>();
            mockPhoneDa = new Mock<IPersonPhoneDA>();
            mockAppReader = new Mock<IAppSettingReader>();

            // Mock the app reader/web.config for each method. Determines which DataAccess method will be used.
            mockAppReader.Setup(x => x.GetAppSetting(TestData.DataAccessMethodKey)).Returns(TestData.DataAccessMethodEntityFramework);

            // Create test data
            ceo = GetCeoEmployeeBo();
            existingCeoNumber = GetCeoPhoneBo();
            newCeoNumber = GetCeoPhoneBo();
            newCeoNumber.PhoneNumber = "123-456-7890";
            nonEmployeeNumber = GetCeoPhoneBo();
            nonEmployeeNumber.BusinessEntityId = 2;
        }

        [Test]
        public void AddPhoneNumber_EmployeeExistsAndNumberNotDuplicate_PhoneNumberAddedAndTrueReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityIdAsync(ceo.BusinessEntityId)).ReturnsAsync(ceo);
            mockPhoneDa.Setup(x => x.GetPhoneNumbersByBusinessEntityIdAsync(existingCeoNumber.BusinessEntityId))
                .ReturnsAsync(new List<BusinessObjects.PersonPhone> { existingCeoNumber });
            mockPhoneDa.Setup(x => x.AddPhoneNumber(newCeoNumber));
            hr = new HumanResourcesService(mockEmployeeDa.Object, mockPhoneDa.Object, mockAppReader.Object);

            // Act
            bool returns = hr.AddPhoneNumber(newCeoNumber);

            // Assert
            // TODO: Verify the DA methods have been called
            Assert.IsTrue(returns);
        }

        [Test]
        public void AddPhoneNumber_EmployeeDoesNotExist_FalseReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityIdAsync(nonEmployeeNumber.BusinessEntityId))
                .ReturnsAsync((BusinessObjects.Employee)null);
            mockPhoneDa.Setup(x => x.GetPhoneNumbersByBusinessEntityIdAsync(nonEmployeeNumber.BusinessEntityId))
                .ReturnsAsync(new List<BusinessObjects.PersonPhone> { existingCeoNumber });
            mockPhoneDa.Setup(x => x.AddPhoneNumber(nonEmployeeNumber)).Throws(new System.Exception());
            hr = new HumanResourcesService(mockEmployeeDa.Object, mockPhoneDa.Object, mockAppReader.Object);

            // Act
            bool returns = hr.AddPhoneNumber(nonEmployeeNumber);

            // Assert
            // TODO: Verify the DA methods have been called
            Assert.IsFalse(returns);
        }

        [Test]
        public void AddPhoneNumber_EmployeeAlreadyHasNumber_FalseReturned()
        {
            // Arrange
            mockEmployeeDa.Setup(x => x.GetEmployeeByBusinessEntityIdAsync(existingCeoNumber.BusinessEntityId))
                .ReturnsAsync(ceo);
            mockPhoneDa.Setup(x => x.GetPhoneNumbersByBusinessEntityIdAsync(existingCeoNumber.BusinessEntityId))
                .ReturnsAsync(new List<BusinessObjects.PersonPhone> { existingCeoNumber });
            mockPhoneDa.Setup(x => x.AddPhoneNumber(existingCeoNumber)).Throws(new System.Exception());
            hr = new HumanResourcesService(mockEmployeeDa.Object, mockPhoneDa.Object, mockAppReader.Object);

            // Act
            bool returns = hr.AddPhoneNumber(existingCeoNumber);

            // Assert
            // TODO: Verify the DA methods have been called
            Assert.IsFalse(returns);
        }
    }
}
