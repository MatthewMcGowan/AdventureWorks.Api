using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.TestData
{
    public static class TestData
    {
        #region Employee Database Data

        public const int CeoBusinessEntityId = 1;
        public const string CeoFirstName = "Ken";
        public const string CeoMiddleName = "J";
        public const string CeoLastName = "Sánchez";
        public const string CeoJobTitle = "Chief Executive Officer";
        public const string CeoPhoneNumber = "697-555-0142";
        public const Enumerations.PhoneNumberTypeEnum CeoPhoneNumberType = Enumerations.PhoneNumberTypeEnum.Cell;

        public const int AlternativeBusinessEntityId = 2;
        public const string AlternativeFirstName = "Gary";
        public const string AlternativePhoneNumber = "123-456-7890";

        #endregion

        #region Web.config Data

        public const string DataAccessMethodKey = "DataAccessMethod";
        public const string DataAccessMethodEntityFramework = "EntityFramework";

        #endregion
    }
}
