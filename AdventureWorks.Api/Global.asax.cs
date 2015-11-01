using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace AdventureWorks.Api
{
    using AutoMapper;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Mapper.CreateMap<Logic.Objects.EmployeeBO, Api.Models.EmployeeModel>();
        }
    }
}
