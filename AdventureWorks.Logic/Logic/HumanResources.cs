using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business
{
    using Data.EntityFramework.HumanResources;
    using Objects;
    using Extensions;

    public class HumanResources
    {
        #region Private Fields

        private readonly EmployeeDA EmployeeDA;

        #endregion

        #region Constructors

        public HumanResources()
        {
            EmployeeDA = new EmployeeDA();
        }

        #endregion

        #region Public Methods

        public List<Employee> GetEmployees()
        {
            var businessEntities = EmployeeDA.GetAllEmployees();

            var employees = businessEntities.MapToBusinessLayer();

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            var businessEntity = EmployeeDA.GetEmployeeByBusinessEntityId(id);

            var employee = businessEntity.MapToBusinessLayer();

            return employee;
        }

        public void UpdateEmployee(Objects.Employee employee)
        {
            var businessEntity = EmployeeDA.GetEmployeeByBusinessEntityId(employee.BusinessEntityId);


        }

        #endregion
    }
}
