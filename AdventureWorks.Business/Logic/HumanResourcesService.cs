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

        public HumanResourcesService(IEmployeeDA employeeDA, IPersonPhoneDA phoneDA, IAppSettingReader appReader) : base(appReader)
        {
            EmployeeDA = employeeDA;
            PhoneDA = phoneDA;
        }

        public HumanResourcesService() : base()
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
            // Check if an employee, and that this number does not already exist
            var check = CheckEmployeeExistsAndNumberDoesnt(phone);
            if(!check.Result)
            {
                return false;
            }

            // Add number to database
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

        #region Private Methods

        private async Task<bool> CheckEmployeeExistsAndNumberDoesnt(BusinessObjects.PersonPhone phone)
        {
            // Get numbers for this business entity Id
            var employeeNumbersTask = PhoneDA.GetPhoneNumbersByBusinessEntityIdAsync(phone.BusinessEntityId);

            // Ensure person is an employee
            var employeeTask = EmployeeDA.GetEmployeeByBusinessEntityIdAsync(phone.BusinessEntityId);

            // If added number already exists, or not an employee, don't add number
            List<BusinessObjects.PersonPhone> numbers = await employeeNumbersTask;
            BusinessObjects.Employee employee = await employeeTask;
            if (employee == null || numbers.Any(n => n.Equals(phone)))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
