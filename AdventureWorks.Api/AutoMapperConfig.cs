using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Api
{
    using Business.Objects;
    using AutoMapper;
    using Models;

    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.CreateMap<Employee, EmployeeModel>();
            Mapper.CreateMap<EmployeeModel, Employee>();
        }
    }
}