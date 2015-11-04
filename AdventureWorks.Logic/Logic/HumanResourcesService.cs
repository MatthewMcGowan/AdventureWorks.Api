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
    using Logic;
    using Interfaces;
    using Data.EntityFramework.Interfaces;
    using Enumerations;

    public class HumanResourcesService : BaseService, IHumanResourcesService
    {
        #region Private Fields

        private readonly IEmployeeDA EmployeeDA;

        #endregion

        #region Constructors

        public HumanResourcesService(IEmployeeDA employeeDA) : base()
        {
            EmployeeDA = employeeDA;
        }

        public HumanResourcesService() : this(new EmployeeDA())
        {
        }

        #endregion

        #region Public Methods

        public List<Employee> GetEmployees()
        {
            List<Employee> employees;

            switch (DataAccessMethod)
            {
                case 0:
                    employees = EmployeeDA.GetAllEmployees().MapToBusinessLayer();
                    break;
                default:
                    throw new NotImplementedException();
            }


            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee;

            switch(DataAccessMethod)
            {
                case 0:
                    employee = EmployeeDA.GetEmployeeByBusinessEntityId(id).MapToBusinessLayer();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return employee;
        }

        public void UpdateEmployee(Employee employee)
        {
            var e = EmployeeDA.GetEmployeeByBusinessEntityId(employee.BusinessEntityId);

            e.MapFromBusinessLayer(employee);

            EmployeeDA.UpdateEmployee(e);
        }

        #endregion
    }
}
