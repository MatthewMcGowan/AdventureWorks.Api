using AdventureWorks.Api.Models;
using AdventureWorks.Business;
using AdventureWorks.Business.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdventureWorks.Api.Controllers
{
    public class EmployeePhoneController : ApiController
    {
        #region Private Fields

        private readonly IHumanResourcesService HumanResourcesService;

        #endregion

        #region Constructors

        public EmployeePhoneController(IHumanResourcesService humanResourcesService)
        {
            HumanResourcesService = humanResourcesService;
        }

        public EmployeePhoneController() : this (new HumanResourcesService())
        {
        }

        #endregion

        #region Public Actions

        [HttpGet]
        public IHttpActionResult GetEmployeePhoneNumbers(int id)
        {
            // Get any phone numbers for this entity, and map to model
            var phoneNumbers = HumanResourcesService.GetPhoneNumbersByEmployeeId(id);
            var phoneModels = Mapper.Map<List<EmployeePhoneModel>>(phoneNumbers);

            // If no phone numbers, return not found
            if (phoneNumbers.Count == 0)
            {
                return NotFound();
            }

            return Ok(phoneModels);
        }

        [HttpPut]
        public IHttpActionResult PutEmployeePhoneNumber([FromBody]EmployeePhoneModel model)
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
        public IHttpActionResult DeleteEmployeePhoneNumber([FromBody]EmployeePhoneModel model)
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