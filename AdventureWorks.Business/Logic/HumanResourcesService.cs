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

        #region Employee Methods

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
            // Check business object sent is valid, and the employee exists
            if (employee == null 
                || employee.BusinessEntityId < 0
                || EmployeeDA.GetEmployeeByBusinessEntityId(employee.BusinessEntityId) == null)
            {
                return false;
            }

            EmployeeDA.UpdateEmployee(employee);
            return true;
        }

        public List<BusinessObjects.PersonPhone> GetPhoneNumbersByEmployeeId(int id)
        {
            return PhoneDA.GetEmployeePersonPhonesByBusinessEntityId(id);
        }

        #endregion

        #region General Phone Methods

        public bool AddPhoneNumber(BusinessObjects.PersonPhone phone)
        {
            // Check if an employee, and that this number does not already exist
            if(!CheckEmployeeExistsAndNumberDoesnt(phone).Result)
            {
                return false;
            }

            // Add number to database
            PhoneDA.AddPhoneNumber(phone);
            return true;
        }

        public bool DeletePhoneNumber(BusinessObjects.PersonPhone phone)
        {
            // Check phone number exists, and that this business entity is an employee
            if (!CheckEmployeeAndPhoneNumberExist(phone).Result)
            {
                return false;
            }

            // Delete the phone number
            PhoneDA.DeletePhoneNumber(phone);
            return true;
        }

        #endregion

        #endregion

        #region Private Methods

        private async Task<bool> CheckEmployeeAndPhoneNumberExist(BusinessObjects.PersonPhone phone)
        {
            // Get phone number
            var phoneTask = PhoneDA.GetPhoneNumberAsync(phone.BusinessEntityId, phone.PhoneNumber, (int)phone.PhoneNumberType);

            // Get employee
            var employeeTask = EmployeeDA.GetEmployeeByBusinessEntityIdAsync(phone.BusinessEntityId);

            // If either of these are null, return false
            if(await phoneTask == null || await employeeTask == null)
            {
                return false;
            }

            // Otherwise both exist, so return true
            return true;
        }

        private async Task<bool> CheckEmployeeExistsAndNumberDoesnt(BusinessObjects.PersonPhone phone)
        {
            // Get phone number
            var phoneTask = PhoneDA.GetPhoneNumberAsync(phone.BusinessEntityId, phone.PhoneNumber, (int)phone.PhoneNumberType);

            // Get employee
            var employeeTask = EmployeeDA.GetEmployeeByBusinessEntityIdAsync(phone.BusinessEntityId);

            // If added number already exists, or not an employee, return false
            if (await phoneTask != null || await employeeTask == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
