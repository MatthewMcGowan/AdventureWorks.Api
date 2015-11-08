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
            Assert.True(phoneEntity.BusinessEntityID == 1);
            Assert.True(phoneEntity.PhoneNumber == "697-555-0142");
            Assert.True(phoneEntity.PhoneNumberTypeID == (int)Enumerations.PhoneNumberTypeEnum.Cell);
        }

        [Test]
        public void MapOntoEntity_PersonPhoneBusinessObjectMappedOntoPersonPhoneEntity_NoOtherFieldsChange()
        {

        }

        [Test]
        public void MapOntoEntity_NullPersonPhoneBusinessObject_NullReferenceExceptionThrown()
        {

        }

        [Test]
        public void MapOntoEntity_NullPersonPhoneEntity_NullReferenceExceptionThrown()
        {

        }

        private void AddValidDataToPhoneBo()
        {
            phoneBo.BusinessEntityId = 1;
            phoneBo.PhoneNumber = "697-555-0142";
            phoneBo.PhoneNumberType = Enumerations.PhoneNumberTypeEnum.Cell;
        }
    }
}
