using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Api.Test.EmployeeController
{
    using NUnit.Framework;
    using Moq;
    using Business.Interfaces;
    using TestData;
    using Models;

    public abstract class BaseEmployeeTests
    {
        #region Protected Fields

        protected Mock<IHumanResourcesService> mockHumanResourcesService;
        protected Controllers.EmployeeController e;
        protected BusinessObjects.Employee ceoBo;
        protected EmployeeModel ceoModel;

        #endregion

        #region Public Methods

        [SetUp]
        public virtual void Setup()
        {
            // Lazy, TODO: Register globally
            AutoMapperConfig.RegisterMapping();

            // Create mock for HumanResourcesService
            mockHumanResourcesService = new Mock<IHumanResourcesService>();

            // Create new Employee object
            ceoBo = GetCeoEmployeeBo();
            ceoModel = GetCeoModel();
        }

        protected EmployeeModel GetCeoModel()
        {
            return new EmployeeModel
            {
                BusinessEntityId = TestData.CeoBusinessEntityId,
                FirstName = TestData.CeoFirstName,
                MiddleName = TestData.CeoMiddleName,
                LastName = TestData.CeoLastName,
                JobTitle = TestData.CeoJobTitle
            };
        }

        protected BusinessObjects.Employee GetCeoEmployeeBo()
        {
            return new BusinessObjects.Employee
            {
                BusinessEntityId = TestData.CeoBusinessEntityId,
                FirstName = TestData.CeoFirstName,
                MiddleName = TestData.CeoMiddleName,
                LastName = TestData.CeoLastName,
                JobTitle = TestData.CeoJobTitle
            };
        }

        #endregion
    }
}
