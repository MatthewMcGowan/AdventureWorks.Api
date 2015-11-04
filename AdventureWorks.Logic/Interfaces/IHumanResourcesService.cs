using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Interfaces
{
    public interface IHumanResourcesService
    {
        List<BusinessObjects.Employee> GetEmployees();

        BusinessObjects.Employee GetEmployeeById(int id);

        bool UpdateEmployee(BusinessObjects.Employee employee);

        bool AddPhoneNumber(BusinessObjects.PersonPhone phone);

        bool DeletePhoneNumber(BusinessObjects.PersonPhone phone);
    }
}
