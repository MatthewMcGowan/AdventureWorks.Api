using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Interfaces
{
    public interface IPersonPhoneDA
    {
        Task<List<BusinessObjects.PersonPhone>> GetPhoneNumbersByBusinessEntityIdAsync(int id);

        void AddPhoneNumber(BusinessObjects.PersonPhone phoneNumber);

        void DeletePhoneNumber(BusinessObjects.PersonPhone phoneNumber);
    }
}
