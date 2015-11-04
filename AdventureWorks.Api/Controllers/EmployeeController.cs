using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace AdventureWorks.Api.Controllers
{
    using AdventureWorks.Api.Models;
    using AdventureWorks.Business;
    using Business.Interfaces;
    using AutoMapper;

    public class EmployeeController : ApiController
    {
        #region Private Fields

        private readonly IHumanResourcesService HumanResourcesService;

        #endregion

        #region Constructors

        public EmployeeController(IHumanResourcesService humanResourcesService)
        {
            HumanResourcesService = humanResourcesService;
        }

        public EmployeeController() : this(new HumanResourcesService())
        {
        }

        #endregion

        #region Public Actions

        [HttpGet]
        public IHttpActionResult GetEmployees ()
        {
            var employeeBos = HumanResourcesService.GetEmployees();

            if (employeeBos.Any())
            {
                return NotFound();
            }

            var employees = Mapper.Map<IEnumerable<EmployeeModel>>(employeeBos);
            return Ok(employees);
        }

        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            var employeeBo = HumanResourcesService.GetEmployeeById(id);
            var employee = Mapper.Map<EmployeeModel>(employeeBo);
            return Ok(employee);
        }

        [HttpPost]
        public void PostEmployee(EmployeeModel employee)
        {
            var employeeBo = Mapper.Map<Business.Objects.Employee>(employee);

            HumanResourcesService.UpdateEmployee(employeeBo);
        }

        [HttpPut]
        public void PutEmployee()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
