using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorks.Api.Controllers
{
    using AdventureWorks.Api.Models;
    using AdventureWorks.Logic;
    using Logic.Objects;
    using AutoMapper;

    public class EmployeeController : ApiController
    {
        #region Private Fields

        private readonly HumanResourcesLogic HumanResourcesLogic;

        #endregion

        #region Constructors

        public EmployeeController()
        {
            HumanResourcesLogic = new HumanResourcesLogic();
        }

        #endregion

        #region Public Actions

        public IHttpActionResult GetEmployees ()
        {
            var employeeBos = HumanResourcesLogic.GetEmployees();

            if (employeeBos.Any())
            {
                return NotFound();
            }

            var employees = Mapper.Map<IEnumerable<EmployeeModel>>(employeeBos);
            return Ok(employees);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            return getEmployeeByIdEf(id);
        }

        public void PostEmployee(EmployeeModel employee)
        {
            var employeeBo = Mapper.Map<EmployeeBO>(employee);

            HumanResourcesLogic.UpdateEmployee(employeeBo);
        }

        public void PutEmployee()
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private Methods

        private IHttpActionResult getEmployeeByIdEf(int id)
        {
            var employeeBo = HumanResourcesLogic.GetEmployeeById(id);
            var employee = Mapper.Map<EmployeeModel>(employeeBo);
            return Ok(employee);
        }

        private IHttpActionResult getEmployeeByIdTest(int id)
        {
            if (id < 1)
            {
                return NotFound();
            }

            var employee = new EmployeeModel
            {
                BusinessEntityId = id,
                FirstName = "Matthew",
                LastName = "McGowan",
                JobTitle = "Software Engineer",
                OrganizationNode = "/"
            };

            return Ok(employee);
        }

        #endregion
    }
}
