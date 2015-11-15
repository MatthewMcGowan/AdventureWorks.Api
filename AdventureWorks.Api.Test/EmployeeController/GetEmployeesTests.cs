using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Api.Test.EmployeeController
{
    using Models;
    using NUnit.Framework;
    using System.Web.Http;
    using System.Web.Http.Results;
    using AutoMapper;

    [TestFixture]
    public class GetEmployeesTests : BaseEmployeeTests
    {
        [SetUp]
        public override void Setup()
        {
            // Call base setup
            base.Setup();
        }

        [Test]
        public void GetEmployees_EmployeeListFromBusinessLayer_OkReturnedWithEmployeeList()
        {
            // ARRANGE
            // Mock the business Layer
            mockHumanResourcesService.Setup(x => x.GetEmployees()).Returns(new List<BusinessObjects.Employee> { ceoBo });
            e = new Controllers.EmployeeController(mockHumanResourcesService.Object);

            // Create expected result
            var expectedResult =
                new OkNegotiatedContentResult<List<EmployeeModel>>(new List<EmployeeModel> { ceoModel }, e);


            // ACT
            // Call the API method, casting to expected result type
            var returns = (OkNegotiatedContentResult<List<EmployeeModel>>)e.GetEmployees();

            // ASSERT
            // Explicitly state that we want this type
            Assert.IsInstanceOf<OkNegotiatedContentResult<List<EmployeeModel>>>(returns);
            // Make sure there's 1 item in the list (mocked service returns 1 item)
            Assert.AreEqual(returns.Content.Count(), 1);
            // Make sure that item contains the expected employee data
            Assert.True(returns.Content.FirstOrDefault().Equals(ceoModel));
        }

        [Test]
        public void GetEmployees_EmptyListFromBusinessLayer_NotFoundReturned()
        {

        }
    }
}
