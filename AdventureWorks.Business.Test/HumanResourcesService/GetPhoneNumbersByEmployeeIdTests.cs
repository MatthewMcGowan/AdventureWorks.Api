using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Test.HumanResourcesService
{
    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class GetPhoneNumbersByEmployeeIdTests : BaseHumanResourcesTests
    {
        private BusinessObjects.PersonPhone ceoNumber;

        [SetUp]
        public override void SetUp()
        {
            // Call the base setup
            base.SetUp();

            // Create ceo phone number
            ceoNumber = GetCeoPhoneBo();
        }

        [Test]
        public void GetPhoneNumbersByEmployeeId_NonEmptyListReturnedByDataAccessLayer_ListReturned()
        {
            // Arrange
            mockPhoneDa.Setup(x => x.GetEmployeePersonPhonesByBusinessEntityId(ceo.BusinessEntityId))
                .Returns(new List<BusinessObjects.PersonPhone> { ceoNumber });
            CreateHumanResourcesService();

            // Act
            var returns = hr.GetPhoneNumbersByEmployeeId(ceo.BusinessEntityId);

            // Assert
            mockPhoneDa.VerifyAll();
            Assert.True(returns.Count == 1);
            Assert.AreEqual(returns[0], ceoNumber);
        }

        [Test]
        public void GetPhoneNumberByEmployeeId_EmptyListReturnedByDataAccessLayer_EmptyListReturned()
        {
            // Arrange
            mockPhoneDa.Setup(x => x.GetEmployeePersonPhonesByBusinessEntityId(ceo.BusinessEntityId))
                .Returns(new List<BusinessObjects.PersonPhone>());
            CreateHumanResourcesService();

            // Act
            var returns = hr.GetPhoneNumbersByEmployeeId(ceo.BusinessEntityId);

            // Assert
            mockPhoneDa.VerifyAll();
            Assert.True(returns.Count == 0);
        }
    }
}
