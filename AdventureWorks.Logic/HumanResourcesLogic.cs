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
        #region Private Fields

        private readonly EmployeeDA EmployeeDA;

        #endregion

        #region Constructors

        public HumanResourcesLogic()
        {
            EmployeeDA = new EmployeeDA();
            Mapper.CreateMap<Employee, EmployeeBO>();
        }

        #endregion

        #region Public Methods

        public IEnumerable<EmployeeBO> GetEmployees()
        {
            var businessEntities = EmployeeDA.GetAllEmployees();

            var employees = Mapper.Map<IEnumerable<EmployeeBO>>(businessEntities);

            return employees;
        }

        public EmployeeBO GetEmployeeById(int id)
        {
            var businessEntity = EmployeeDA.GetEmployeeByBusinessEntityId(id);
            
            var employee = Mapper.Map<EmployeeBO>(businessEntity);

            return employee;
        }

        public void UpdateEmployee(EmployeeBO employee)
        {
            var businessEntity = EmployeeDA.GetEmployeeByBusinessEntityId(employee.BusinessEntityId);


        }

        #endregion
    }
}
