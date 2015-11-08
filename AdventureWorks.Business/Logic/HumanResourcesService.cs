using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business
{
    using Extensions;
    using Logic;
    using Interfaces;
    using Data.Interfaces;
    using AdventureWorks.Data;
    using Enumerations;

    public class HumanResourcesService : BaseService, IHumanResourcesService
    {
        #region Private Fields

        private readonly IEmployeeDA EmployeeDA;

        private readonly IPersonPhoneDA PhoneDA;

        #endregion

        #region Constructors

        public HumanResourcesService(IEmployeeDA employeeDA, IPersonPhoneDA phoneDA) : base()
        {
            EmployeeDA = employeeDA;
            PhoneDA = phoneDA;
        }

        public HumanResourcesService()
        {
            IEmployeeDA employeeDA;
            IPersonPhoneDA personPhoneDA;

            if (DataMethod == 0)
            {
                employeeDA = new Data.EntityFramework.Core.EmployeeDA();
                personPhoneDA = new Data.EntityFramework.Core.PersonPhoneDA();
            }
            else
            {
                throw new NotImplementedException();
            }

            EmployeeDA = employeeDA;
            PhoneDA = personPhoneDA;
        }

        #endregion

        #region Public Methods

        public List<BusinessObjects.Employee> GetEmployees()
        {
            return EmployeeDA.GetAllEmployees();
        }

        public BusinessObjects.Employee GetEmployeeById(int id)
        {
                return EmployeeDA.GetEmployeeByBusinessEntityId(id);
        }

        public bool UpdateEmployee(BusinessObjects.Employee employee)
        {
            EmployeeDA.UpdateEmployee(employee);
            return true;
        }

        public bool AddPhoneNumber(BusinessObjects.PersonPhone phone)
        {
            // Ensure person is an employee
            var employee = EmployeeDA.GetEmployeeByBusinessEntityId(phone.BusinessEntityId);

            if (employee == null)
            {
                // Rather than updating a non-employee, return false
                return false;
            }

            PhoneDA.AddPhoneNumber(phone);
            return true;
        }

        public bool DeletePhoneNumber(BusinessObjects.PersonPhone phone)
        {
            // Ensure person is an employee
            var employee = EmployeeDA.GetEmployeeByBusinessEntityId(phone.BusinessEntityId);

            if (employee == null)
            {
                // Rather than updating a non-employee, return false
                return false;
            }

            // Delete the phone number
            PhoneDA.DeletePhoneNumber(phone);
            return true;
        }

        #endregion
    }
}
