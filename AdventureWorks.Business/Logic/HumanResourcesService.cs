using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business
{
    using Data.EntityFramework.Core;
    using Extensions;
    using Logic;
    using Interfaces;
    using Data.EntityFramework.Interfaces;
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

        public HumanResourcesService() : this(new EmployeeDA(), new PersonPhoneDA())
        {
        }

        #endregion

        #region Public Methods

        public List<BusinessObjects.Employee> GetEmployees()
        {
            if(DataMethod == 0)
            {
                return EmployeeDA.GetAllEmployees().MapToBusinessLayer();
            }
            else if(DataMethod == 1)
            {
                throw new NotImplementedException();
            }
            else if(DataMethod == 2)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public BusinessObjects.Employee GetEmployeeById(int id)
        {
            if (DataMethod == 0)
            {
                return EmployeeDA.GetEmployeeByBusinessEntityId(id).MapToBusinessLayer();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public bool UpdateEmployee(BusinessObjects.Employee employee)
        {
            if(DataMethod == 0)
            {
                EmployeeDA.UpdateEmployee(employee);
                return true;
            }
            else
            {
                throw new NotImplementedException();
            }
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

            // Add the phone number
            if (DataMethod == 0)
            {
                PhoneDA.AddPhoneNumber(phone);
                return true;
            }
            else
            {
                throw new NotImplementedException();
            }
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
            if (DataMethod == 0)
            {
                PhoneDA.DeletePhoneNumber(phone);
                return true;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
