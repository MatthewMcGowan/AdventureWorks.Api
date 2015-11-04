using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Api
{
    using AutoMapper;
    using Models;

    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            // Employee
            Mapper.CreateMap<EmployeeModel, BusinessObjects.Employee>();
            Mapper.CreateMap<BusinessObjects.Employee, EmployeeModel>();

            // Phone Number
            Mapper.CreateMap<EmployeePhoneModel, BusinessObjects.PersonPhone>();
        }
    }
}