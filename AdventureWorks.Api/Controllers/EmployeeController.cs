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
    using AutoMapper;

    public class EmployeeController : ApiController
    {
        public IHttpActionResult GetEmployeeById(int id)
        {
            return getEmployeeByIdEf(id);
        }

        private IHttpActionResult getEmployeeByIdEf(int id)
        {
            var humanResourcesLogic = new HumanResourcesLogic();
            var employeeBo = humanResourcesLogic.GetEmployeeById(id);
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
    }
}
