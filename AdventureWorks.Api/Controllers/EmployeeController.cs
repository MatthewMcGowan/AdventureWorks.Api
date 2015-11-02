using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorks.Api.Controllers
{
    using AdventureWorks.Api.Models;
    using AdventureWorks.Business;
    using AutoMapper;

    public class EmployeeController : ApiController
    {
        #region Private Fields

        private readonly HumanResources HumanResources;

        #endregion

        #region Constructors

        public EmployeeController()
        {
            HumanResources = new HumanResources();
        }

        #endregion

        #region Public Actions

        public IHttpActionResult GetEmployees ()
        {
            var employeeBos = HumanResources.GetEmployees();

            if (employeeBos.Any())
            {
                return NotFound();
            }

            var employees = Mapper.Map<IEnumerable<EmployeeModel>>(employeeBos);
            return Ok(employees);
        }

        public IHttpActionResult GetEmployee(int id)
        {
            return getEmployeeById(id);
        }

        public void PostEmployee(EmployeeModel employee)
        {
            var employeeBo = Mapper.Map<Business.Objects.Employee>(employee);

            HumanResources.UpdateEmployee(employeeBo);
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

        private IHttpActionResult getEmployeeById(int id)
        {
            var employeeBo = HumanResources.GetEmployeeById(id);
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
            };

            return Ok(employee);
        }

        #endregion
    }
}
