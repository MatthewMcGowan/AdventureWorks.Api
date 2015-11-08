namespace AdventureWorks.Logic.Test.HumanResourcesService
{
    using NUnit.Framework;
    using Moq;
    using Data.Interfaces;
    using Business;

    [TestFixture]
    public class AddPhoneNumberTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void AddPhoneNumber_EmployeeExistsAndNumberNotDuplicate_PhoneNumberAdded()
        {

        }

        [Test]
        public void AddPhoneNumber_EmployeeDoesNotExist_FalseReturned()
        {

        }

        [Test]
        public void AddPhoneNumber_EmployeeAlreadyHasNumber_FalseReturned()
        {

        }
    }
}
