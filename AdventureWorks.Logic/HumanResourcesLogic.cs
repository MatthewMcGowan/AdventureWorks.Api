using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Logic
{
    using Data.EntityFramework.HumanResources;
    using Data.EntityFramework;
    using AutoMapper;
    using Objects;

    public class HumanResourcesLogic
    {
        public EmployeeBO GetEmployeeById(int id)
        {
            var employeeDa = new EmployeeDA();

            var businessEntity = employeeDa.GetEmployeeByBusinessEntityId(id);

            Mapper.CreateMap<Employee, EmployeeBO>();
            var employee = Mapper.Map<EmployeeBO>(businessEntity);

            return employee;
        }
    }
}
