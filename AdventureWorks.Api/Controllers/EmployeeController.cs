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
        public IHttpActionResult GetEmployees()
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

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IHttpActionResult PostEmployee(EmployeeModel model)
        {
            var employee = Mapper.Map<BusinessObjects.Employee>(model);

            bool updated = HumanResourcesService.UpdateEmployee(employee);

            if (!updated)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult PutEmployeePhoneNumber(EmployeePhoneModel model)
        {
            var phoneNumber = Mapper.Map<BusinessObjects.PersonPhone>(model);

            bool added = HumanResourcesService.AddPhoneNumber(phoneNumber);

            if (!added)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployeePhoneNumber(EmployeePhoneModel model)
        {
            var phoneNumber = Mapper.Map<BusinessObjects.PersonPhone>(model);

            bool deleted = HumanResourcesService.DeletePhoneNumber(phoneNumber);

            if (!deleted)
            {
                return NotFound();
            }

            return Ok();
        }

        #endregion
    }
}
