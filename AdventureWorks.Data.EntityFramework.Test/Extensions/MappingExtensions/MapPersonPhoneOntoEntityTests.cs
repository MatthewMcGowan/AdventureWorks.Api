using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.EntityFramework.Test.Extensions.MappingExtensions
{
    using NUnit.Framework;
    using Moq;
    using Data.EntityFramework.Extensions;
    using TestData;

    [TestFixture]
    public class MapPersonPhoneOntoEntityTests
    {
        private BusinessObjects.PersonPhone phoneBo;

        private Data.EntityFramework.PersonPhone phoneEntity;

        [SetUp]
        public void SetUp()
        {
            phoneBo = new BusinessObjects.PersonPhone();
            phoneEntity = new Data.EntityFramework.PersonPhone();
        }

        [Test]
        public void MapOntoEntity_PersonPhoneBusinessObjectMappedOntoPersonPhoneEntity_ModifiedFieldsChange()
        {
            // Arrange
            AddValidDataToPhoneBo();

            // Act
            phoneBo.MapOntoEntity(phoneEntity);

            // Assert
            Assert.True(phoneEntity.BusinessEntityID == TestData.CeoBusinessEntityId);
            Assert.True(phoneEntity.PhoneNumber == TestData.CeoPhoneNumber);
            Assert.True(phoneEntity.PhoneNumberTypeID == (int)TestData.CeoPhoneNumberType);
        }

        [Test]
        public void MapOntoEntity_NullPersonPhoneBusinessObject_NullReferenceExceptionThrown()
        {
            // Arrange
            BusinessObjects.PersonPhone nullPhoneBo = null;

            // Act/Assert
            Assert.Throws<NullReferenceException>(() => nullPhoneBo.MapOntoEntity(phoneEntity));
        }

        [Test]
        public void MapOntoEntity_NullPersonPhoneEntity_NullReferenceExceptionThrown()
        {
            // Arrange
            AddValidDataToPhoneBo();
            EntityFramework.PersonPhone nullPhoneEntity = null;

            // Act/Assert
            Assert.Throws<NullReferenceException>(() => phoneBo.MapOntoEntity(nullPhoneEntity));
        }

        private void AddValidDataToPhoneBo()
        {
            phoneBo.BusinessEntityId = TestData.CeoBusinessEntityId;
            phoneBo.PhoneNumber = TestData.CeoPhoneNumber;
            phoneBo.PhoneNumberType = TestData.CeoPhoneNumberType;
        }
    }
}
