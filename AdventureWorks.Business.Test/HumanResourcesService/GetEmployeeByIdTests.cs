using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Logic.Test.HumanResourcesService
{
    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class GetEmployeeByIdTests
    {
        [Test]
        public void GetEmployeeById_GivenExistantEmployeeId_ReturnsCorrectEmployee()
        {

        }

        [Test]
        public void GetEmployeeById_GivenNonExistantBusinessEntityId_ReturnNull()
        {

        }

        [Test]
        public void GetEmployeeById_GivenPersonNotEmployeeId_ReturnNull()
        {

        }
    }
}
