using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Interfaces
{
    public interface IPersonPhoneDA
    {
        List<BusinessObjects.PersonPhone> GetEmployeePersonPhonesByBusinessEntityId(int id);

        Task<BusinessObjects.PersonPhone> GetPhoneNumberAsync(int businessEntityId, string phoneNumber, int phoneNumberType);

        void AddPhoneNumber(BusinessObjects.PersonPhone phoneNumber);

        void DeletePhoneNumber(BusinessObjects.PersonPhone phoneNumber);
    }
}
