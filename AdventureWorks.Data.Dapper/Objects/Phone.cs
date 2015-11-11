using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Dapper.Objects
{
    public class Phone
    {
        public int BusinessEntityId { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberType { get; set; }
    }
}
