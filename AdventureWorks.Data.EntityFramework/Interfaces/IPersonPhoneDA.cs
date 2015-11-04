using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.EntityFramework.Interfaces
{
    public interface IPersonPhoneDA
    {
        void AddPhoneNumber(BusinessObjects.PersonPhone phoneNumber);

        void DeletePhoneNumber(BusinessObjects.PersonPhone phoneNumber);
    }
}
